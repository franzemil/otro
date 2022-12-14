using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.Repositories;
using Emtagas.Facturation.Repository;
using Emtagas.Facturation.Repository.Models;

namespace Emtagas.Facturation.SQLServerRepository.Repositories
{
    public class DeclaracionFacturaRepository : IDeclaracionFacturaRepository
    {
        private readonly EmtagasDbContext _dbContext;

        public DeclaracionFacturaRepository(EmtagasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DeclaracionFactura GetDeclaracionFacturaByFacturaId(int facturaId)
        {
            throw new System.NotImplementedException();
        }

        public void SaveDeclaracionFactura(DeclaracionFactura declaracionFactura)
        {
            var model = DeclaracionFacturaModel.FromModel(declaracionFactura);
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }

        public void ActualizarDeclaracion(DeclaracionFactura declaracionFactura)
        {
            _dbContext.Update(declaracionFactura);
            _dbContext.SaveChanges();
        }
    }
}