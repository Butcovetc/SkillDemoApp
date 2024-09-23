using DemoApp.Model.Dal.Response.Base;

namespace DemoApp.Model.Dal.Response.Account
{
    /// <summary>
    /// Response login object
    /// </summary>
    public class RespLogin : ResponseBase
    {
        /// <summary>
        /// Authorization token
        /// </summary>
        public string? Token { get; set; }
    }
}
