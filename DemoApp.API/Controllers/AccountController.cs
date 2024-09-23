using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response;
using DemoApp.Model.Services.Interfaces;
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
        /// Account service
        /// </summary>
        IAccountService _accountService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Loger</param>
        public AccountController(IAccountService accountService) : base()
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Account login operation
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Loging result object</returns>
        [HttpPost]
        [Route("Login")]
        public Task<RespLogin> Login([FromBody] ReqLogin request)
            => _accountService.LoginAsync(request);

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Users collection list</returns>
        [HttpPost]
        [Route("List")]
        public Task<ResponseList<AccountItem>> GetAllAccounts([FromBody] RequestTokenBased request)
            => _accountService.GetAllAccountsAsync(request);
    }
}
