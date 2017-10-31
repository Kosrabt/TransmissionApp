using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransmissionApp.Web.ViewModels.Jobs
{
    public class JobViewModel
    {
       
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string RssUrl { get; set; }

        [Required]
        public string DownloadPath { get; set; }

        public IEnumerable<RuleViewModel> Rules { get; set; }
    }
}
