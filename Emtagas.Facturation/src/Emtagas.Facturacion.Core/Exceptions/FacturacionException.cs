using System;

namespace Emtagas.Facturacion.Core.Exceptions
{
    public class FacturacionException : Exception
    {
        public FacturacionException(string message) : base(message)
        {
        }
    }
}