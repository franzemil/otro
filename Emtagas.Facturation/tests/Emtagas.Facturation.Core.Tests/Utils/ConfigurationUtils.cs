using System;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturacion.INServices;

namespace Emtagas.Facturation.Core.Tests.Utils
{
    public class ConfigurationUtils
    {
        public static Configuration GetFromEnv()
        {
            return new Configuration()
            {
                Nit = Convert.ToInt32(Environment.GetEnvironmentVariable("NIT")),
                ApiToken = Environment.GetEnvironmentVariable("API_TOKEN"),
                CodigoSistema = Environment.GetEnvironmentVariable("CODIGO_SISTEMA"),
                IsDevelopment = true,
                CodigoSucursal = "1",
                ConnectionString = Environment.GetEnvironmentVariable("DB_URI")
            };
        }

    }
}