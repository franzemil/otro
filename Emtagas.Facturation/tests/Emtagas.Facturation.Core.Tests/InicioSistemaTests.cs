using System.Threading.Tasks;
using Emtagas.Facturacion.Core;
using Emtagas.Facturacion.INServices;
using Emtagas.Facturation.Core.Tests.Fixtures;
using Emtagas.Facturation.Repository.Repositories;
using Emtagas.Facturation.SQLServerRepository.Repositories;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Emtagas.Facturation.Core.Tests
{
    public class InicioSistemaTests: IClassFixture<DbContextFixture>, IClassFixture<ConfigurationFixture>
    {
        private ConfigurationFixture ConfigurationFixture { get; }
        
        private DbContextFixture DbContextFixture { get; }
        
        public InicioSistemaTests(DbContextFixture dbContextFixture, ConfigurationFixture configurationFixture)
        {
            ConfigurationFixture = configurationFixture;
            DbContextFixture = dbContextFixture;
        }
        
        [Fact]
        public async Task ItShouldSaveTheParameters()
        {
            var config = ConfigurationFixture.config;

            var application = new FacturacionFacade(
                ConfigurationFixture.config,
                new FacturaRepository(DbContextFixture.DbContext),
                new DeclaracionFacturaRepository(DbContextFixture.DbContext),
                new CodigoFacturacionRepository(DbContextFixture.DbContext),
                new ParametroRepository(DbContextFixture.DbContext),
                new ImpuestosServices(config, new NullLogger<ImpuestosServices>())
            );

            await application.InicioSistema();
        }
    }
}