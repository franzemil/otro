using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.Repositories;
using Emtagas.Facturacion.RestAPI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Emtagas.Facturacion.RestAPI.Controllers
{
    [ApiController]
    [Route("facturas")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaController(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        [HttpGet(Name = "GetFacturas")]
        public IList<Factura> GetFacturas([FromQuery] FacturaQueryParams @params)
        {
            var filters = new FacturaFilters()
            {
                NumeroFactura = @params.NumeroFactura,
                NIT = @params.Nit,
                RazonSocial = @params.RazonSocial,
                StartDate = @params.StartDate,
                EndDate = @params.EndDate,
            };
            return _facturaRepository.GetFacturaFilteredAndPaged(filters, new Pagination() { PageSize = 10, Offset = 0}).Select(f => f).ToList();
        }

        [HttpGet]
        [Route(":id")]
        public ActionResult<Factura> GetSingleFactura([FromRoute(Name = "id")] Guid facturaId)
        {
            return default;
        }

        [HttpPost]
        [Route(":id/declarar")]
        public IActionResult DeclararFactura()
        {
            return default;
        }

        [HttpPost]
        public IActionResult DeclararFacturas()
        {
            return default;
        }
    }
}