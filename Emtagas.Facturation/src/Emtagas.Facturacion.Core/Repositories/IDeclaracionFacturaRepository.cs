using Emtagas.Facturacion.Core.Entities;

namespace Emtagas.Facturacion.Core.Repositories
{
    public interface IDeclaracionFacturaRepository
    { 
        DeclaracionFactura GetDeclaracionFacturaByFacturaId(int facturaId);

        void SaveDeclaracionFactura(DeclaracionFactura declaracionFactura);
        
        void ActualizarDeclaracion(DeclaracionFactura declaracionFactura);
    }
}