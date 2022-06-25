using System;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.Exceptions;
using Emtagas.Facturacion.Core.Repositories;

namespace Emtagas.Facturacion.Core
{
    public class FacturacionFacade
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly ICUFRepository _cufRepository;
        private readonly IDeclaracionFacturaRepository _declaracionFacturaRepository;
        private readonly Configuration _configuration;

        public FacturacionFacade(Configuration configuration, IFacturaRepository facturaRepository, IDeclaracionFacturaRepository declaracionFacturaRepository)
        {
            _facturaRepository = facturaRepository;
            _configuration = configuration;
            _declaracionFacturaRepository = declaracionFacturaRepository;
        }

        public async Task<string> GenerateCUF()
        {
            return default;
        }

        public async Task DeclararFacturas(params int[] facturas)
        {
            foreach (var facturaId in facturas)
            {
                var cuf = string.Empty;
                
                try
                {
                    cuf = _cufRepository.GetTodayCode();
                }
                catch (CUFNotFoundException)
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