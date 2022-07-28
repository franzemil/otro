using System.Text;
using System.Threading.Tasks;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.Exceptions;
using Emtagas.Facturacion.Core.Repositories;
using Emtagas.Facturacion.Core.Services;
using Emtagas.Facturacion.Core.Utils;
using Emtagas.Facturacion.Core.Validator;

namespace Emtagas.Facturacion.Core
{
    public sealed class FacturacionFacade
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly ICodigoFacturacionRepository _codigoFacturacionRepository;
        private readonly IParametroRepository _parametroRepository;
        private readonly IDeclaracionFacturaRepository _declaracionFacturaRepository;
        private readonly IInpuestosNacionalesService _inServices;
        private readonly Configuration _configuration;

        public FacturacionFacade(Configuration configuration,
            IFacturaRepository facturaRepository,
            IDeclaracionFacturaRepository declaracionFacturaRepository,
            ICodigoFacturacionRepository codigoFacturacionRepository,
            IParametroRepository parametroRepository,
            IInpuestosNacionalesService inServices)
        {
            _configuration = configuration;
            _facturaRepository = facturaRepository;
            _codigoFacturacionRepository = codigoFacturacionRepository;
            _parametroRepository = parametroRepository;
            _declaracionFacturaRepository = declaracionFacturaRepository;
            _inServices = inServices;
        }

        public async Task InicioSistema()
        {
            var cuis = string.Empty;
            
            try
            {
                 cuis = _codigoFacturacionRepository.GetTodayCode(TipoCodigo.CUIS);
            }
            catch  (CodigoNotFoundException e)
            {
                 cuis = await _inServices.SolicitarCodigoInicioSistema();
                _codigoFacturacionRepository.Save(cuis, TipoCodigo.CUIS);
            }

            try
            {
                _codigoFacturacionRepository.GetTodayCode(TipoCodigo.CUFD);
            }
            catch (CodigoNotFoundException e)
            {
                var (cufd, cufdControl) = await _inServices.SolicitarCodigoUnicoFacturacionDiaria(cuis);
                _codigoFacturacionRepository.Save(cufd, TipoCodigo.CUFD);
                _codigoFacturacionRepository.Save(cufdControl, TipoCodigo.CUFD_CONTROL);
            }

            var parametros = await _inServices.SincronizarParametros(cuis);
            _parametroRepository.SaveParametros(parametros);

        }

        public string GetTodayCodigo(TipoCodigo tipoCodigo)
        {
            return _codigoFacturacionRepository.GetTodayCode(tipoCodigo);
        }

        public Factura GetFacturaById(int facturaId)
        {
            return _facturaRepository.GetFactura(facturaId);
        }

        public async Task RedeclararFactura(int facturaId)
        {
            var declaracion = _declaracionFacturaRepository.GetDeclaracionFacturaByFacturaId(facturaId);

            if (declaracion == null)
            {
                throw new FacturacionException($"La Factura ({facturaId}) aun no ha sido declarada, trate de declarar Antes");
            }

            var cuis = _codigoFacturacionRepository.GetTodayCode(TipoCodigo.CUIS);
            
            var nuevaDeclaracion = await _inServices.RecepcionarFactura(declaracion.File, cuis,declaracion.CUFD, declaracion.Hash);

            declaracion.Detalle = nuevaDeclaracion.Detalle;
            declaracion.FechaDeclaracion = nuevaDeclaracion.FechaDeclaracion;
            declaracion.Success = nuevaDeclaracion.Success;
   
            _declaracionFacturaRepository.ActualizarDeclaracion(declaracion);
        }

        public async Task DeclararFactura(string cuis, int facturaId, int numTries = 0)
        {
            try
            {
                 await DeclararFacturas(cuis, facturaId);
            }
            catch (CodigoNotFoundException e)
            {
                if (numTries > 0)
                {
                    throw;
                }
                
                await InicioSistema();
                await DeclararFacturas(cuis, facturaId, 1);
            }
        }

        private async Task DeclararFacturas(string cuis, params int[] facturas)
        {
            foreach (var facturaId in facturas)
            {
                var cufd = string.Empty;
                var cufdControl = string.Empty;

                try
                {
                    cufd = _codigoFacturacionRepository.GetTodayCode(TipoCodigo.CUFD);
                    cufdControl = _codigoFacturacionRepository.GetTodayCode(TipoCodigo.CUFD_CONTROL);

                    var factura = _facturaRepository.GetFactura(facturaId);

                    var cuf = new CodigoGenerator(_configuration).GetCuf(cufdControl, factura.FechaPago,
                        factura.NumeroFactura);

                    var xmlSerializer = new FacturaXmlSerializer(_configuration, cufd);
                    var xmlValidator = new FacturaXmlValidator();
                    var xmlSigner = new DigitalSignature();

                    var xml = xmlSerializer.Serialize(factura, cuf);
                    var signedXml = xmlSigner.Sign(xml, _configuration.CertificatePath, _configuration.PrivateKeyPath);

                    xmlValidator.IsValid(signedXml);

                    var facturaCompresa = Utils.Utils.Comprimir(Encoding.UTF8.GetBytes(xml));
                    
                    var hash = Utils.Utils.ComputeHash256(facturaCompresa);

                    var declaracionFactura = await _inServices.RecepcionarFactura(facturaCompresa, cuis, cufd, hash);

                    declaracionFactura.FacturaId = facturaId;
                    declaracionFactura.File = facturaCompresa;
                    declaracionFactura.Hash = hash;
                    declaracionFactura.CUF = cuf;
                    declaracionFactura.CUFD = cufd;
                    
                    _declaracionFacturaRepository.SaveDeclaracionFactura(declaracionFactura);
                }
                catch (CodigoNotFoundException)
                {
                }
                catch (InvalidXMLException)
                {
                    throw;
                }
            }
        }

        public async Task DeclararFacturasSince()
        {
        }
    }
}