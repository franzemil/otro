using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Emtagas.Facturacion.Core.Entities;

namespace Emtagas.Facturation.Repository.Models
{
    public class FacturaModel
    {
        public int Id { get; set; }

        public int NumeroFactura { get; set; }

        public string RazonSocial { get; set; }
        
        public string NIT { get; set; }
        
        public decimal TotalFactura { get; set; }

        public int Mes { get; set; }
        
        public DateTime FechaPago { get; set; }
        
        public DateTime? FechaDeclaracion { get; set; }

        public int IdCliente { get; set; }

        public string CodigoMedidor { get; set; }

        public Factura ToModel()
        {
            return new Factura()
            {
                Id = Id,
                NumeroFactura = NumeroFactura,
                RazonSocial = RazonSocial,
                NIT = NIT,
                TotalFactura = TotalFactura,
                Mes = Mes,
                FechaPago = FechaPago,
                FechaDeclaracion = FechaDeclaracion,
                IdCliente = IdCliente,
                CodigoMedidor = CodigoMedidor
            };
        }
    }
}