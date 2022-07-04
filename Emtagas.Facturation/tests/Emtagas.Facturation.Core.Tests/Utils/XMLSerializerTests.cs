using System;
using System.Linq;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.Exceptions;
using Emtagas.Facturacion.Core.Utils;
using Emtagas.Facturacion.Core.Validator;
using Emtagas.Facturacion.Core.ValueObjects;
using Emtagas.Facturation.Core.Tests.Data;
using Emtagas.Facturation.Core.Tests.Fixtures;
using Emtagas.Facturation.Repository.Repositories;
using Xunit;
using Xunit.Abstractions;

namespace Emtagas.Facturation.Core.Tests.Utils
{
    public class XMLSerializerTests : IClassFixture<DbContextFixture>, IClassFixture<ConfigurationFixture>
    {
        private readonly DbContextFixture _contextFixture;
        private readonly ConfigurationFixture _configurationFixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public XMLSerializerTests(DbContextFixture contextFixture, ConfigurationFixture configurationFixture, ITestOutputHelper testOutputHelper)
        {
            _contextFixture = contextFixture;
            _configurationFixture = configurationFixture;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void SerializerShouldWorkWithValidaFactura()
        {
            var factura = new FacturaRepository(_contextFixture.DbContext).GetFactura(3890640);

            var serializer = new FacturaXMLSerializer(_configurationFixture.config, "6F9892E5");
            var facturaXml = serializer.Serialize(factura, "TEst");


            var validator = new FacturaXmlValidator();

            try
            {
                validator.IsValid(facturaXml);
            }
            catch (InvalidXMLException)
            {
                _testOutputHelper.WriteLine("Invalid"); 
            }
            
            Assert.Equal(TestData.GetFileContent("facturaComputarizadaCompraVenta.xml"), facturaXml);
        }

        [Fact] 
        public void ItShouldThrowErrorWithInvalidXMLDocuments()
        {
            var facturaInvalid = TestData.GetFileContent("InvalidXmlDocument.xml");

            var validator = new FacturaXmlValidator();

            Assert.Throws<InvalidXMLException>(() => validator.IsValid(facturaInvalid));
        }
    }
}