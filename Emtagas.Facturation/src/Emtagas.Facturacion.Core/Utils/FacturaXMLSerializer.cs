using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Emtagas.Facturacion.Common;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturacion.Core.Entities;

namespace Emtagas.Facturacion.Core.Utils
{
    public class FacturaXmlSerializer
    {
        private readonly Configuration _configuration;
        private readonly string _cufd;

        public FacturaXmlSerializer(Configuration configuration, string cufd)
        {
            _configuration = configuration;
            _cufd = cufd;
        }
        
        public string Serialize(Factura factura, string cuf)
        {
            var serializer = new XmlSerializer(typeof(FacturaComputarizadaServicioBasico));

            var memoryStream = new MemoryStream();

            serializer.Serialize(memoryStream, Format(factura, cuf));

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        private FacturaComputarizadaServicioBasico Format(Factura factura, string cuf)
        {
            var cabecera = new Cabecera
            {
                NitEmisor = _configuration.Nit,
                RazonSocialEmisor = _configuration.RazonSocial,
                Municipio = Constants.Municipio,
                NumeroFactura = factura.NumeroFactura,
                Cuf = cuf,
                Cufd = _cufd,
                CodigoSucursal = Constants.CasaMatriz, //Casa Matriz
                Direccion = Constants.Direccion,
                NumeroMedidor = Convert.ToInt32(factura.CodigoMedidor),
                FechaEmision = factura.FechaPago,
                NombreRazonSocial = factura.RazonSocial,
                CodigoTipoDocumentoIdentidad = 1, // 1 is CI
                NumeroDocumento = 1, //Get the CI,
                Complemento = "", // TODO: Get the complement
                CodigoCliente = factura.IdCliente,
                CodigoMetodoPago = Constants.MetodoPagoBolivianos, // Metodo de pago en efectivo
                MontoTotal = (double) factura.TotalFactura,
                MontoTotalSujetoIva = (int) factura.TotalFactura,
                CodigoMoneda = 1, // TODO: FindCodigos
                TipoCambio = 1, // Pago en Boliviano
                MontoTotalMoneda = (double) factura.TotalFactura,
                Leyenda = Constants.Leyenda, // TODO: Leyenda
                Usuario = "GOKU",
                CodigoDocumentoSector = 13,
            };

            var detalle = new Detalle()
            {
                CodigoProductoSin = 9900,
                ActividadEconomica = 352020,
                Cantidad = 1,
                Descripcion = factura.Detalle.Description,
                CodigoProducto = 2,
                UnidadMedida = Constants.MetrosCubicos68FBol,
                PrecioUnitario = 100,
                MontoDescuento = 0,
                SubTotal = factura.Detalle.SubTotal
            };
            
            return new FacturaComputarizadaServicioBasico()
            {
                Cabecera = cabecera,
                Detalle = detalle
            };
        }
    }
}
