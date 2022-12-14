using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Emtagas.Facturacion.Core.Exceptions;

namespace Emtagas.Facturacion.Core.Validator
{
    public class FacturaXmlValidator
    {

        public void IsValid(string xml)
        {
            var path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(FacturaXmlValidator)).Location);
            var schema = new XmlSchemaSet();
            schema.Add("http://www.w3.org/2000/09/xmldsig#", Path.Join(path, "Utils", "SignatureSchema.xsd"));
            schema.Add("", Path.Join(path, "Utils", "facturaElectronicaServicioBasico.xsd"));

            var doc = new XmlDocument();
            
            doc.LoadXml(xml);
            doc.Schemas.Add(schema);
        
            
            doc.Validate((sender, args) =>
            {
                if (Enum.TryParse < XmlSeverityType > ("Error", out var type)) {  
                    if (type == XmlSeverityType.Error) throw new InvalidXMLException(args.Message);  
                }  
            });
        }
    }
}