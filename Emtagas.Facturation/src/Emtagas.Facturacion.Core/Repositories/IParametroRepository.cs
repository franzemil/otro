using System.Collections.Generic;
using Emtagas.Facturacion.Core.ValueObjects;

namespace Emtagas.Facturacion.Core.Repositories
{
    public interface IParametroRepository
    {
        IEnumerable<Parametro> SaveParametros(IEnumerable<Parametro> toSave);

        IEnumerable<Parametro> GetParametros();
    }
}