using System;
using Emtagas.Facturation.Core.Tests.Utils;
using Emtagas.Facturation.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Emtagas.Facturation.Core.Tests.Fixtures
{
    public class DbContextFixture : IClassFixture<ConfigurationFixture>, IDisposable
    {
        public EmtagasDbContext DbContext { get; set; }


        public DbContextFixture()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmtagasDbContext>();
            optionsBuilder.UseSqlServer(ConfigurationUtils.GetFromEnv().ConnectionString);

            DbContext = new EmtagasDbContext(optionsBuilder.Options);
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}