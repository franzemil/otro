using System.Collections.Generic;
using System.Threading.Tasks;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.ValueObjects;

namespace Emtagas.Facturacion.Core.Services
{
    public interface IInpuestosNacionalesService
    {
        Task<string> SolicitarCodigoInicioSistema();
        
        Task<(string, string)> SolicitarCodigoUnicoFacturacionDiaria(string codigoUnicoInicioSistema);

        Task<IEnumerable<Parametro>> SincronizarParametros(string codigoUnicoInicioSistema);

        Task<DeclaracionFactura> RecepcionarFactura(byte[] archivo, string cuis, string cufd, string hash);
    }
}
