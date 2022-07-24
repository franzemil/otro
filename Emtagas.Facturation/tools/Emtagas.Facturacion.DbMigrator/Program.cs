using System;
using System.Reflection;
using Emtagas.Facturacion.DbMigrator.Scripts;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Emtagas.Facturacion.DbMigrator
{
    static class Program
    {
        static void Main(string[] args)
        {
            var dbUri = Environment.GetEnvironmentVariable("DB_URI");
            
            if (args.Length > 2)
            {
                dbUri = args[1];
            }
            
            var serviceProvider = CreateServiceProvider(dbUri);

            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        private static IServiceProvider CreateServiceProvider(string dbUri)
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    //.WithGlobalConnectionString(dbUri)
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}