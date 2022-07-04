using System;

namespace Emtagas.Facturacion.Core.Exceptions
{
    public class InvalidXMLException : Exception
    {
        public InvalidXMLException(string message) : base (message)
        {
        }
    }
}