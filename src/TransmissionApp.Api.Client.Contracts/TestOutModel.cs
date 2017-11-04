using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Api.Client.Contracts
{
    public class TestOutModel
    {
        
        public int TorrentId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public int StateInt { get; set; }
    }
}
