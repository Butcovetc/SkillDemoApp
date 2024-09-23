using DemoApp.Model.Dal.Requests.Base;
using System.Text.Json.Serialization;

namespace DemoApp.Model.Dal.Requests
{
    /// <summary>
    /// Account login request object
    /// </summary>
    internal class ReqLogin : RequestTokenBased
    {
        //hiding token from swagger
        [JsonIgnore]
        private new String? Token {get;set;}

        /// <summary>
        /// Login
        /// </summary>
        public String? Login { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public String? Password { get; set; }
    }
}
