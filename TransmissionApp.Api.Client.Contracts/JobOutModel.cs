using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Api.Client.Contracts
{
    public class JobOutModel
    {
        public string Id;
        public string Name;
        public string RssUrl;
        public string DownloadPath;
        public IEnumerable<RuleOutModel> Rules;
    }
}
