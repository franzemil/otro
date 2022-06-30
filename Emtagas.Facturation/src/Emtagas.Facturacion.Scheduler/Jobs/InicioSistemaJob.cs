using System;
using System.Drawing;
using System.Threading.Tasks;
using Emtagas.Facturacion.Core;
using Quartz;

namespace Emtagas.Facturacion.Scheduler.Jobs
{
    public class InicioSistemaJob : IJob
    {
        private readonly FacturacionFacade _application;

        public InicioSistemaJob()
        {
        }
        
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Gaaaa");
            await Task.CompletedTask;
        }
    }
}