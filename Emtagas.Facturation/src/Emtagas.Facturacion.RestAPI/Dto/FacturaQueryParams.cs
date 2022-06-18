using System;
using Microsoft.AspNetCore.Mvc;

namespace Emtagas.Facturacion.RestAPI.Dto
{
    public class FacturaQueryParams
    {
        [FromQuery(Name = "numeroFactura")]
        public int NumeroFactura { get; set; }
        
        [FromQuery(Name = "nit")]
        public string Nit { get; set; }
        
        [FromQuery(Name = "razonSocial")]
        public string RazonSocial { get; set; }
        
        [FromQuery(Name = "startDate")]
        public DateTime StartDate { get; set; }
        
        [FromQuery(Name = "endDate")]
        public DateTime EndDate { get; set; }
    }
}