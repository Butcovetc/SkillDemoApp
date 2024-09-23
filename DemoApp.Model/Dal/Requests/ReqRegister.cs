using DemoApp.Model.Dal.Requests.Base;
using System.Text.Json.Serialization;

namespace DemoApp.Model.Dal.Requests
{
    /// <summary>
    /// Account registration request object
    /// </summary>
    public class ReqRegister : RequestTokenBased
    {
        /// <summary>
        /// Login
        /// </summary>
        public String? Login { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public String? Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public String? Password { get; set; }
    }
}
