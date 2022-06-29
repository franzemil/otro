using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturacion.Core.Repositories;
using Emtagas.Facturation.Repository;
using Emtagas.Facturation.Repository.Repositories;
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
            var dbUri = Configuration.GetValue<string>("DB_URI");
            services.AddDbContext<EmtagasDbContext>(options => options.UseSqlServer(dbUri));
            services.AddScoped<IFacturaRepository>(sp =>
            {
                var dbContext = sp.GetService<EmtagasDbContext>();
                var repository = new FacturaRepository(dbContext);
                return repository;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                object p = endpoints.MapGet("/health", async context => await context.Response.WriteAsync("OK"));
            });
        }
    }
}
