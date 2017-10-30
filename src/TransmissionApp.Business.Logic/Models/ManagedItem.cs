using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Business.Logic.Models
{
    public class ManagedItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public ItemsState State { get; set; }
    }
}
