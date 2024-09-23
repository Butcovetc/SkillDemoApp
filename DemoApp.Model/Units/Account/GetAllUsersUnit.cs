using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response;
using DemoApp.Model.Dal.Response.Account;
using DemoApp.Model.Units.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Monee.Logic.DbLayer;

namespace DemoApp.Model.Units.Account
{
    /// <summary>
    /// authorize user
    /// </summary>
    internal class GetAllUsersUnit : AuthorizationBasedUnit<ResponseList<AccountItem>, RequestTokenBased>
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="request">Request object</param>
        public GetAllUsersUnit(ILogger logger, DataBaseContext context, RequestTokenBased request) 
            : base(logger, context, request) {}


        protected override void Proceed()
        {
            base.Proceed();

            Result.Items = (from user
                      in Context.Users.AsNoTracking()
                      select new AccountItem
                      {
                          Email = user.Email,
                          Login = user.Login
                      }).ToList();
                
            SetSuccess();
        }
    }
}
