using System;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.Utils;
using Emtagas.Facturacion.Core.ValueObjects;
using Emtagas.Facturation.Core.Tests.Data;
using Xunit;

namespace Emtagas.Facturation.Core.Tests.Utils
{
    public class XMLSerializerTests
    {

        [Fact]
        public void SerializerShouldWorkWithValidaFactura()
        {
            var factura = new Factura
            {
                // Id = Guid.NewGuid(),
                // Municipio = "La Paz",
                // NitEmisor = 123123,
                // RazonSocialEmisor = "PRUEBA",
                // CodigoUnicoFacturation = new CodigoUnicoFacturacion()
                // {
                //     Id = "B2AFA11610013351564D658EE50D2D2A4AA6B685",
                //     Fecha = DateTime.Now
                // },
                // CodigoSucursal = 0,
                // Direccion = "Calle Juan Pablo II #54",
                // FechaEmision  = new DateTime(2019, 7, 26, 0, 12, 0),
                // NombreRazonSocial = "Rios",
                // DocumentoIdentidad = new DocumentoIdentidad()
                // {
                //     TipoDocumentoIdentidad = 1,
                //     NumeroDocumento = "1548971",
                // },
                // CodigoCliente = "PMamani",
                // MetodoPago = MetodoPago.TARJETA,
                // MontoTotal = 25,
                // MontoTotalSujetoIVA = 25,
                // Leyenda = "Ley N° 453: Tienes derecho a recibir información sobre las características y contenidos de los servicios que utilices."
            };

            var serializer = new XMLSerializer();
            var facturaXML = serializer.Serialize(factura);

            Assert.Equal(TestData.GetFileContent("facturaComputarizadaCompraVenta.xml"), facturaXML);
        }
    }
}