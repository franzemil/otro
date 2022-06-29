using System.Collections.Generic;
using System.Threading.Tasks;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturacion.Core.Services;
using Emtagas.Facturacion.Core.ValueObjects;
using Emtagas.Facturacion.INServices.Client;
using SIN.Codigos;

namespace Emtagas.Facturacion.INServices
{
    public class ImpuestosServices: IInpuestosNacionalesService
    {
        private readonly Configuration _configuration;

        public ImpuestosServices(Configuration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<string> SolicitarCodigoInicioSistema()
        {
            var client = FacturacionServiceClientFactory.CreateCodigoClient(_configuration);
            var response = await client.cuisAsync(new solicitudCuis
            {
                nit = _configuration.Nit,
                codigoAmbiente = ImpuestosConstants.AmbienteDesarrollo,
                codigoModalidad = ImpuestosConstants.ModalidadElectronica,
                codigoSistema = _configuration.CodigoSistema,
                codigoSucursal = ImpuestosConstants.CasaMatriz,
                codigoPuntoVentaSpecified = false
            });
            
            return response.RespuestaCuis.codigo;
        }

        public Task<IEnumerable<Parametro>> SincronizarParametros()
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> SolicitarCodigoUnicoFacturacionDiaria()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Parametro>> SincronizarParametros(string codigoUnicoInicioSistema)
        {
            throw new System.NotImplementedException();
        }
    }
}