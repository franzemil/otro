using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Emtagas.Facturation.Repository.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly EmtagasDbContext _context;

        public FacturaRepository(EmtagasDbContext context)
        {
            _context = context;
        }
        
        public IQueryable<Factura> GetFacturaByDate(DateTime date)
        {
            return _context.Factura.Where(f => f.FechaPago != null).Select(f => f.ToModel());
        }

        public IEnumerable<Factura> GetFacturaFilteredAndPaged(FacturaFilters filters, Pagination pagination)
        {
            var query = _context.Factura.FromSqlRaw(@$"
            SELECT 
                ff.IdFactura AS Id, 
                ff.NroFactura as NumeroFactura,
                ff.NIT,
                ff.nombre as RazonSocial,
                ff.FechaPago as FechaPago,
                ff.TotalFactura,
                ff.Mes,
                fdf.FechaDeclaracion,
                fdf.Success as Declarado,
                c.IdCliente as IdCliente,
	            tm.CodMedidor as CodigoMedidor
            FROM FaFactura ff
            LEFT JOIN FaDeclaracionFactura fdf ON ff.IdFactura = fdf.FacturaId
            INNER JOIN AcContrato c ON ff.IdContrato = c.IdContrato 
            INNER JOIN TeMedidor tm ON tm.IdContrato = c.IdContrato ");

            if (filters.NumeroFactura != null && filters.NumeroFactura > 0)
            {
                query = query.Where(f => f.NumeroFactura == filters.NumeroFactura);
            }
            
            if (!string.IsNullOrEmpty(filters.NIT))
            {
                query = query.Where(f => f.NIT.Contains(filters.RazonSocial));
            }

            if (!string.IsNullOrEmpty(filters.RazonSocial))
            {
                query = query.Where(f => f.RazonSocial.Contains(filters.RazonSocial));
            }

            return query
                .OrderByDescending(f => f.FechaPago)
                .Take(pagination.PageSize).Skip(pagination.PageSize * pagination.Offset)
                .ToList().Select(f => f.ToModel());
        }

        public Factura GetFactura(int id)
        {
            var query = _context.Factura.FromSqlRaw(@$"
            SELECT 
                ff.IdFactura AS Id, 
                ff.NroFactura as NumeroFactura,
                ff.NIT,
                ff.nombre as RazonSocial,
                ff.FechaPago as FechaPago,
                ff.TotalFactura,
                ff.Mes,
                fdf.FechaDeclaracion,
                fdf.Success as Declarado,
                c.IdCliente as IdCliente,
	            tm.CodMedidor as CodigoMedidor
            FROM FaFactura ff
            LEFT JOIN FaDeclaracionFactura fdf ON ff.IdFactura = fdf.FacturaId
            INNER JOIN AcContrato c ON ff.IdContrato = c.IdContrato 
            INNER JOIN TeMedidor tm ON tm.IdContrato = c.IdContrato");

            return query.First(f => f.Id == id).ToModel();

        }
    }
}