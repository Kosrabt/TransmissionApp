using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Business.Logic.Configuration.Models
{
    public class ClientConfiguration
    {
        public int RefreshTime = 60;
        public string TransmissionUrl = "http://localhost";
        public int TransmissionPort = 9091;

        public IEnumerable<JobConfiguration> Jobs = new List<JobConfiguration>();
    }
}
