using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Dal.Response;
using DemoApp.Model.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Monee.RestApi.Controllers.Base;

namespace DemoApp.API.Controllers
{
    /// <summary>
    /// Account controller. Responde for account related actions
    /// </summary>
    internal class AccountController : BaseApiController
    {
        /// <summary>
        /// Account service
        /// </summary>
        IAccountService _accountService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Loger</param>
        public AccountController(IAccountService accountService) : base() {
            _accountService = accountService;
        }

        /// <summary>
        /// Account login operation
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Loging result object</returns>
        [HttpPost]
        public Task<RespLogin> Login([FromBody] ReqLogin request)
            => _accountService.LoginAsync(request);
    }
}
