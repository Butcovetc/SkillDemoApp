using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.DbContext.Entity;
using Microsoft.Extensions.Logging;
using Monee.Logic.DbLayer;
using static DemoApp.Model.Utils.CryptoFacade;

namespace DemoApp.Model.Units.Base
{
    /// <summary>
    /// Authorization base unit. Should be based for all auth units
    /// </summary>
    internal class AuthorizationBasedUnit<TResult, TRequest> : RequestResultUnitAbstract<TResult, TRequest>
        where TResult : ResponseBase, new()
        where TRequest : RequestTokenBased
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="context">Context</param>
        /// <param name="request">Request object</param>
        public AuthorizationBasedUnit(ILogger logger, DataBaseContext context,TRequest request)
            : base(logger, context, request)
        {
        }


        /// <summary>
        /// Pack token to string
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Packed token</returns>
        protected String PackToken(ApplicationUserEntity user)
        {
            var data = $"{user.Email}|{user.Id}|{user.Session}";
            return Convert.ToBase64String(AESEcryption.ToAes(data));
        }
    }
}
