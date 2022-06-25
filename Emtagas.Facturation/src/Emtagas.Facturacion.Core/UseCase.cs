namespace Emtagas.Facturacion.Core
{
    public interface UseCase<T>
    {
        T Execute();
    }
}