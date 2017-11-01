using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Api.Client.Contracts
{
    public class RuleOutModel
    {
        public string Id { get; set; }
        public string Regex { get; set; }
        public string Path { get; set; }
        public int Priority { get; set; }
    }
}
