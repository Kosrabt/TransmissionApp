using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransmissionApp.Business.Logic;
using TransmissionApp.Api.Client.Contracts;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransmissionApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {

        NeedABetterNameExecutor executor;
        NeedABetterNameConfigurator configurator;
        IMapper mapper;

        public TestController(NeedABetterNameExecutor executor, NeedABetterNameConfigurator configurator, IMapper mapper)
        {
            this.executor = executor;
            this.configurator = configurator;
            this.mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<TestOutModel> Get()
        {
            var items = executor.GetItemsToBeManaged();
            var mapped = mapper.Map<IEnumerable<TestOutModel>>(items);
            return mapped;
        }
    }
}
