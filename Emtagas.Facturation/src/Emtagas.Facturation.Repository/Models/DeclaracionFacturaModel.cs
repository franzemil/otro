using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.ValueObjects;
using Newtonsoft.Json;

namespace Emtagas.Facturation.Repository.Models
{
    [Table("FaDeclaracionFactura")]
    public class DeclaracionFacturaModel
    {
        public Guid Id { get; set; }

        public int FacturaId { get; set; }

        public string CUFD { get; set; }
         
        public string CUF { get; set; }

        public byte[] File { get; set; }

        public string Hash { get; set; }

        public DateTime FechaDeclaracion { get; set; }

        public bool Success { get; set; }
        
        public string Detalle { get; set; }


        public DeclaracionFacturaModel()
        {
        }


        public static DeclaracionFacturaModel FromModel(DeclaracionFactura declaracionFactura)
        {
            return new DeclaracionFacturaModel()
            {
                Id = declaracionFactura.Id,
                FacturaId = declaracionFactura.FacturaId,
                File = declaracionFactura.File,
                Hash = declaracionFactura.Hash,
                CUF = declaracionFactura.CUF,
                CUFD = declaracionFactura.CUFD,
                FechaDeclaracion = declaracionFactura.FechaDeclaracion,
                Success = declaracionFactura.Success,
                Detalle = JsonConvert.SerializeObject(declaracionFactura.Detalle)
            };
        }

        public DeclaracionFactura ToModel()
        {
            return new DeclaracionFactura()
            {

                Id = Id,
                FacturaId = FacturaId,
                File = File,
                CUF = CUF,
                CUFD = CUFD,
                Hash = Hash,
                FechaDeclaracion = FechaDeclaracion,
                Success = Success,
                Detalle = JsonConvert.DeserializeObject<List<DeclaracionResponse>>(Detalle)
            };
        }
    }
}