using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Emtagas.Facturacion.Common;
using Emtagas.Facturacion.Core.Config;
using Emtagas.Facturacion.Core.Entities;
using Emtagas.Facturacion.Core.Exceptions;
using Emtagas.Facturacion.Core.Services;
using Emtagas.Facturacion.Core.ValueObjects;
using Emtagas.Facturacion.INServices.Client;
using Microsoft.Extensions.Logging;
using SIN.Codigos;
using SIN.FacturacionServiciosBasicos;
using SIN.RecepcionCompras;
using SIN.Sincronizacion;

namespace Emtagas.Facturacion.INServices
{
    public class ImpuestosServices: IInpuestosNacionalesService
    {
        private readonly Configuration _configuration;
        private readonly ILogger<ImpuestosServices> _logger;

        public ImpuestosServices(Configuration configuration, ILogger<ImpuestosServices> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        
        public async Task<string> SolicitarCodigoInicioSistema()
        {
            var client = FacturacionServiceClientFactory.CreateCodigoClient(_configuration);
            var response = await client.cuisAsync(new solicitudCuis
            {
                nit = _configuration.Nit,
                codigoAmbiente = _configuration.Ambiente,
                codigoModalidad = _configuration.Modalidad,
                codigoSistema = _configuration.CodigoSistema,
                codigoSucursal = Constants.CasaMatriz,
                codigoPuntoVentaSpecified = false
            });
            
            return response.RespuestaCuis.codigo;
        }

        public async Task<IEnumerable<Parametro>> SincronizarParametros(string codigoUnicoInicioSistema)
        {
            var codigos = new List<Parametro>();
            
            var client = FacturacionServiceClientFactory.CreateSincronizacionClient(_configuration);

            var solicitudParams = new solicitudSincronizacion()
            {
                cuis = codigoUnicoInicioSistema,
                nit = _configuration.Nit,
                codigoAmbiente = _configuration.Ambiente,
                codigoSistema = _configuration.CodigoSistema,
                codigoSucursal = Constants.CasaMatriz,
                codigoPuntoVentaSpecified = false
            };

            var tipoMoneda = await client.sincronizarParametricaTipoMonedaAsync(solicitudParams);
            codigos.AddRange(FormatParametros(tipoMoneda.RespuestaListaParametricas, TipoParametro.TipoMoneda));

            var tipoDocumentoIdentidad = await client.sincronizarParametricaTipoDocumentoIdentidadAsync(solicitudParams);
            codigos.AddRange(FormatParametros(tipoDocumentoIdentidad.RespuestaListaParametricas, TipoParametro.TipoDocumentoIdentidad));

            var metodoPago = await client.sincronizarParametricaTipoMetodoPagoAsync(solicitudParams);
            codigos.AddRange(FormatParametros(metodoPago.RespuestaListaParametricas, TipoParametro.MetodoPago));

            var unidadMedida = await client.sincronizarParametricaUnidadMedidaAsync(solicitudParams);
            codigos.AddRange(FormatParametros(unidadMedida.RespuestaListaParametricas, TipoParametro.UnidadMedida));
            
            var codigoProducto = await client.sincronizarListaProductosServiciosAsync(solicitudParams);
            codigos.AddRange(FormatParametros(codigoProducto.RespuestaListaProductos, TipoParametro.CodigoProducto));
            
            return codigos;
        }

        public async Task<DeclaracionFactura> RecepcionarFactura(byte[] factura, string cuis, string cufd, string hash)
        {
            var client = FacturacionServiceClientFactory.CreateServicioFacturacionClient(_configuration);

            var response = await client.recepcionFacturaAsync(new solicitudRecepcionFactura()
            {
                nit = _configuration.Nit,
                archivo = factura,
                cufd = cufd,
                cuis = cuis,
                hashArchivo = hash,
                codigoAmbiente = _configuration.Ambiente,
                codigoEmision = 1,
                codigoDocumentoSector = Constants.DocumentoSectorServicioBasico,
                codigoModalidad = Constants.ModalidadComputarizada,
                codigoSistema = _configuration.CodigoSistema,
                codigoSucursal = Constants.CasaMatriz,
                fechaEnvio = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff"),
                tipoFacturaDocumento = 1,
                codigoPuntoVentaSpecified = false
            });

            // if (!response.RespuestaServicioFacturacion.transaccion)
            // {
            //     
            // }
            //
            // if (response.RespuestaServicioFacturacion.codigoDescripcion != "RECHAZADO" && response.RespuestaServicioFacturacion.mensajesList.First().codigo != 995)
            // {
            //     Console.WriteLine("g");
            // }
            // }

            return new DeclaracionFactura();
        }

        private IEnumerable<Parametro> FormatParametros(respuestaListaProductos codigoProductoRespuestaListaProductos, TipoParametro codigoProducto)
        {
            var codigos = codigoProductoRespuestaListaProductos.listaCodigos.Select(p =>
                $"{p.codigoActividad},{p.codigoProducto},{p.descripcionProducto},{p.codigoProductoSpecified}");
            File.WriteAllText("/tmp/codigos.csv", string.Join("\n", codigos));
            return new List<Parametro>();
        }

        private IEnumerable<Parametro> FormatParametros(respuestaListaParametricas parametricas, TipoParametro tipoParametro)
        {
            if (!parametricas.transaccion)
            {
                foreach (var codigo in parametricas.listaCodigos)
                {
                    _logger.LogError($"Error loading the parameteres with code: {codigo.codigoClasificador} and Description: {codigo.descripcion}");
                }
                throw new INServiceException(parametricas.mensajesList.Select(m => $"Codigo: {(m.codigoSpecified ? m.codigo : string.Empty)} - Description: ${m.descripcion}"));
            }
            
            return parametricas.listaCodigos.Select(dto => new Parametro()
            {
                Codigo = dto.codigoClasificador,
                Descripcion = dto.descripcion,
                TipoParametro = tipoParametro
            });
        }

        public async Task<(string, string)> SolicitarCodigoUnicoFacturacionDiaria(string codigoUnicoInicioSistema)
        {
            
            var client = FacturacionServiceClientFactory.CreateCodigoClient(_configuration);

            var response = await client.cufdAsync(new solicitudCufd()
            {
                cuis = codigoUnicoInicioSistema,
                nit = _configuration.Nit,
                codigoAmbiente = _configuration.Ambiente,
                codigoModalidad = Constants.ModalidadComputarizada,
                codigoSistema = _configuration.CodigoSistema,
                codigoSucursal = Constants.CasaMatriz,
                codigoPuntoVentaSpecified = false
            });

            if (!response.RespuestaCufd.transaccion)
            {
                throw new INServiceException(response.RespuestaCufd.mensajesList.Select(m => $"Code: {(m.codigoSpecified ? m.codigo : "NA")} - Description: {m.descripcion}"));
            }

            return (response.RespuestaCufd.codigo, response.RespuestaCufd.codigoControl);
        }
    }
}