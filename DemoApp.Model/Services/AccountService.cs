using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Dal.Response;
using DemoApp.Model.Services.Interfaces;
using DemoApp.Model.Units.Account;

namespace DemoApp.Model.Services
{
    /// <summary>
    /// Account manadgment service
    /// </summary>
    public class AccountService :ServiceBase, IAccountService
    {
        /// <summary>
        /// User login method
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>Result object</returns>
        Task<RespLogin> IAccountService.LoginAsync(ReqLogin request)
            => RunAsync<RespLogin, AccountLoginUnit, ReqLogin>(request);
    }
}
