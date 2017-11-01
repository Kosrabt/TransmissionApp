using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransmissionApp.Business.Logic;
using AutoMapper;
using Transmission.API.RPC;
using Transmission.API.RPC.Entity;
using TransmissionApp.TorrentClients;
using TransmissionApp.TorrentClients.TransmissionClient;
using TransmissionApp.TorrentClients.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransmissionApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class TorrentsController : Controller
    {
        NeedABetterNameConfigurator configurator;
        IMapper mapper;
        RpcClient client;

        public TorrentsController(NeedABetterNameConfigurator configurator, IMapper mapper)
        {
            this.configurator = configurator;
            this.mapper = mapper;
            var clientConfig = configurator.GetClientConfiguration();
            client = new RpcClient(clientConfig.TransmissionUrl, "kodi", "kodi");
        }

        // GET: api/values
        [HttpGet]
        public AllTorrents Get()
        {
            return client.TorrentGet();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
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
