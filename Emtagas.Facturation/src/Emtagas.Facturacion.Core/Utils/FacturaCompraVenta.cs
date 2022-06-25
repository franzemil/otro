using System;
using System.Xml.Serialization;

namespace Emtagas.Facturacion.Core.Utils
{
    // [XmlRoot(ElementName = "codigoPuntoVenta")]
    // public class CodigoPuntoVenta
    // {
    //     [XmlAttribute(AttributeName = "nil")] public bool Nil { get; set; }
    // }
    //
    // [XmlRoot(ElementName = "complemento")]
    // public class Complemento
    // {
    //     [XmlAttribute(AttributeName = "nil")] public bool Nil { get; set; }
    // }
    //
    // [XmlRoot(ElementName = "numeroTarjeta")]
    // public class NumeroTarjeta
    // {
    //     [XmlAttribute(AttributeName = "nil")] public bool Nil { get; set; }
    // }
    //
    // [XmlRoot(ElementName = "montoGiftCard")]
    // public class MontoGiftCard
    // {
    //     [XmlAttribute(AttributeName = "nil")] public bool Nil { get; set; }
    // }
    //
    // [XmlRoot(ElementName = "codigoExcepcion")]
    // public class CodigoExcepcion
    // {
    //     [XmlAttribute(AttributeName = "nil")] public bool Nil { get; set; }
    // }
    //
    // [XmlRoot(ElementName = "cafc")]
    // public class Cafc
    // {
    //     [XmlAttribute(AttributeName = "nil")] public bool Nil { get; set; }
    // }

    [XmlRoot(ElementName = "cabecera")]
    public class Cabecera
    {
        [XmlElement(ElementName = "nitEmisor")]
        public int NitEmisor { get; set; }

        [XmlElement(ElementName = "razonSocialEmisor")]
        public string RazonSocialEmisor { get; set; }

        [XmlElement(ElementName = "municipio")]
        public string Municipio { get; set; }

        [XmlElement(ElementName = "telefono")] public int Telefono { get; set; }

        [XmlElement(ElementName = "numeroFactura")]
        public int NumeroFactura { get; set; }

        [XmlElement(ElementName = "cuf")] public string Cuf { get; set; }

        [XmlElement(ElementName = "cufd")] public string Cufd { get; set; }

        [XmlElement(ElementName = "codigoSucursal")]
        public int CodigoSucursal { get; set; }

        [XmlElement(ElementName = "direccion")]
        public string Direccion { get; set; }

        [XmlElement(ElementName = "codigoPuntoVenta")]
        public string CodigoPuntoVenta { get; set; }

        [XmlElement(ElementName = "fechaEmision")]
        public DateTime FechaEmision { get; set; }

        [XmlElement(ElementName = "nombreRazonSocial")]
        public string NombreRazonSocial { get; set; }

        [XmlElement(ElementName = "codigoTipoDocumentoIdentidad")]
        public int CodigoTipoDocumentoIdentidad { get; set; }

        [XmlElement(ElementName = "numeroDocumento")]
        public int NumeroDocumento { get; set; }

        [XmlElement(ElementName = "complemento")]
        public string Complemento { get; set; }

        [XmlElement(ElementName = "codigoCliente")]
        public int CodigoCliente { get; set; }

        [XmlElement(ElementName = "codigoMetodoPago")]
        public int CodigoMetodoPago { get; set; }

        [XmlElement(ElementName = "numeroTarjeta")]
        public int NumeroTarjeta { get; set; }

        [XmlElement(ElementName = "montoTotal")]
        public int MontoTotal { get; set; }

        [XmlElement(ElementName = "montoTotalSujetoIva")]
        public int MontoTotalSujetoIva { get; set; }

        [XmlElement(ElementName = "codigoMoneda")]
        public int CodigoMoneda { get; set; }

        [XmlElement(ElementName = "tipoCambio")]
        public int TipoCambio { get; set; }

        [XmlElement(ElementName = "montoTotalMoneda")]
        public int MontoTotalMoneda { get; set; }

        [XmlElement(ElementName = "montoGiftCard")]
        public int MontoGiftCard { get; set; }

        [XmlElement(ElementName = "descuentoAdicional")]
        public int DescuentoAdicional { get; set; }

        [XmlElement(ElementName = "codigoExcepcion")]
        public int CodigoExcepcion { get; set; }

        [XmlElement(ElementName = "cafc", IsNullable = true)] 
        public string Cafc { get; set; }

        [XmlElement(ElementName = "leyenda")] 
        public string Leyenda { get; set; }

        [XmlElement(ElementName = "usuario")]
        public string Usuario { get; set; }

        [XmlElement(ElementName = "codigoDocumentoSector")]
        public int CodigoDocumentoSector { get; set; }
    }

    [XmlRoot(ElementName = "detalle")]
    public class Detalle
    {
        [XmlElement(ElementName = "actividadEconomica")]
        public int ActividadEconomica { get; set; }

        [XmlElement(ElementName = "codigoProductoSin")]
        public int CodigoProductoSin { get; set; }

        [XmlElement(ElementName = "codigoProducto")]
        public string CodigoProducto { get; set; }

        [XmlElement(ElementName = "descripcion")]
        public string Descripcion { get; set; }

        [XmlElement(ElementName = "cantidad")] public int Cantidad { get; set; }

        [XmlElement(ElementName = "unidadMedida")]
        public int UnidadMedida { get; set; }

        [XmlElement(ElementName = "precioUnitario")]
        public int PrecioUnitario { get; set; }

        [XmlElement(ElementName = "montoDescuento")]
        public int MontoDescuento { get; set; }

        [XmlElement(ElementName = "subTotal")] public int SubTotal { get; set; }

        [XmlElement(ElementName = "numeroSerie")]
        public int NumeroSerie { get; set; }

        [XmlElement(ElementName = "numeroImei")]
        public int NumeroImei { get; set; }
    }

    [XmlRoot(ElementName = "facturaComputarizadaCompraVenta")]
    public class FacturaComputarizadaCompraVenta
    {
        [XmlElement(ElementName = "cabecera")] public Cabecera Cabecera { get; set; }

        [XmlElement(ElementName = "detalle")] public Detalle Detalle { get; set; }

        [XmlAttribute(AttributeName = "xsi")] public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "noNamespaceSchemaLocation")]
        public string NoNamespaceSchemaLocation { get; set; }

        [XmlText] public string Text { get; set; }
    }
}