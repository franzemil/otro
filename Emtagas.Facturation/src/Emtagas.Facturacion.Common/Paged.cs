using System.Collections.Generic;

namespace Emtagas.Facturacion.Common
{
    public abstract class Paged<T>
    {
        public int Count { get; set; }

        public IList<T> Items { get; set; }
    }
}
