using DemoApp.Model.Dal.Response.Base;

namespace DemoApp.Model.Dal.Response
{
    /// <summary>
    /// Response login object
    /// </summary>
    public class RespLogin: ResponseBase
    {
        public String Token { get; set; }

    }
}
