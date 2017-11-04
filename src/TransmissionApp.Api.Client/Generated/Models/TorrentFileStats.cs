// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace TransmissionApp.Api.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class TorrentFileStats
    {
        /// <summary>
        /// Initializes a new instance of the TorrentFileStats class.
        /// </summary>
        public TorrentFileStats()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TorrentFileStats class.
        /// </summary>
        public TorrentFileStats(double? bytesCompleted = default(double?), bool? wanted = default(bool?), int? priority = default(int?))
        {
            BytesCompleted = bytesCompleted;
            Wanted = wanted;
            Priority = priority;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bytesCompleted")]
        public double? BytesCompleted { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "wanted")]
        public bool? Wanted { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

    }
}
