namespace Emtagas.Facturacion.Core.ValueObjects
{
    public class DeclaracionResponse
    {
        public int FacturaId { get; set; }

        public bool Success { get; set; }

        public string? Response { get; set; }
    }
}