
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransmissionApp.Business.Logic.Configuration.Models;


namespace TransmissionApp.Business.Logic
{
    public static class IServiceCollectionExtension
    {
        public static void AddTransmissionApp(this IServiceCollection services, IConfiguration Configuration)
        {

            services.Configure<AppConfiguration>(Configuration.GetSection("Rss"));
            services.AddScoped<NeedABetterNameConfigurator>();
            services.AddScoped<NeedABetterNameExecutor>();
        }
    }
}
