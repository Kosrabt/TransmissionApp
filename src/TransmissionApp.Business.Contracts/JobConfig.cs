﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Business.Contracts
{
    public class JobConfig
    {
        public string Id;
        public string Name;
        public string RssUrl;
        public string DownloadPath;
        public IEnumerable<RuleConfig> Rules;
    }
}
