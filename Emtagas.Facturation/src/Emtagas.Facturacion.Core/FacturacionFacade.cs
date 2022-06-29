using System;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.Exceptions;
using Emtagas.Facturacion.Core.Repositories;
using Emtagas.Facturacion.Core.Services;

namespace Emtagas.Facturacion.Core
{
    public sealed class FacturacionFacade
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly ICodigoFacturacionRepository _codigoFacturacionRepository;
        private readonly IDeclaracionFacturaRepository _declaracionFacturaRepository;
        private readonly IInpuestosNacionalesService _inServices;
        private readonly Configuration _configuration;

        public FacturacionFacade(Configuration configuration, IFacturaRepository facturaRepository, IDeclaracionFacturaRepository declaracionFacturaRepository, IInpuestosNacionalesService inServices)
        {
            _facturaRepository = facturaRepository;
            _configuration = configuration;
            _declaracionFacturaRepository = declaracionFacturaRepository;
            _inServices = inServices;
        }

        public async Task<string> GenerateCUF()
        {
            return default;
        }

        public async Task InicioSistema()
        {
            var cuis = await _inServices.SolicitarCodigoInicioSistema();
            
            _codigoFacturacionRepository.Save(cuis, TipoCodigo.CUIS);

            var codigos = _inServices.SincronizarParametros(cuis);
        }

        public async Task DeclararFacturas(params int[] facturas)
        {
            foreach (var facturaId in facturas)
            {
                var cuf = string.Empty;
                
                try
                {
                    cuf = _codigoFacturacionRepository.GetTodayCode(TipoCodigo.CUFD);
                }
                catch (CodigoNotFoundException)
                {
                    // TODO: Generate cuf
                }

                var declaracionFactura = new DeclaracionFactura()
                {
                    Id = Guid.NewGuid(),
                    CUF = cuf,
                    FacturaId = facturaId
                };
            }
        }

        public async Task DeclararFacturasSince()
        {
        }
    }
}