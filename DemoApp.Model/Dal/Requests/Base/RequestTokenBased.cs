namespace DemoApp.Model.Dal.Requests.Base
{
    /// <summary>
    /// Request token base
    /// </summary>
    public class RequestTokenBased:RequestBase
    {
        /// <summary>
        /// Token 
        /// </summary>
        public String? Token { get; set; }
    }
}
