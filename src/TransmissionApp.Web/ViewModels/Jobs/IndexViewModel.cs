using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransmissionApp.Web.ViewModels.Jobs
{
    public class IndexViewModel
    {
        IEnumerable<JobViewModel> Jobs { get; set; }
    }
}
