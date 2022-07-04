namespace Emtagas.Facturacion.Core.Config
{
    public class Configuration
    {
        public const string DEFAULT_CODIGO_SUCURSAL = "1";
        
        public string ConnectionString { get; set; }

        public string CodigoSistema { get; set; }

        public string CodigoSucursal { get; set; } = DEFAULT_CODIGO_SUCURSAL;

        public int Nit { get; set; }

        public string RazonSocial { get; set; } = "Emtagas";

        public string ApiToken { get; set; }

        public bool IsDevelopment { get; set; }
    }
}