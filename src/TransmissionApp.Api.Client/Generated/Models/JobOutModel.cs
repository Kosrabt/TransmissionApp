// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace TransmissionApp.Api.Client.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class JobOutModel
    {
        /// <summary>
        /// Initializes a new instance of the JobOutModel class.
        /// </summary>
        public JobOutModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the JobOutModel class.
        /// </summary>
        public JobOutModel(string id = default(string), string name = default(string), string rssUrl = default(string), string downloadPath = default(string), IList<RuleOutModel> rules = default(IList<RuleOutModel>))
        {
            Id = id;
            Name = name;
            RssUrl = rssUrl;
            DownloadPath = downloadPath;
            Rules = rules;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rssUrl")]
        public string RssUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "downloadPath")]
        public string DownloadPath { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rules")]
        public IList<RuleOutModel> Rules { get; set; }

    }
}