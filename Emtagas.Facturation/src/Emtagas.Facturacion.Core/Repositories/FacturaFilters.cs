using System;
using Microsoft.VisualBasic;

namespace Emtagas.Facturacion.Core.Repositories
{
    public class FacturaFilters
    {
        public int? NumeroFactura { get; set; }
        
        public string? NIT { get; set; }
        
        public string? RazonSocial { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
    }
}