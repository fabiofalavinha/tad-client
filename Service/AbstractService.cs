using Spring.Http;
using Spring.Http.Client;
using Spring.Http.Converters.Json;
using Spring.Rest.Client;
using System;
using System.IO;
using System.Net;

namespace TadManagementTool.Service
{
    public abstract class AbstractService
    {
        private const int DefaultRequestTimeoutInMilliseconds = 1000;

        protected readonly RestTemplate restTemplate;

        public AbstractService()
        {
#if DEBUG
            restTemplate = new RestTemplate("http://localhost:7139");
#else
            restTemplate = new RestTemplate(System.Configuration.ConfigurationManager.AppSettings["tad.server"]);
#endif
            restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            restTemplate.ErrorHandler = new CustomResponseErrorHandler();
        }

        private class CustomResponseErrorHandler : IResponseErrorHandler
        {
            public void HandleError(Uri requestUri, HttpMethod requestMethod, IClientHttpResponse response)
            {
                using (var reader = new StreamReader(response.Body))
                {
                    throw new Exception(reader.ReadToEnd());
                }
            }

            public bool HasError(Uri requestUri, HttpMethod requestMethod, IClientHttpResponse response)
            {
                return response.StatusCode != HttpStatusCode.OK;
            }
        }

        private class CustomClientHttpRequestFactory : WebClientHttpRequestFactory
        {
            public CustomClientHttpRequestFactory(int timeout)
            {
                Timeout = timeout;
            }
        }
    }
}
