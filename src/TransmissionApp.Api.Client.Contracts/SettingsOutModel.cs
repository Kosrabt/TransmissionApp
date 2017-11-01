using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Api.Client.Contracts
{
    public class SettingsOutModel
    {
        public int RefreshTime { get; set; }
        public string TransmissionUrl { get; set; }
        public int TransmissionPort { get; set; }
    }
}
