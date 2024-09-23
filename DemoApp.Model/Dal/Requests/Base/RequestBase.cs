using System.Text.Json.Serialization;

namespace DemoApp.Model.Dal.Requests.Base
{
    /// <summary>
    /// Base request object 
    /// </summary>
    public class RequestBase
    {
        /// <summary>
        /// Store client Ip
        /// </summary>
        [JsonIgnore]//To hide field from swagger
        public String? Ip { get; set; }
    }
}
