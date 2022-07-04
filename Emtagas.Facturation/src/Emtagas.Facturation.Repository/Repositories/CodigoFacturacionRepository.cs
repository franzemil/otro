using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Emtagas.Facturacion.Core.Exceptions;
using Emtagas.Facturacion.Core.Repositories;
using Emtagas.Facturation.Repository;
using Emtagas.Facturation.Repository.Models;

namespace Emtagas.Facturation.SQLServerRepository.Repositories
{
    public class CodigoFacturacionRepository : ICodigoFacturacionRepository
    {
        private readonly EmtagasDbContext _context;
        private readonly IDictionary<TipoCodigo, string> _tipoCodigoMap = new Dictionary<TipoCodigo, string>
            {
                [TipoCodigo.CUFD] = "CUFD",
                [TipoCodigo.CUIS] = "CUIS",
                [TipoCodigo.CUFD_CONTROL] = "CUFD_CONTROL",
            };

        public CodigoFacturacionRepository(EmtagasDbContext context)
        {
            _context = context;
        }
        
        public string GetCodeByDate(DateTime date, TipoCodigo tipoCodigo)
        {
            var cuf = _context.CodigosFacturacion.FirstOrDefault(cuf => 
                cuf.Fecha == date && cuf.TipoCodigo.Equals(_tipoCodigoMap[tipoCodigo])
                );

            if (cuf == null)
                throw new CodigoNotFoundException();

            return cuf.Codigo;
        }

        public string GetTodayCode(TipoCodigo tipoCodigo)
        {
            var today = DateTime.Today;

            return GetCodeByDate(today, tipoCodigo);
        }

        public string Save(string cuf, TipoCodigo tipoCodigo)
        {
            var cufModel = new CodigoFacturacionModel
            {
                Codigo = cuf,
                Fecha = DateTime.Today,
                TipoCodigo = _tipoCodigoMap[tipoCodigo]
            };

            _context.Add(cufModel);
            _context.SaveChanges();

            return cufModel.Codigo;
        }
    }
}