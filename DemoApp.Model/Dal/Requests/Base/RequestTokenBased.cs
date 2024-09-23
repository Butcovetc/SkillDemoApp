namespace DemoApp.Model.Dal.Requests.Base
{
    /// <summary>
    /// Request token base
    /// </summary>
    internal class RequestTokenBased:RequestBase
    {
        /// <summary>
        /// Token 
        /// </summary>
        public String? Token { get; set; }
    }
}
