using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TransmissionApp.Api.Client.Contracts
{
    public class JobInModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string RssUrl { get; set; }
        [Required]
        public string DownloadPath { get; set; }
    }
}
