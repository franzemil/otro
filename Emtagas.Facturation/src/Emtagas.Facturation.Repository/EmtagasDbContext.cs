using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturation.Repository.Models;
using Emtagas.Facturation.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Emtagas.Facturation.Repository
{
    public class EmtagasDbContext : DbContext
    {
        public DbSet<FacturaModel> Factura { get; set; }

        public DbSet<CodigoFacturacionModel> CodigosFacturacion { get; set; }
        
        
        public DbSet<DeclaracionFacturaModel> FacturasDeclaradas { get; set; }

        public DbSet<ParametroModel> Parametros { get; set; }

        public EmtagasDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
