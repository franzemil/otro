using System;
using Emtagas.Facturacion.Core.Services;
using Emtagas.Facturation.Core.Tests.Fixtures;
using Xunit;

namespace Emtagas.Facturation.Core.Tests.Services
{
    public class CodigoUnicoFacturacionTests : IClassFixture<ConfigurationFixture>
    {
        private readonly ConfigurationFixture _configurationFixture;

        public CodigoUnicoFacturacionTests(ConfigurationFixture configurationFixture)
        {
            _configurationFixture = configurationFixture;
        }
        
        [Fact]
        public void CufWithValidParameters()
        {

            var codigo = new CodigoGenerator(_configurationFixture.config);

            var cuf = codigo.GetCuf("ABCS", DateTime.Now, 1231);
            
            Assert.Equal(54, cuf.Length);

            Convert.ToInt32(cuf, 16);
        }
    }
}