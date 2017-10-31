using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TransmissionApp.Web.Models;
using System.Threading.Tasks;
using System.Linq;
using TransmissionApp.Web.ViewModels;
using TransmissionApp.Api.Client;

namespace TransmissionApp.Web.Controllers
{
    public class HomeController : Controller
    {
        ApiClient apiClient;

        public HomeController(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}