using System;
using System.Xml.Serialization;

namespace Emtagas.Facturacion.Core.Utils
{
    // using System.Xml.Serialization;
// XmlSerializer serializer = new XmlSerializer(typeof(FacturaComputarizadaServicioBasico));
// using (StringReader reader = new StringReader(xml))
// {
//    var test = (FacturaComputarizadaServicioBasico)serializer.Deserialize(reader);
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

        [XmlElement(ElementName = "telefono", IsNullable = true)]
        public int? Telefono { get; set; }

        [XmlElement(ElementName = "numeroFactura")]
        public int NumeroFactura { get; set; }

        [XmlElement(ElementName = "cuf")]
        public string Cuf { get; set; }

        [XmlElement(ElementName = "cufd")] 
        public string Cufd { get; set; }

        [XmlElement(ElementName = "codigoSucursal")]
        public int CodigoSucursal { get; set; }

        [XmlElement(ElementName = "direccion")]
        public string Direccion { get; set; }

        [XmlElement(ElementName = "codigoPuntoVenta", IsNullable = true)]
        public int? CodigoPuntoVenta { get; set; }

        [XmlElement(ElementName = "mes", IsNullable = true)] 
        public string? Mes { get; set; }

        [XmlElement(ElementName = "gestion", IsNullable = true)] 
        public int? Gestion { get; set; }

        [XmlElement(ElementName = "ciudad", IsNullable = true)] 
        public string? Ciudad { get; set; }

        [XmlElement(ElementName = "zona", IsNullable = true)] 
        public string? Zona { get; set; }

        [XmlElement(ElementName = "numeroMedidor")]
        public int NumeroMedidor { get; set; }

        [XmlElement(ElementName = "fechaEmision")]
        public DateTime FechaEmision { get; set; }

        [XmlElement(ElementName = "nombreRazonSocial", IsNullable = true)]
        public string? NombreRazonSocial { get; set; }

        [XmlElement(ElementName = "domicilioCliente", IsNullable = true)]
        public string? DomicilioCliente { get; set; }

        [XmlElement(ElementName = "codigoTipoDocumentoIdentidad")]
        public int CodigoTipoDocumentoIdentidad { get; set; }

        [XmlElement(ElementName = "numeroDocumento")]
        public int NumeroDocumento { get; set; }

        [XmlElement(ElementName = "complemento", IsNullable = true)]
        public string? Complemento { get; set; }

        [XmlElement(ElementName = "codigoCliente")]
        public int CodigoCliente { get; set; }

        [XmlElement(ElementName = "codigoMetodoPago")]
        public int CodigoMetodoPago { get; set; }

        [XmlElement(ElementName = "numeroTarjeta", IsNullable = true)]
        public int? NumeroTarjeta { get; set; }

        [XmlElement(ElementName = "montoTotal")]
        public double MontoTotal { get; set; }

        [XmlElement(ElementName = "montoTotalSujetoIva")]
        public int MontoTotalSujetoIva { get; set; }

        [XmlElement(ElementName = "consumoPeriodo")]
        public int ConsumoPeriodo { get; set; }

        [XmlElement(ElementName = "beneficiarioLey1886", IsNullable = true)]
        public int? BeneficiarioLey1886 { get; set; }

        [XmlElement(ElementName = "montoDescuentoLey1886", IsNullable = true)]
        public double? MontoDescuentoLey1886 { get; set; }

        [XmlElement(ElementName = "montoDescuentoTarifaDignidad", IsNullable = true)]
        public double? MontoDescuentoTarifaDignidad { get; set; }

        [XmlElement(ElementName = "tasaAseo", IsNullable = true)] 
        public int? TasaAseo { get; set; }

        [XmlElement(ElementName = "tasaAlumbrado", IsNullable = true)]
        public int? TasaAlumbrado { get; set; }

        [XmlElement(ElementName = "ajusteNoSujetoIva", IsNullable = true)]
        public int? AjusteNoSujetoIva { get; set; }

        [XmlElement(ElementName = "detalleAjusteNoSujetoIva", IsNullable = true)]
        public string? DetalleAjusteNoSujetoIva { get; set; }

        [XmlElement(ElementName = "ajusteSujetoIva", IsNullable = true)]
        public int? AjusteSujetoIva { get; set; }

        [XmlElement(ElementName = "detalleAjusteSujetoIva", IsNullable = true)]
        public string? DetalleAjusteSujetoIva { get; set; }

        [XmlElement(ElementName = "otrosPagosNoSujetoIva", IsNullable = true)]
        public int? OtrosPagosNoSujetoIva { get; set; }

        [XmlElement(ElementName = "detalleOtrosPagosNoSujetoIva", IsNullable = true)]
        public string? DetalleOtrosPagosNoSujetoIva { get; set; }

        [XmlElement(ElementName = "otrasTasas", IsNullable = true)]
        public double? OtrasTasas { get; set; }

        [XmlElement(ElementName = "codigoMoneda")]
        public int CodigoMoneda { get; set; }

        [XmlElement(ElementName = "tipoCambio")]
        public int TipoCambio { get; set; }

        [XmlElement(ElementName = "montoTotalMoneda")]
        public double MontoTotalMoneda { get; set; }

        [XmlElement(ElementName = "descuentoAdicional", IsNullable = true)]
        public double? DescuentoAdicional { get; set; }

        [XmlElement(ElementName = "codigoExcepcion")]
        public int? CodigoExcepcion { get; set; }

        [XmlElement(ElementName = "cafc", IsNullable = true)] 
        public string? Cafc { get; set; }

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
        public int CodigoProducto { get; set; }

        [XmlElement(ElementName = "descripcion")]
        public string Descripcion { get; set; }

        [XmlElement(ElementName = "cantidad")] 
        public int Cantidad { get; set; } = 1;

        [XmlElement(ElementName = "unidadMedida")]
        public int UnidadMedida { get; set; }

        [XmlElement(ElementName = "precioUnitario")]
        public int PrecioUnitario { get; set; }

        [XmlElement(ElementName = "montoDescuento", IsNullable = true)]
        public double? MontoDescuento { get; set; }

        [XmlElement(ElementName = "subTotal")] 
        public int SubTotal { get; set; }
    }

    [XmlRoot(ElementName = "facturaComputarizadaServicioBasico")]
    public class FacturaComputarizadaServicioBasico
    {
        [XmlElement(ElementName = "cabecera")] 
        public Cabecera Cabecera { get; set; }

        [XmlElement(ElementName = "detalle")] 
        public Detalle Detalle { get; set; }
    }
}