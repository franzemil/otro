using System.Collections.Generic;
using System.Linq;
using Emtagas.Facturacion.Core.Repositories;
using Emtagas.Facturacion.Core.ValueObjects;
using Emtagas.Facturation.Repository;
using Emtagas.Facturation.Repository.Models;

namespace Emtagas.Facturation.SQLServerRepository.Repositories
{
    public class ParametroRepository : IParametroRepository
    {
        private readonly EmtagasDbContext _context;
        private static IEnumerable<Parametro> _cachedParametros;

        public ParametroRepository(EmtagasDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Parametro> SaveParametros(IEnumerable<Parametro> toSave)
        {
            _context.Parametros.RemoveRange(_context.Parametros);
            
            var toAdd = toSave.Select(p => new ParametroModel(p));
                
            _context.AddRange(toAdd);

            _context.SaveChanges();

            return toSave;
        }

        public IEnumerable<Parametro> GetParametros()
        {
            return _cachedParametros ??= _context.Parametros.ToList().Select(p => p.ToModel());
        }
    }
}