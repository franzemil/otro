using System;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturation.Core.Tests.Utils;

namespace Emtagas.Facturation.Core.Tests.Fixtures
{
    public class ConfigurationFixture : IDisposable
    {
        public Configuration config { get; set; }

        public ConfigurationFixture()
        {
            config = ConfigurationUtils.GetFromEnv();
        }
        
        public void Dispose()
        {
        }
    }
}