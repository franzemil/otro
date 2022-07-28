using Emtagas.Facturacion.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturacion.Core.Repositories;
using Emtagas.Facturacion.Core.Services;
using Emtagas.Facturacion.INServices;
using Emtagas.Facturation.Repository;
using Emtagas.Facturation.Repository.Repositories;
using Emtagas.Facturation.SQLServerRepository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Emtagas.Facturacion.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = Configuration.GetEmtagasConfiguration();
            services.AddSingleton(configuration);
            services.AddDbContext<EmtagasDbContext>(options => options.UseSqlServer(configuration.ConnectionString));
            services.AddScoped<IFacturaRepository, FacturaRepository>();
            services.AddScoped<IDeclaracionFacturaRepository, DeclaracionFacturaRepository>();
            services.AddScoped<ICodigoFacturacionRepository, CodigoFacturacionRepository>();
            services.AddScoped<IInpuestosNacionalesService, ImpuestosServices>();
            services.AddScoped<IParametroRepository, ParametroRepository>();
            services.AddScoped<FacturacionFacade>();

            services.AddMvcCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                object p = endpoints.MapGet("/health", async context => await context.Response.WriteAsync("OK"));
            });
        }
    }
}
