using Spring.Http.Converters.Json;
using Spring.Rest.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TadManagementTool.Service
{
    public abstract class AbstractService
    {
        protected readonly RestTemplate restTemplate;

        public AbstractService()
        {
            this.restTemplate = new RestTemplate(ConfigurationManager.AppSettings["tad.server"]);
            this.restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
        }
    }
}
