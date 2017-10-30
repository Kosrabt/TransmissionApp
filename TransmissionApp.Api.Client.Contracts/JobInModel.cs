using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TransmissionApp.Api.Client.Contracts
{
    public class JobInModel
    {
        public string Id;
        [Required]
        public string Name;
        [Required]
        [DataType(DataType.Url)]
        public string RssUrl;
        [Required]
        public string DownloadPath;
    }
}
