using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransmissionApp.Web.ViewModels.Settings
{
    public class IndexViewModel
    {
        [Required]
        [Range(0, 86400)]
        public int RefreshTime { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string TransmissionUrl { get; set; }
        [Required]
        [Range(0, 65535)]
        public int TransmissionPort { get; set; }
    }
}
