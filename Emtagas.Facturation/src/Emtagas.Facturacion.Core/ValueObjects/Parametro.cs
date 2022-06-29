namespace Emtagas.Facturacion.Core.ValueObjects
{
    public class Parametro
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }

        public TipoParametro TipoParametro { get; set; }
    }
}