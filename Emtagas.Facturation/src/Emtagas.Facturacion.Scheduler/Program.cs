using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Emtagas.Facturacion.Scheduler.Jobs;
using Quartz;
using Quartz.Impl;

namespace Emtagas.Facturacion.Scheduler
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            }; 
            var factory = new StdSchedulerFactory();

            var scheduler = await factory.GetScheduler();
            await scheduler.Start();
            
            var inicioSistemaJob = JobBuilder.Create<InicioSistemaJob>()
                .WithIdentity("InicioSistema", "default")
                .Build();

            var dailyTrigger = TriggerBuilder.Create()
                .WithIdentity("dailyTrigger", "default")
                .StartNow()
                // .WithCronSchedule("* * * * * ?")
                // .ForJob(inicioSistemaJob)
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(2).RepeatForever())
                .Build();


            await scheduler.ScheduleJob(inicioSistemaJob, dailyTrigger);
            Console.ReadKey();
            await scheduler.Shutdown();
        }
    }
}