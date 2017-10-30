using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Api.Client.Contracts
{
    public class RuleOutModel
    {
        public string Id;
        public string Regex;
        public string Path;
        public int Priority;
    }
}
