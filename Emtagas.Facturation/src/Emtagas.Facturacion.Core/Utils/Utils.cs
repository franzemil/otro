using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace Emtagas.Facturacion.Core.Utils
{
    public class Utils
    {
        public byte[] Comprimir(byte[] file)
        {
            using var stream = new MemoryStream(file);
            using (var compressor = new GZipStream(stream, CompressionMode.Compress))
            {
                compressor.Write(file, 0, file.Length);
            }

            return stream.ToArray();
        }

        public string ComputeHash256(byte[] content)
        {
            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(content);
            var builder = new StringBuilder();
                
            foreach (var t in hash)
            {
                builder.Append(t.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
