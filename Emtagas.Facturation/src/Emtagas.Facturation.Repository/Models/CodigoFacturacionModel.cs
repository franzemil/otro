using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace Emtagas.Facturation.Repository.Models
{
    [Table("FaCodigoFacturacion")]
    public class CodigoFacturacionModel
    {
        public Guid Id { get; set; }

        public string Codigo { get; set; }

        public DateTime Fecha { get; set; }
    }
}