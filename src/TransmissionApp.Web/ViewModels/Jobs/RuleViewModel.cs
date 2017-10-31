using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransmissionApp.Web.ViewModels.Jobs
{
    public class RuleViewModel
    {
        public string Id { get; set; }
        public string Regex { get; set; }
        public string Path { get; set; }

        public int Priority { get; set; }
    }
}
