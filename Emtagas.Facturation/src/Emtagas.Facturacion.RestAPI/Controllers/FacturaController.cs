using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emtagas.Facturacion.Core;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.Repositories;
using Emtagas.Facturacion.RestAPI.Dto;
using Emtagas.Facturation.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Emtagas.Facturacion.RestAPI.Controllers
{
    [ApiController]
    [Route("facturas")]
    public class FacturaController : ControllerBase
    {
        private readonly FacturacionFacade _application;
        private readonly IFacturaRepository _facturaRepository;

        public FacturaController(FacturacionFacade application, IFacturaRepository facturaRepository)
        {
            _application = application;
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
            return _facturaRepository.GetFacturaFilteredAndPaged(filters, new Pagination() {PageSize = 10, Offset = 0})
                .Select(f => f).ToList();
        }

        [HttpGet]
        [Route(":id")]
        public async Task<ActionResult> GetSingleFactura([FromRoute(Name = "id")] int facturaId)
        {
            try
            {
                var cuis = _application.GetTodayCodigo(TipoCodigo.CUIS);
                await  _application.DeclararFactura(cuis, facturaId);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        [Route(":id/declarar")]
        public IActionResult DeclararFactura()
        {
            return default;
        }

        public IActionResult RedeclararFactura()
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