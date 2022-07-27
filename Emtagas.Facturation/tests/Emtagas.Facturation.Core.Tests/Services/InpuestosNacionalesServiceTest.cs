using System.Threading.Tasks;
using Emtagas.Facturacion.Common;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturacion.INServices;
using Emtagas.Facturacion.INServices.Client;
using SIN.Codigos;
using Xunit;

namespace Emtagas.Facturation.Core.Tests.Services
{
    public class InpuestosNacionalesTest
    {
        [Fact]
        public async Task GetCUISShouldReturnCorrectResponse()
        {
            long nit = 1024063020;
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJFTVRBR0FTMjAxMCIsImNvZGlnb1Npc3RlbWEiOiI3MjBGMzlFQTQ4NDMzMzM4OUI1RjkwRSIsIm5pdCI6Ikg0c0lBQUFBQUFBQUFETTBNREl4TURNMk1ESUFBR29JQ2ZZS0FBQUEiLCJpZCI6MTYzNjYsImV4cCI6MTY1OTIyNTYwMCwiaWF0IjoxNjU2NjIyMzExLCJuaXREZWxlZ2FkbyI6MTAyNDA2MzAyMCwic3Vic2lzdGVtYSI6IlNGRSJ9.hPa-0jto2Tds0goIydYARGrRsuRl7LmCSupIUb56bQniafWDODl72_IiW1WUHc21mn3Df-_mU4uEFPfBP3B_SA";

            var codigoServiceClient = FacturacionServiceClientFactory.CreateCodigoClient(new Configuration()
            {
                ApiToken = token
            });

            var response = await codigoServiceClient.cuisAsync(new solicitudCuis
            {
                nit = nit,
                codigoAmbiente = Constants.AmbienteDesarrollo,
                codigoModalidad = Constants.ModalidadElectronica,
                codigoSucursal = 1,
                codigoSistema = "720F39EA484333389B5F90E",
                codigoPuntoVentaSpecified = false
            });
            
            Assert.True(response.RespuestaCuis.transaccion);
        }    
    }
}