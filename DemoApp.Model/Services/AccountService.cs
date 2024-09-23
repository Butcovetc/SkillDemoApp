using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response;
using DemoApp.Model.Services.Interfaces;
using DemoApp.Model.Units.Account;
using Microsoft.Extensions.Logging;
using Monee.Logic.DbLayer;

namespace DemoApp.Model.Services
{
    /// <summary>
    /// Account manadgment service
    /// </summary>
    internal class AccountService :ServiceBase, IAccountService
    {
        /// <summary>
        /// Constuctor 
        /// </summary>
        /// <param name="logger">Class logger</param>
        /// <param name="context">Context</param>
        public AccountService(ILogger logger, DataBaseContext context)
            :base(logger,context)
        { }

        /// <summary>
        /// Returns users list
        /// </summary>
        /// <param name="request">Request token based</param>
        /// <returns>Result list</returns>
        public Task<ResponseList<AccountItem>> GetAllUsers(RequestTokenBased request)
            => RunAsync<ResponseList<AccountItem>, GetAllUsersUnit, RequestTokenBased>(request);

        /// <summary>
        /// User login method
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Result object</returns>
        Task<RespLogin> IAccountService.LoginAsync(ReqLogin request)
            => RunAsync<RespLogin, AccountLoginUnit, ReqLogin>(request);
    }
}
