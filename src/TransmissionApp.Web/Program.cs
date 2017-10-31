using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TransmissionApp.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHost = BuildWebHost(args);
            await webHost.RunAsync();//blocking
    
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((builderContext, config) =>
                 {
                     IHostingEnvironment env = builderContext.HostingEnvironment;

                     config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                         
                 })
                .UseStartup<Startup>()
                .Build();
    }
}
