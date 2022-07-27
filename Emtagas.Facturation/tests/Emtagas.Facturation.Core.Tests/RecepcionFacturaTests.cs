using System.Threading.Tasks;
using Emtagas.Facturacion.Core;
using Emtagas.Facturacion.Core.Repositories;
using Emtagas.Facturacion.INServices;
using Emtagas.Facturation.Core.Tests.Fixtures;
using Emtagas.Facturation.Repository.Repositories;
using Emtagas.Facturation.SQLServerRepository.Repositories;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Emtagas.Facturation.Core.Tests
{
    public class RecepcionFacturaTests : IClassFixture<DbContextFixture>, IClassFixture<ConfigurationFixture>
    {
        private readonly DbContextFixture _dbContextFixture;
        private readonly ConfigurationFixture _configurationFixture;

        public RecepcionFacturaTests(DbContextFixture dbContextFixture, ConfigurationFixture configurationFixture)
        {
            _dbContextFixture = dbContextFixture;
            _configurationFixture = configurationFixture;
        }
        
        [Fact]
        public async Task DeclarationShouldWorkSucessfuly()
        {
            var config = _configurationFixture.config;

            var application = new FacturacionFacade(
                config,
                new FacturaRepository(_dbContextFixture.DbContext),
                new DeclaracionFacturaRepository(_dbContextFixture.DbContext),
                new CodigoFacturacionRepository(_dbContextFixture.DbContext),
                new ParametroRepository(_dbContextFixture.DbContext),
                new ImpuestosServices(config, new NullLogger<ImpuestosServices>())
            );

            await application.InicioSistema();

            var cuis = application.GetTodayCodigo(TipoCodigo.CUIS);

            await application.DeclararFacturas(cuis, 3890640);
        }
    }
}