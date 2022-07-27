using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Emtagas.Facturacion.Core.Services
{
    public class DigitalSignature
    {
        public DigitalSignature()
        {
        }

        private static string Read(string filePath)
        {
            using (var privateKeyTextReader = new StringReader(File.ReadAllText(filePath)))
            {
                return privateKeyTextReader.ReadToEnd();
            }
        }
        
        public string Sign(string documentToSign, string pathCertificate, string pathPrivateKey)
        {
            var rsa = RSA.Create();
            rsa.ImportFromPem(Read(pathPrivateKey));
            
            var cert = X509Certificate.CreateFromCertFile(pathCertificate);

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(documentToSign);

            var signedXml = new SignedXml(xmlDocument.DocumentElement)
            {
                SigningKey = rsa,
                SignedInfo =
                {
                    SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256",
                    CanonicalizationMethod = "http://www.w3.org/2001/10/xml-exc-c14n#"
                },
                KeyInfo = new KeyInfo()
            };

            signedXml.KeyInfo.AddClause(new KeyInfoX509Data(cert, X509IncludeOption.WholeChain));

            var reference = new Reference {Uri = string.Empty}; 
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new XmlDsigExcC14NTransform());
            signedXml.AddReference(reference);
            
            signedXml.ComputeSignature();

            signedXml.GetXml();
            
            if (xmlDocument.DocumentElement != null) 
                xmlDocument.DocumentElement.AppendChild(signedXml.GetXml());

            using (var sw = new StringWriter())
            {
                using (var tx = new XmlTextWriter(sw))
                {
                    xmlDocument.WriteTo(tx);
                    string strXmlText = sw.ToString();
                    return strXmlText;
                }
            }
        }
    }
}