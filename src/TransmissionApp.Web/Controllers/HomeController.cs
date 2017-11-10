using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TransmissionApp.Web.Models;
using System.Threading.Tasks;
using System.Linq;
using TransmissionApp.Web.ViewModels;
using TransmissionApp.Api.Client;
using Microsoft.Extensions.Configuration;

namespace TransmissionApp.Web.Controllers
{
    public class HomeController : Controller
    {
        ApiClient apiClient;
        IConfiguration config;

        public HomeController(IConfiguration config, ApiClient apiClient)
        {
            this.apiClient = apiClient;
            this.config = config;
        }

        public IActionResult Index()
        {
            ViewData["ApiUrl"] = config.GetValue<string>("ApiUrl");
            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}