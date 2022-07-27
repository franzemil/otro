using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Text;
using Emtagas.Facturacion.Common;
using Emtagas.Facturacion.Core.Config;

namespace Emtagas.Facturacion.Core.Services
{
    public class CodigoGenerator
    {
        private readonly Configuration _configuration;

        public CodigoGenerator(Configuration configuration)
        {
            _configuration = configuration;
        }

        public string GetCuf(string cufd, DateTime fecha, int numeroFactura)
        {
            var cuf = _configuration.Nit.ToString("D13");
            cuf += fecha.ToString("yyyyMMddHHmmssfff");
            cuf += Constants.CasaMatriz.ToString("D4");
            cuf += _configuration.Modalidad.ToString();
            cuf += Constants.TipoEmisionOnline.ToString();
            cuf += Constants.FacturaConDerechoACreditoFiscal.ToString();
            cuf += Constants.DocumentoSectorServicioBasico.ToString("D2");
            cuf += numeroFactura.ToString("D10");
            cuf +=  "0000";

            var modulo11 = BigInteger.Parse(cuf) % 11;

            cuf += modulo11.ToString("D1");

            return BigInteger.Parse(cuf).ToString("x") + cufd;
        }
        
        
        private static string ToHexString(string str)
        {
            return string.Join("", str.Select(c => $"{Convert.ToInt32(c):X2}"));
        }
    }
}