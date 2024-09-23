using System.Text.Json.Serialization;

namespace DemoApp.Model.Dal.Requests.Base
{
    /// <summary>
    /// Base request object 
    /// </summary>
    internal class RequestBase
    {
        /// <summary>
        /// Store client Ip
        /// </summary>
        [JsonIgnore]//To hide field from swagger
        public string Ip { get; set; }
    }
}
