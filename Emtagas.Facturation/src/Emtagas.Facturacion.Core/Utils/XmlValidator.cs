using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Emtagas.Facturacion.Core.Exceptions;

namespace Emtagas.Facturacion.Core.Validator
{
    public class XmlValidator
    {

        public void IsValid(string xml)
        {
            var schema = new XmlSchemaSet();
            schema.Add("namespace", "./validatio.xds");

            var doc = new XmlDocument();
            
            doc.Load(xml);
            doc.Schemas.Add(schema);
            
            doc.Validate(((sender, args) => throw new InvalidXMLException()));
        }
    }
}