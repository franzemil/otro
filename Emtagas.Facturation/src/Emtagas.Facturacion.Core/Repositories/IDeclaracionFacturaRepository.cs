using Emtagas.Facturacion.Core.Entities;

namespace Emtagas.Facturacion.Core.Repositories
{
    public interface IDeclaracionFacturaRepository
    { 
        DeclaracionFactura GetDeclaracionFacturaByFacturaIdAndCUF(int facturaId, string cuf);

        void SaveDeclaracionFactura(DeclaracionFactura declaracionFactura);
    }
}