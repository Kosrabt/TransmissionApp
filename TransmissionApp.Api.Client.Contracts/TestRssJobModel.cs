using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Api.Client.Contracts
{
    public class TestRssJobModel
    {
        public string JobId { get; set; }
        public IEnumerable<TestRssItemModel> Items { get; set; }
    }
}
