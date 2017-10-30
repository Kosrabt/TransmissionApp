using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TransmissionApp.Api.Client.Contracts
{
    public class RuleInModel
    {
        public string Id;
        [Required]
        public string Regex;
        [Required]
        public string Path;
        [Required]
        public int Priority;
    }
}
