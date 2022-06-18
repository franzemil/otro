namespace Emtagas.Facturacion.Core.Entities
{
    public class DetalleFactura
    {
        public string CodigoProducto { get; set; }

        public string Description { get; set; }

        public decimal SubTotal { get; set; }
    }
}