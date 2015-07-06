using Spring.Http;
using Spring.Http.Client;
using Spring.Http.Converters.Json;
using Spring.Rest.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace TadManagementTool.Service
{
    public abstract class AbstractService
    {
        private const int DefaultRequestTimeoutInMilliseconds = 1000;

        protected readonly RestTemplate restTemplate;

        public AbstractService()
        {
            this.restTemplate = new RestTemplate(ConfigurationManager.AppSettings["tad.server"]);
            this.restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            this.restTemplate.ErrorHandler = new CustomResponseErrorHandler();
            this.restTemplate.RequestFactory = new CustomClientHttpRequestFactory(DefaultRequestTimeoutInMilliseconds);
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
