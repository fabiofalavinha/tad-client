using Spring.Http;
using Spring.Http.Client;
using Spring.Http.Client.Interceptor;
using Spring.Http.Converters.Json;
using Spring.Rest.Client;
using System;
using System.IO;
using System.Net;

namespace TadManagementTool.Service
{
    public abstract class AbstractService
    {
        private class CustomClientHttpRequestFactory : WebClientHttpRequestFactory
        {
            public CustomClientHttpRequestFactory(int timeout)
            {
                Timeout = timeout;
            }
        }

        private class ApplicationClientVersionRequestHeaderInterceptor : IClientHttpRequestBeforeInterceptor
        {
            private static readonly string TadClientVersionHeaderKey = "X-TAD-Client-Version";

            public void BeforeExecute(IClientHttpRequestContext request)
            {
                request.Headers.Add(TadClientVersionHeaderKey, ApplicationVersion.Version);
            }
        }

        private const int DefaultRequestTimeoutInMilliseconds = 60000;

        protected readonly RestTemplate restTemplate;

        public AbstractService()
        {
#if DEBUG
            //restTemplate = new RestTemplate("http://localhost:7139");
            restTemplate = new RestTemplate(System.Configuration.ConfigurationManager.AppSettings["tad.server"]);
#else
            restTemplate = new RestTemplate(System.Configuration.ConfigurationManager.AppSettings["tad.server"]);
#endif
            restTemplate.RequestFactory = new CustomClientHttpRequestFactory(DefaultRequestTimeoutInMilliseconds);
            restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            restTemplate.ErrorHandler = new CustomResponseErrorHandler();
            restTemplate.RequestInterceptors.Clear();
            restTemplate.RequestInterceptors.Add(new ApplicationClientVersionRequestHeaderInterceptor());
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
    }
}
