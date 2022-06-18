namespace Emtagas.Facturacion.Core.Services
{
    public interface IInpuestosNacionalesService
    {
        string SolicitarCUFD();
        
        void SolicitudCUFDMasivo();

        void SolicitudCUIS();
        
        void SolicitudCUISMasivo();
    }
}
