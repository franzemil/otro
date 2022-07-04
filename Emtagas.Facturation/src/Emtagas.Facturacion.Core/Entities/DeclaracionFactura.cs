using System;
using System.Collections.Generic;
using Emtagas.Facturacion.Core.ValueObjects;

namespace Emtagas.Facturacion.Core.Entities
{
    public class DeclaracionFactura
    {
        public Guid Id { get; set; }

        public int FacturaId { get; set; }

        public string CUFD { get; set; }
         
        public string CUF { get; set; }

        public byte[] File { get; set; }

        public string Hash { get; set; }

        public DateTime FechaDeclaracion { get; set; }

        public List<DeclaracionResponse> Detalle { get; set; }
    }
}