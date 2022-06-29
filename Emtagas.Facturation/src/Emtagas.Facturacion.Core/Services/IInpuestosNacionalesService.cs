using System.Collections.Generic;
using System.Threading.Tasks;
using Emtagas.Facturacion.Core.ValueObjects;

namespace Emtagas.Facturacion.Core.Services
{
    public interface IInpuestosNacionalesService
    {
        Task<string> SolicitarCodigoInicioSistema();
        
        Task<string> SolicitarCodigoUnicoFacturacionDiaria();

        Task<IEnumerable<Parametro>> SincronizarParametros(string codigoUnicoInicioSistema);
    }
}
