using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Business.Logic.Configuration.Models
{
    public class RuleConfiguration
    {
        public string Id = Guid.NewGuid().ToString();
        public string Regex = "";
        public string Path = "";
        public int Priority = 0;
    }
}
