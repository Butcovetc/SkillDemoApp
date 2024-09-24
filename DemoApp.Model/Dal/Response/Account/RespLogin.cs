using DemoApp.Model.Dal.Response.Base;

namespace DemoApp.Model.Dal.Response.Account
{
    /// <summary>
    /// Response login object
    /// </summary>
    public class RespLogin : ResponseBase
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
        /// Authorization token
        /// </summary>
        public String? Token { get; set; }
    }
}
