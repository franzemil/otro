using System;
using Emtagas.Facturacion.Core.Entities;

namespace Emtagas.Facturacion.Core.Repositories
{
    public interface ICUFRepository
    {
        string GetCodeByDate(DateTime date);

        string GetTodayCode();

        string SaveCUF(string cuf);
    }
}