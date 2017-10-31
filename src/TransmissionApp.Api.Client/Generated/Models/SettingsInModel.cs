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

    public partial class SettingsInModel
    {
        /// <summary>
        /// Initializes a new instance of the SettingsInModel class.
        /// </summary>
        public SettingsInModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SettingsInModel class.
        /// </summary>
        public SettingsInModel(int refreshTime, string transmissionUrl, int transmissionPort)
        {
            RefreshTime = refreshTime;
            TransmissionUrl = transmissionUrl;
            TransmissionPort = transmissionPort;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "refreshTime")]
        public int RefreshTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "transmissionUrl")]
        public string TransmissionUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "transmissionPort")]
        public int TransmissionPort { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (TransmissionUrl == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TransmissionUrl");
            }
        }
    }
}