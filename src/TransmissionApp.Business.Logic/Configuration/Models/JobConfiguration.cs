using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Business.Logic.Configuration.Models
{
    public class JobConfiguration
    {
        public string Id = Guid.NewGuid().ToString();
        public string Name = "Unnamed";
        public string RssUrl = "";
        public string DownloadPath = "/";
        public IEnumerable<RuleConfiguration> Rules = new List<RuleConfiguration>();
    }
}
