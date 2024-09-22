using DemoApp.Model.Dal.Requests.Base;

namespace DemoApp.Model.Dal
{
    /// <summary>
    /// Request object by id
    /// </summary>
    public class RequestById:RequestTokenBased
    {
        /// <summary>
        /// Id param
        /// </summary>
        public Int32? Id { get; set; }
    }
}
