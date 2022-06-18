using System.Linq;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.Repositories;

namespace Emtagas.Facturacion.Core
{
    public class FacturacionFacade
    {
        public IFacturaRepository FacturaRepository { get; }
        
        private readonly Configuration _configuration;

        public FacturacionFacade(Configuration configuration, IFacturaRepository facturaRepository)
        {
            FacturaRepository = facturaRepository;
            _configuration = configuration;
        }
    }
}