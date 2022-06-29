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
            var savedParameters = toSave.Select(p => new ParametroModel(p)).Select(parametro =>
            {
                var currentParametro = _context.Parametros.First(p => p.TipoParametro == parametro.TipoParametro);

                if (currentParametro == null)
                {
                   return _context.Add(parametro).Entity;
                }
                    
                currentParametro.Codigo = parametro.Codigo;
                return parametro;
            });

            _context.SaveChanges();

            return savedParameters.Select(p => p.ToModel());
        }

        public IEnumerable<Parametro> GetParametros()
        {
            return _cachedParametros ??= _context.Parametros.ToList().Select(p => p.ToModel());
        }
    }
}