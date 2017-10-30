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
    [Route("api/Jobs/{jobid}/[controller]")]
    public class RulesController : Controller
    {
        // GET: api/values
        NeedABetterNameConfigurator configurator;
        IMapper mapper;

        public RulesController(IMapper mapper, NeedABetterNameConfigurator configurator)
        {
            this.configurator = configurator;
            this.mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<RuleOutModel>))]
        public IActionResult Get(string jobId)
        {
            var clientConfiguration = configurator.GetClientConfiguration();
            var job = configurator.GetJob(jobId);
            var rules = mapper.Map<IEnumerable<RuleOutModel>>(job.Rules);
            return Ok(rules);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(RuleOutModel))]
        public IActionResult GetById(string jobId, string id)
        {
            var rule = configurator.GetRule(jobId, id);
            return Ok(mapper.Map<RuleOutModel>(rule));
        }

        // PUT api/values/5
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(RuleOutModel))]
        public IActionResult Post(string jobId, [FromBody]RuleInModel value)
        {

            if (!String.IsNullOrEmpty(value.Id))
                return BadRequest("You cannot provide Id with post");

            if (String.IsNullOrEmpty(value.Path))
                return BadRequest("You have to provide a download path");

            if (String.IsNullOrEmpty(value.Regex))
                return BadRequest("You have to provide a regex");

            RuleConfiguration newRule = new RuleConfiguration
            {
                Regex = value.Regex,
                Priority = value.Priority,
                Path = value.Path
            };
            configurator.SetRule(jobId, newRule);

            return Created(Url.Action("Get", new { jobId = jobId, id = newRule.Id }), mapper.Map<RuleOutModel>(newRule));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(RuleOutModel))]
        public IActionResult Put(string jobId, string id, [FromBody]RuleInModel value)
        {

            if (String.IsNullOrEmpty(value.Id))
                return BadRequest("You have to provide Id with put");

            if (String.IsNullOrEmpty(value.Path))
                return BadRequest("You have to provide a download path");

            if (String.IsNullOrEmpty(value.Regex))
                return BadRequest("You have to provide a regex");

            var rule = configurator.GetRule(jobId, id);
            rule.Regex = value.Regex;
            rule.Priority = value.Priority;
            rule.Path = value.Path;

            configurator.SetRule(jobId, rule);

            return Ok(mapper.Map<RuleOutModel>(rule));

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        public IActionResult Delete(string jobId, string id)
        {
            configurator.DeleteRule(jobId, id);
            return Ok();
        }
    }
}
