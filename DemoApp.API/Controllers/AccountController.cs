using Monee.RestApi.Controllers.Base;

namespace DemoApp.API.Controllers
{
    /// <summary>
    /// Account controller. Responde for account related actions
    /// </summary>
    public class AccountController : BaseApiController
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Loger</param>
        public AccountController(ILogger logger) : base(logger) {}
    }
}
