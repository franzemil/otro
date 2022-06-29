using System;
using Emtagas.Facturacion.Core.Entities;

namespace Emtagas.Facturacion.Core.Repositories
{
    public interface ICodigoFacturacionRepository
    {
        string GetCodeByDate(DateTime date, TipoCodigo tipoCodigo);

        string GetTodayCode(TipoCodigo tipoCodigo);

        string Save(string cuf, TipoCodigo tipoCodigo);
    }
}