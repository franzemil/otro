using Emtagas.Facturacion.Common;

namespace Emtagas.Facturacion.Core.Config
{
    public class Configuration
    {
        public const string DEFAULT_CODIGO_SUCURSAL = "1";
        
        public string InpuestosServiceApi { get; set; }
        
        public string ConnectionString { get; set; }

        public string CodigoSistema { get; set; }

        public string CodigoSucursal { get; init; } = DEFAULT_CODIGO_SUCURSAL;

        public int Ambiente => IsDevelopment ? Constants.AmbienteDesarrollo : Constants.AmbienteProduccion;

        public int Modalidad => Constants.ModalidadComputarizada;

        public int Nit { get; set; }

        public string RazonSocial { get; set; } = "Emtagas";

        public string ApiToken { get; init; }

        public bool IsDevelopment { get; init; }
    }
}