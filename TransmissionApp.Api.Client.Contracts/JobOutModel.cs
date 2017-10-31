using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Api.Client.Contracts
{
    public class JobOutModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RssUrl { get; set; }
        public string DownloadPath { get; set; }
        public IEnumerable<RuleOutModel> Rules { get; set; }
    }
}
