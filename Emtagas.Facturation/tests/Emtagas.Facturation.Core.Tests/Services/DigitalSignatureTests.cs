using System.IO;
using System.Reflection;
using Emtagas.Facturacion.Core.Services;
using Emtagas.Facturacion.Core.Utils;
using Emtagas.Facturation.Core.Tests.Fixtures;
using Emtagas.Facturation.Repository.Repositories;
using Xunit;

namespace Emtagas.Facturation.Core.Tests.Services
{
    public class DigitalSignatureTests: IClassFixture<DbContextFixture>, IClassFixture<ConfigurationFixture>
    {
        private readonly DbContextFixture _dbContextFixture;
        private readonly ConfigurationFixture _configurationFixture;

        public DigitalSignatureTests(DbContextFixture dbContextFixture, ConfigurationFixture configurationFixture)
        {
            _dbContextFixture = dbContextFixture;
            _configurationFixture = configurationFixture;
        }
        
        [Fact]
        public void SignShouldWorkWithValidDocument()
        {
            var certificatePath = "/home/franzemil/Projects/tarija/certificate/signing.crt";
            var privateKeyPath = "/home/franzemil/Projects/tarija/certificate/signing.key";
            
            var factura = new FacturaRepository(_dbContextFixture.DbContext).GetFactura(3890640);

            var serializer = new FacturaXmlSerializer(_configurationFixture.config, "6F9892E5");
            var facturaXml = serializer.Serialize(factura, "TEst");

            var dg = new DigitalSignature();

            var response = dg.Sign(facturaXml, certificatePath, privateKeyPath);

            Assert.True(true);
        }
    }
}