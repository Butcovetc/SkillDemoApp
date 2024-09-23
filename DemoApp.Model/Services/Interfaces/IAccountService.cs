using DemoApp.Model.Dal.Requests;
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
    }
}
