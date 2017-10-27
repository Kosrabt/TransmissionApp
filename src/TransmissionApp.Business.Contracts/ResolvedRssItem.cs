using System;

namespace TransmissionApp.Business.Contracts
{
    public class ResolvedRssItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        public string DownloadPath { get; set; }
    }
}
