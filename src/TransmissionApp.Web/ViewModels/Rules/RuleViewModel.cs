using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransmissionApp.Web.ViewModels.Rules
{
    public class RuleViewModel
    {
        [Required]
        public string JobId { get; set; }
        public string Id { get; set; }
        [Required]
        public string Regex { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public int Priority { get; set; }
    }
}
