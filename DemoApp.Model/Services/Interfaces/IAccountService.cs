using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response;

namespace DemoApp.Model.Services.Interfaces
{
    /// <summary>
    /// Account manadgment service
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Login action
        /// </summary>
        /// <param name="">Request object</param>
        /// <returns>Responce object</returns>
        Task<RespLogin> LoginAsync(ReqLogin request);


        /// <summary>
        /// Returns users list
        /// </summary>
        /// <param name="request">Request token based</param>
        /// <returns>Result list</returns>

        Task<ResponseList<AccountItem>> GetAllAccountsAsync(RequestTokenBased request);
    }
}
