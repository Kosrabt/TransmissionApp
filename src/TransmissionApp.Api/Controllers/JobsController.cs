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
using TransmissionApp.Business.Logic.Configuration.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransmissionApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class JobsController : Controller
    {

        NeedABetterNameConfigurator configurator;
        IMapper mapper;

        public JobsController(IMapper mapper, NeedABetterNameConfigurator configurator)
        {
            this.configurator = configurator;
            this.mapper = mapper;
        }

        // GET: api/values       
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<JobOutModel>))]
        public IActionResult Get()
        {
            var clientConfiguration = configurator.GetClientConfiguration();
            var jobs = mapper.Map<IEnumerable<JobOutModel>>(clientConfiguration.Jobs);
            return Ok(jobs);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(JobOutModel))]
        public IActionResult Get(string id)
        {
            var job = configurator.GetJob(id);
            return Ok(mapper.Map<JobOutModel>(job));
        }

        // POST api/values
        // Create new
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(JobOutModel))]
        public IActionResult Post([FromBody]JobInModel value)
        {
            if (!String.IsNullOrEmpty(value.Id))
                return BadRequest("You cannot provide Id with post");

            if (String.IsNullOrEmpty(value.DownloadPath))
                return BadRequest("You have to provide a download path");

            if (String.IsNullOrEmpty(value.Name))
                return BadRequest("You have to provide a Name");

            if (String.IsNullOrEmpty(value.RssUrl))
                return BadRequest("You have to provide an Rss url");

            JobConfiguration job = new JobConfiguration()
            {
                Name = value.Name,
                DownloadPath = value.DownloadPath,
                RssUrl = value.RssUrl

            };
            configurator.SetJob(job);
            return Created(Url.Action("Get", new { id = job.Id }), job);
        }

        // PUT api/values/5
        // Update
        [HttpPut("{id}")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(JobOutModel))]
        public IActionResult Put(string id, [FromBody] JobInModel value)
        {
            if (String.IsNullOrEmpty(value.Id))
                return BadRequest("You have to provide Id with put");

            if (id != value.Id)
                return BadRequest("The id not match with the item id");

            if (String.IsNullOrEmpty(value.DownloadPath))
                return BadRequest("You have to provide a download path");

            if (String.IsNullOrEmpty(value.Name))
                return BadRequest("You have to provide a Name");

            if (String.IsNullOrEmpty(value.RssUrl))
                return BadRequest("You have to provide an Rss url");

            JobConfiguration job = configurator.GetJob(value.Id);
            job.Name = value.Name;
            job.DownloadPath = value.DownloadPath;
            job.RssUrl = value.RssUrl;
            configurator.SetJob(job);
            return Ok(job);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        public IActionResult Delete(string id)
        {
            configurator.DeleteJob(id);
            return Ok();
        }
    }
}
