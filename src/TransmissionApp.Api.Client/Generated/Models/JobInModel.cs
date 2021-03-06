// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace TransmissionApp.Api.Client.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class JobInModel
    {
        /// <summary>
        /// Initializes a new instance of the JobInModel class.
        /// </summary>
        public JobInModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the JobInModel class.
        /// </summary>
        public JobInModel(string name, string rssUrl, string downloadPath, string id = default(string))
        {
            Id = id;
            Name = name;
            RssUrl = rssUrl;
            DownloadPath = downloadPath;
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
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (RssUrl == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "RssUrl");
            }
            if (DownloadPath == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DownloadPath");
            }
        }
    }
}
