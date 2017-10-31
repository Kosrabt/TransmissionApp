using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using TransmissionApp.Api.Client;

namespace TransmissionApp.Web
{
    public class ApiClient
    {
        AppConfig config;
        public ApiClient(IOptions<AppConfig> configAncestor)
        {
            config = configAncestor.Value;
        }

        public ITransmissionApp GetApiClient()
        {
            return new Api.Client.TransmissionApp()
            {
                BaseUri = new Uri(config.ApiUrl)
            };
        }
    }
}
