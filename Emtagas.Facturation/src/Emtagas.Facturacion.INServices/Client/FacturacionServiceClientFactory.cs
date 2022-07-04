using System;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Threading;
using System.Threading.Tasks;
using Emtagas.Facturacion.Core.Config;
using SIN.Codigos;
using SIN.FacturacionServiciosBasicos;
using SIN.RecepcionCompras;
using SIN.Sincronizacion;
using ServicioFacturacionClient = SIN.FacturacionServiciosBasicos.ServicioFacturacionClient;

namespace Emtagas.Facturacion.INServices.Client
{
    public class CustomCorrelationDelegatingHandler : DelegatingHandler
    {
        private readonly string _apiKeyHeader;
        private const string API_KEY_HEADER = "apiKey";
        
        public CustomCorrelationDelegatingHandler(HttpClientHandler handler, string apiKeyHeader)
        {
            _apiKeyHeader = apiKeyHeader;
            InnerHandler = handler;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = $"TokenApi {_apiKeyHeader}";
            request.Headers.Add(API_KEY_HEADER, token);
            return base.SendAsync(request, cancellationToken);
        }
    }

    public class CorrelationEndpointBehavior : IEndpointBehavior
    {
        private readonly string _apiKeyHeader;

        public CorrelationEndpointBehavior(string apiKeyHeader)
        {
            _apiKeyHeader = apiKeyHeader;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            bindingParameters.Add(new Func<HttpClientHandler, HttpMessageHandler>(x => new CustomCorrelationDelegatingHandler(x, _apiKeyHeader)));
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }

    public class FacturacionServiceClientFactory
    {
        public static ServicioFacturacionCodigosClient CreateCodigoClient(Configuration configuration)
        {
            var codigoServiceClient = new ServicioFacturacionCodigosClient();
            
            codigoServiceClient.Endpoint.EndpointBehaviors.Add(new CorrelationEndpointBehavior(configuration.ApiToken));

            return codigoServiceClient;
        }

        public static ServicioFacturacionSincronizacionClient CreateSincronizacionClient(Configuration configuration)
        {
            var serviceClient = new ServicioFacturacionSincronizacionClient();
            
            serviceClient.Endpoint.EndpointBehaviors.Add(new CorrelationEndpointBehavior(configuration.ApiToken));

            return serviceClient;
        }


        public static ServicioFacturacionClient CreateServicioFacturacionClient(Configuration configuration)
        {
            var serviceClient = new ServicioFacturacionClient();
            
            serviceClient.Endpoint.EndpointBehaviors.Add(new CorrelationEndpointBehavior(configuration.ApiToken));

            return serviceClient;
        }
     
    }
}