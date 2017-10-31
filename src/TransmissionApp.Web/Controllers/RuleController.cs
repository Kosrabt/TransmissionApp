using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransmissionApp.Api.Client;
using TransmissionApp.Web.ViewModels.Rules;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransmissionApp.Web.Controllers
{
    
    public class RuleController : Controller
    {

        Func<ITransmissionApp> transmissionAppApi;
        IMapper mapper;

        public RuleController(ApiClient apiClient, IMapper mapper)
        {
            this.transmissionAppApi = () => apiClient.GetApiClient();
            this.mapper = mapper;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Edit(string jobId, string id)
        {
            RuleViewModel mapped;
            if (string.IsNullOrEmpty(id))
            {
                mapped = new RuleViewModel();        
            }
            else
            {
                var rule = await transmissionAppApi().ApiRulesByIdGetAsync(id, jobId);
                mapped = mapper.Map<RuleViewModel>(rule);               
            }
       
            mapped.JobId = jobId;
            return View(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string jobId, string id, RuleViewModel viewModel)
        {


            if (ModelState.IsValid)
            {
                var client = transmissionAppApi();
                var rule = mapper.Map<Api.Client.Models.RuleInModel>(viewModel);
                           
                if (String.IsNullOrEmpty(viewModel.Id))
                {
                    await client.ApiRulesPostAsync(jobId, rule);                   
                }
                else
                {
                    await client.ApiRulesByIdPutAsync(id, jobId, rule);       
                }
                return RedirectToAction("Edit", "Job", new { id = jobId });

            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(string jobId, string id)
        {
            var client = transmissionAppApi();
            var rule = await client.ApiRulesByIdGetAsync(id, jobId);
            var mapped = mapper.Map<RuleViewModel>(rule);
            mapped.JobId = jobId;
            return View(mapped);
        }


        [HttpPost]
        [Route("[controller]/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmation(string jobId, string id)
        {
            var client = transmissionAppApi();
            await client.ApiRulesByIdDeleteAsync(id,jobId);
            return RedirectToAction(nameof(Edit), "Job", new { id = jobId });
        }
    }
}
