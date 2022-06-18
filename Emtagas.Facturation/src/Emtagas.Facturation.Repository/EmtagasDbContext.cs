using Emtagas.Facturation.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Emtagas.Facturation.Repository
{
    public class EmtagasDbContext : DbContext
    {
        public DbSet<FacturaModel> Factura { get; set; }

        public EmtagasDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
