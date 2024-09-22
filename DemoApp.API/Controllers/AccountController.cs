using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Dal.Response;
using DemoApp.Model.Units.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public AccountController(ILogger logger) : base(logger) { }

        /// <summary>
        /// Account login operation
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Loging result object</returns>
        [HttpPost]
        public RespLogin Login([FromBody] ReqLogin request)
            => Run<RespLogin, AccountLoginUnit, ReqLogin>(request);
    }
}
