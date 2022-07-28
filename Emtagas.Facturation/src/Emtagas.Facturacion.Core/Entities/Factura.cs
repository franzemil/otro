using System;

namespace Emtagas.Facturacion.Core.Entities
{
    public class Factura
    {
        public int Id { get; set; }
        
        public int NumeroFactura { get; set; }

        public string RazonSocial { get; set; }
        
        public string NIT { get; set; }

        public decimal TotalFactura { get; set; }

        public int Mes { get; set; }
        
        public DateTime FechaPago { get; set; }
        
        public DateTime? FechaDeclaracion { get; set; }
        
        public bool Declarado { get; set; }

        public int IdCliente { get; set; }

        public string CodigoMedidor { get; set; }

        public DetalleFactura Detalle { get; set; }
    }
}
