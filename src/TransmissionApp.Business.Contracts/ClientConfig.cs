using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Business.Contracts
{
    public class ClientConfig
    {
        public int RefreshTime;
        public string TransmissionUrl;
        public int TransmissionPort;

        public IEnumerable<JobConfig> Jobs;
    }
}
