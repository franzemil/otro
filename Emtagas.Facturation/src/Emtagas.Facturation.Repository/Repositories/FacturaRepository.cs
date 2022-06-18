using System;
using System.Collections.Generic;
using System.Linq;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.Repositories;
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
                fdf.FechaDeclaracion
                FROM FaFactura ff
            LEFT JOIN FaDeclaracionFactura fdf ON ff.IdFactura = fdf.FacturaId");

            if (filters.NumeroFactura != null)
            {
                query = query.Where(f => f.NumeroFactura == filters.NumeroFactura);
            }
            
            if (filters.NIT != null)
            {
                query = query.Where(f => f.NIT.Contains(filters.RazonSocial));
            }

            if (filters.RazonSocial != null)
            {
                query = query.Where(f => f.RazonSocial.Contains(filters.RazonSocial));
            }

            return query
                .OrderByDescending(f => f.FechaPago)
                .Take(pagination.PageSize).Skip(pagination.PageSize * pagination.Offset)
                .ToList().Select(f => f.ToModel());
        }

        public Factura GetFactura(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}