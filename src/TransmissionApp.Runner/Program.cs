using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransmissionApp.Api.Client;

namespace TransmissionApp.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiLink = Environment.GetEnvironmentVariable("ApiUrl");

            if (string.IsNullOrWhiteSpace(apiLink))
            {
                throw new Exception("Missing Api Url");
            }

            var cancellationTokenSource = new CancellationTokenSource();
            try
            {
                Run(cancellationTokenSource.Token, apiLink).Wait();
            }
            catch (Exception)
            {

            }
        }

        public static async Task Run(CancellationToken ct, string apiUrl)
        {
            var delay = 0;
            while (!ct.IsCancellationRequested)
            {
                using (var apiClient = GetApiClient(apiUrl))
                {
                    delay = await apiClient.ApiExecutionGetAsync() ?? 360;
                    AddConsoleMessage($"Api Request called. Delay: {delay*1000}");
                }
                await Task.Delay(delay * 1000);
            }
        }

        private static ITransmissionApp GetApiClient(string url)
        {
            return new Api.Client.TransmissionApp()
            {
                BaseUri = new Uri(url)
            };
        }

        private static void AddConsoleMessage(string message)
        {            
            Console.WriteLine($"{DateTime.Now.ToShortTimeString()}: {message}");
        }
    }
}
