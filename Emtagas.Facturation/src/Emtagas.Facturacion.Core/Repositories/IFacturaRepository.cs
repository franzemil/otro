using System;
using System.Collections.Generic;
using System.Linq;
using Emtagas.Facturacion.Common;
using Emtagas.Facturacion.Core.Entities;

namespace Emtagas.Facturacion.Core.Repositories
{
    public interface IFacturaRepository
    {
        IQueryable<Factura> GetFacturaByDate(DateTime date);
        
        IEnumerable<Factura> GetFacturaFilteredAndPaged(FacturaFilters filters, Pagination pagination);

        Factura GetFactura(int Id);
    }
}