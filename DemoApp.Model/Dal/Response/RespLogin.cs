using DemoApp.Model.Dal.Response.Base;

namespace DemoApp.Model.Dal.Response
{
    /// <summary>
    /// Response login object
    /// </summary>
    public class RespLogin: ResponseBase
    {
        /// <summary>
        /// Authorization token
        /// </summary>
        public String? Token { get; set; }
    }
}
