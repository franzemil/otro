using System.Threading.Tasks;
using Emtagas.Facturacion.Core;
using Quartz;

namespace Emtagas.Facturacion.Scheduler.Jobs
{
    public class SincronizacionFacturasJob : IJob
    {
        private readonly FacturacionFacade _application;

        public SincronizacionFacturasJob(FacturacionFacade application)
        {
            _application = application;
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}