using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Business.Contracts
{
    public class ManagedItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public Enums.ItemsState State { get; set; }
    }
}
