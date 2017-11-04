using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using TransmissionApp.Api.Client.Contracts;
using TransmissionApp.Business.Logic;
using TransmissionApp.Business.Logic.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransmissionApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class ExecutionController : Controller
    {
        NeedABetterNameExecutor executor;
        NeedABetterNameConfigurator configurator;
        IMapper mapper;

        public ExecutionController(NeedABetterNameExecutor executor, NeedABetterNameConfigurator configurator, IMapper mapper)
        {
            this.executor = executor;
            this.configurator = configurator;
            this.mapper = mapper;
        }

        //// GET: api/values
        //[HttpGet]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<TestRssJobModel>))]
        //public IActionResult TestRssJob(string jobId)
        //{
        //    var job = configurator.GetJob(jobId);
        //    var resolvedRss = executor.GetItemFromRss(job);
        //    var items = mapper.Map<IEnumerable<TestRssItemModel>>(resolvedRss);
        //    return Ok(new TestRssJobModel() {JobId = jobId, Items= items });
        //}

        // GET: api/values
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int))]
        public IActionResult Execute()
        {
            executor.Execute();
            var delay = configurator.GetClientConfiguration().RefreshTime;
            return Ok(delay);
        }

    }

}
