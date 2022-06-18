using System.Xml;

namespace Emtagas.Facturacion.Core.ValueObjects
{
    public class DocumentoIdentidad
    {
        public uint TipoDocumentoIdentidad { get; set; }

        public string NumeroDocumento { get; set; }

        public string? Complemento { get; set; }
    }
}