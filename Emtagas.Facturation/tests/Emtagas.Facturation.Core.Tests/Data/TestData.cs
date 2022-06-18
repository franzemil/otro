using System.IO;
using System.Reflection;

namespace Emtagas.Facturation.Core.Tests.Data
{
    public class TestData
    {
        public static string GetFileContent(string fileName)
        {
            var path = Assembly.GetExecutingAssembly().Location;

            var file = Path.Join(Path.GetDirectoryName(path), "Data", fileName);
            
            return File.ReadAllText(file);
        }
    }
}