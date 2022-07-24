using System;
using Microsoft.Extensions.Configuration;

namespace Emtagas.Facturacion.Core.Config
{
    public static class ConfigurationExtension
    {
        public static Configuration GetEmtagasConfiguration(this IConfiguration configuration)
        {
            return new Configuration
            {
                Nit = Convert.ToInt32(configuration["NIT"]),
                ApiToken = configuration["API_TOKEN"],
                CodigoSucursal = configuration["SUCURSAL"],
                CodigoSistema = configuration["CODIGO_SISTEMA"],
                InpuestosServiceApi = configuration["IMPUESTOS_API"],
                ConnectionString = configuration["DB_URI"],
                IsDevelopment = configuration["ASPNETCORE_ENVIRONMENT"].Equals("Development"),
                RazonSocial = configuration["RAZON_SOCIAL"]
            };
        }
    }
}