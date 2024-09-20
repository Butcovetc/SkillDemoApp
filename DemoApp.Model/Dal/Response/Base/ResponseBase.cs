using System.Text.Json.Serialization;

namespace DemoApp.Model.Dal.Response.Base
{
    /// <summary>
    /// Base object to all responses  
    /// </summary>
    public class ResponseBase
    {

        /// <summary>
        /// Unit result error code 
        /// </summary>
        public ErrorCodeEnum Error { get; set; }

        /// <summary>
        /// Array of error's description
        /// </summary>
        public List<String> ErrorDescriptions { get; set; }
    }
}
