using System;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Xml;
using Emtagas.Facturacion.Core.Entities;

namespace Emtagas.Facturacion.Core.Utils
{
    public class XMLSerializer
    {
        public string Serialize(Factura factura)
        {
            using (var stream = new MemoryStream())
            {
                var doc = new XmlDocument();
                var declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                var root = doc.DocumentElement;
                doc.InsertBefore(declaration, root);

                var cabecera = doc.CreateElement("cabecera");

                var nitEmisor = doc.CreateElement("nitEmisor");
                cabecera.AppendChild(nitEmisor);


                var container = doc.CreateElement("facturaElectronicaCompraVenta", "http://www.w3.org/2001/XMLSchema-instance");
                container.AppendChild(cabecera);
                doc.AppendChild(container);
            
                doc.Save(stream);

                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        private static XmlElement CreateDetalle(XmlDocument doc, DetalleFactura detalle)
        {
            var detalleNode = doc.CreateElement("detalle");
            return detalleNode;
        }

        private static XmlElement CreateTextNode(XmlDocument doc, string name, string value)
        {
            var node = doc.CreateElement(name, "xsi");
            
            if (value == null)
            {
                return node;
            }
            
            node.AppendChild(doc.CreateTextNode(value));
            return node;
        }
    }
}
