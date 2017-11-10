using System;
using TransmissionApp.Api.Client;
using Microsoft.Extensions.Configuration;

namespace TransmissionApp.Web
{
    public class ApiClient
    {
        IConfiguration configuration;
        public ApiClient(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ITransmissionApp GetApiClient()
        {
            return new Api.Client.TransmissionApp()
            {
                BaseUri = new Uri(configuration.GetValue<string>("ApiUrl"))
            };
        }
    }
}
