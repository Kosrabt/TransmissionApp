// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace TransmissionApp.Api.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class RuleOutModel
    {
        /// <summary>
        /// Initializes a new instance of the RuleOutModel class.
        /// </summary>
        public RuleOutModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RuleOutModel class.
        /// </summary>
        public RuleOutModel(string id = default(string), string regex = default(string), string path = default(string), int? priority = default(int?))
        {
            Id = id;
            Regex = regex;
            Path = path;
            Priority = priority;
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
        [JsonProperty(PropertyName = "regex")]
        public string Regex { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

    }
}