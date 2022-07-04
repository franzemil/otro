using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Emtagas.Facturacion.Core.ValueObjects;

namespace Emtagas.Facturation.Repository.Models
{
    [Table("FaParametroFacturacion")]
    public class ParametroModel
    {
        public ParametroModel()
        {
        }
        
        public ParametroModel(Parametro parametro)
        {
            Description = parametro.Descripcion;
            TipoParametro = tipoParametroMap[parametro.TipoParametro];
            Codigo = parametro.Codigo;
        }

        public Guid Id { get; set; }

        public string Description { get; set; }

        public string TipoParametro { get; set; }

        public int Codigo { get; set; }


        private static readonly IDictionary<TipoParametro, string> tipoParametroMap = new Dictionary<TipoParametro, string>()
        {
            [Facturacion.Core.ValueObjects.TipoParametro.MetodoPago] = "METODO_PAGO",
            [Facturacion.Core.ValueObjects.TipoParametro.UnidadMedida] = "UNIDAD_MEDIDA",
            [Facturacion.Core.ValueObjects.TipoParametro.CodigoDocumentoSector] = "CODIGO_DOCUMENTO_SECTOR",
            [Facturacion.Core.ValueObjects.TipoParametro.TipoDocumentoIdentidad] = "TIPO_DOCUMENTO_IDENTIDAD",
            [Facturacion.Core.ValueObjects.TipoParametro.TipoMoneda] = "TIPO_MONEDA",
            [Facturacion.Core.ValueObjects.TipoParametro.CodigoProducto] = "CODIGO_PRODUCTO",
        };
        
        private static readonly IDictionary<string, TipoParametro> reverse = new Dictionary<string, TipoParametro>()
        {
            ["METODO_PAGO"] = Facturacion.Core.ValueObjects.TipoParametro.MetodoPago,
            ["UNIDAD_MEDIDA"] = Facturacion.Core.ValueObjects.TipoParametro.UnidadMedida,
            ["CODIGO_DOCUMENTO_SECTOR"] = Facturacion.Core.ValueObjects.TipoParametro.CodigoDocumentoSector,
            ["TIPO_DOCUMENTO_IDENTIDAD"] = Facturacion.Core.ValueObjects.TipoParametro.TipoDocumentoIdentidad,
            ["TIPO_MONEDA"] = Facturacion.Core.ValueObjects.TipoParametro.TipoMoneda,
            ["CODIGO_PRODUCTO"] = Facturacion.Core.ValueObjects.TipoParametro.CodigoProducto
        };

        public Parametro ToModel()
        {
            return new Parametro()
            {
                Codigo = Codigo,
                Descripcion = Description,
                TipoParametro = reverse[TipoParametro]
            };
        }
    }
}