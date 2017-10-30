using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TransmissionApp.Api.Client.Contracts
{
    public class SettingsInModel
    {
        [Required]
        public int RefreshTime { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string TransmissionUrl { get; set; }

        [Required]        
        public int TransmissionPort { get; set; }
    }
}
