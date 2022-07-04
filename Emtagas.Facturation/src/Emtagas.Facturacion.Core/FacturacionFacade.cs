using System;
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
            

            // var codigos = await _inServices.SincronizarParametros(cuis);
            // _parametroRepository.SaveParametros(codigos);

        }

        public string GetTodayCodigo(TipoCodigo tipoCodigo)
        {
            return _codigoFacturacionRepository.GetTodayCode(tipoCodigo);
        }

        public Factura GetFacturaById(int facturaId)
        {
            return _facturaRepository.GetFactura(facturaId);
        }

        public async Task DeclararFacturas(string cuis, params int[] facturas)
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

                    var xmlSerializer = new FacturaXMLSerializer(_configuration, cufd);
                    var xmlValidator = new FacturaXmlValidator();

                    var xml = xmlSerializer.Serialize(factura, cuf);

                    xmlValidator.IsValid(xml);

                    var facturaCompresa = Utils.Utils.Comprimir(Encoding.UTF8.GetBytes(xml));
                    
                    var hash = Utils.Utils.ComputeHash256(facturaCompresa);

                    await _inServices.RecepcionarFactura(facturaCompresa, cuis, cufd, hash);

                }
                catch (CodigoNotFoundException)
                {
                    // TODO: Generate cuf
                    throw;
                }
                catch (InvalidXMLException)
                {
                    throw;
                }

                var declaracionFactura = new DeclaracionFactura()
                {
                    Id = Guid.NewGuid(),
                    CUF = cufd,
                    FacturaId = facturaId
                };
            }
        }

        public async Task DeclararFacturasSince()
        {
        }
    }
}