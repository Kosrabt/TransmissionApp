using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransmissionApp.Api.Client;
using TransmissionApp.Web.Controllers;
using TransmissionApp.Web.ViewModels;
using TransmissionApp.Web.ViewModels.Jobs;

namespace TransmissionApp.Web
{
    public class JobController : Controller
    {
        Func<ITransmissionApp> transmissionAppApi;
        IMapper mapper;

        public JobController(ApiClient apiClient, IMapper mapper)
        {
            this.transmissionAppApi =() => apiClient.GetApiClient();
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = transmissionAppApi();
            var jobs = await client.ApiJobsGetAsync();
            return View(mapper.Map<IEnumerable<JobViewModel>>(jobs));
        }
        
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var newJob = new JobViewModel();     
                return View(newJob);
            }

            var client = transmissionAppApi();
            var job =await client.ApiJobsByIdGetAsync(id);
            return View(mapper.Map<JobViewModel>(job));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JobViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var client = transmissionAppApi();
                var job = mapper.Map<Api.Client.Models.JobInModel>(viewModel);
                if (String.IsNullOrEmpty(viewModel.Id))
                {
                    var newJob = await client.ApiJobsPostAsync(job);
                    return RedirectToAction(nameof(Edit), new { id= newJob.Id });
                }
                else
                {
                    await client.ApiJobsByIdPutAsync(viewModel.Id, job);
                    return RedirectToAction(nameof(Index));
                }               
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var client = transmissionAppApi();
            var job = await client.ApiJobsByIdGetAsync(id);
            return View(mapper.Map<JobViewModel>(job));
        }


        [HttpPost]
        [Route("[controller]/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmation(string id)
        {
            var client = transmissionAppApi();
            await client.ApiJobsByIdDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }   
        
    }
}