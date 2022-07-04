using System;
using System.Collections.Generic;
using System.Linq;

namespace Emtagas.Facturacion.Core.Exceptions
{
    public class INServiceException : Exception
    {
        public INServiceException(IEnumerable<string> messages) : base(string.Join("\n", messages))
        {
        }
    }
}