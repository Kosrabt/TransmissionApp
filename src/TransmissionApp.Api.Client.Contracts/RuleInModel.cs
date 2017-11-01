using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TransmissionApp.Api.Client.Contracts
{
    public class RuleInModel
    {
        public string Id { get; set; }
        [Required]
        public string Regex { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public int Priority { get; set; }
    }
}
