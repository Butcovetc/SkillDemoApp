using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.DbContext.Entity;
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
        public AuthorizationBasedUnit(TRequest request) : base(request)
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
