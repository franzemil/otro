using System.Drawing;
using System.Threading.Tasks;
using Emtagas.Facturacion.Core;
using Quartz;

namespace Emtagas.Facturacion.Scheduler.Jobs
{
    public class InicioSistemaJob : IJob
    {
        private readonly FacturacionFacade _application;

        public InicioSistemaJob(FacturacionFacade application)
        {
            _application = application;
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}