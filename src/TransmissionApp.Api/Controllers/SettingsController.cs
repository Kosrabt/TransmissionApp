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
    public class SettingsController : Controller
    {
        NeedABetterNameConfigurator configurator;
        IMapper mapper; 

        public SettingsController(IMapper mapper,NeedABetterNameConfigurator configurator)
        {
            this.configurator = configurator;
            this.mapper = mapper;
        }

        // GET api/settings/
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(SettingsOutModel))]
        public IActionResult Get()
        {
            var clientConfiguration = configurator.GetClientConfiguration();
            var settings = mapper.Map<SettingsOutModel>(clientConfiguration);
            return Ok(settings);
        }



        // Put api/values
        [HttpPut]
        [SwaggerResponse(200)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        public IActionResult Put([FromBody]SettingsInModel value)
        {
            if (String.IsNullOrEmpty(value.TransmissionUrl))
                return BadRequest("You have to provide an transmission url");
            if (value.RefreshTime < 0)
                return BadRequest("Refresh time has to be more than 0");
            if (value.TransmissionPort < 0 || 65535 < value.TransmissionPort )
                return BadRequest("Transmission Port has to be valid");

            var config = configurator.GetClientConfiguration();
            config.RefreshTime = value.RefreshTime;
            config.TransmissionPort = value.TransmissionPort;
            config.TransmissionUrl = value.TransmissionUrl;
            configurator.SetClientConfiguration(config);

            return Ok();
        }
    }
}
