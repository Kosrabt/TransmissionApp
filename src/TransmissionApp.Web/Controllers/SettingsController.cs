using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransmissionApp.Api.Client;
using TransmissionApp.Web.ViewModels.Settings;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransmissionApp.Web.Controllers
{
    public class SettingsController : Controller
    {
        Func<ITransmissionApp> transmissionAppApi;
        IMapper mapper;
              

        public SettingsController(ApiClient apiClient, IMapper mapper)
        {
            this.transmissionAppApi = () => apiClient.GetApiClient();
            this.mapper = mapper;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var client = transmissionAppApi();
            var config = await client.ApiSettingsGetAsync();            
            return View(mapper.Map<IndexViewModel>(config));
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var client = transmissionAppApi();
                var config = mapper.Map<Api.Client.Models.SettingsInModel>(viewModel);
                await client.ApiSettingsPutAsync(config);
                return RedirectToAction(nameof(Index));
            }            
            return View(viewModel);
        }
    }
}
