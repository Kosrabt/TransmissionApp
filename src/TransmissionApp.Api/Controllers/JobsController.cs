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
        [HttpPost]
        public void Post([FromBody]JobInModel value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
