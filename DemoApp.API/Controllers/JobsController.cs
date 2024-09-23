using Monee.RestApi.Controllers.Base;

namespace DemoApp.API.Controllers
{
    /// <summary>
    /// Jobs controller. Responde for job related actions
    /// </summary>
    public class JobsController : BaseApiController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Loger</param>
        public JobsController(ILogger logger) : base() {}
    }
}
