using System;
using System.Linq;
using Emtagas.Facturacion.Core.Exceptions;
using Emtagas.Facturacion.Core.Repositories;
using Emtagas.Facturation.Repository;
using Emtagas.Facturation.Repository.Models;

namespace Emtagas.Facturation.SQLServerRepository.Repositories
{
    public class CUFRepository : ICUFRepository
    {
        private readonly EmtagasDbContext _context;

        public CUFRepository(EmtagasDbContext context)
        {
            _context = context;
        }
        
        public string GetCodeByDate(DateTime date)
        {
            var cuf = _context.CUF.FirstOrDefault(cuf => cuf.Fecha == date);

            if (cuf == null)
                throw new CUFNotFoundException();

            return cuf.Codigo;
        }

        public string GetTodayCode()
        {
            var today = DateTime.Today;

            return GetCodeByDate(today);
        }

        public string SaveCUF(string cuf)
        {
            var cufModel = new CodigoFacturacionModel
            {
                Codigo = cuf,
                Fecha = DateTime.Today
            };

            _context.Add(cufModel);
            _context.SaveChanges();

            return cufModel.Codigo;
        }
    }
}