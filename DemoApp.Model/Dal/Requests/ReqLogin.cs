using DemoApp.Model.Dal.Requests.Base;

namespace DemoApp.Model.Dal.Requests
{
    /// <summary>
    /// Account login request object
    /// </summary>
    public class ReqLogin:RequestBase
    {
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
