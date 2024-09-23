using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.DbContext.Entity;
using DemoApp.Model.Exceptions.Account;
using DemoApp.Model.Utils;
using Microsoft.Extensions.Logging;
using Monee.Logic.DbLayer;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
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
        public AuthorizationBasedUnit(ILogger logger, DataBaseContext context, TRequest request)
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
            var tokenData = new TokenData
            {
                Id = user.Id,
                Email = user.Email,
                SessionKeyUniq = user.SessionKeyUniq,
            };
            
            var data = JObject.FromObject(tokenData).ToString(Newtonsoft.Json.Formatting.None);
            
            return Convert.ToBase64String(AESEcryption.ToAes(data));
        }

        /// <summary>
        /// Un pack token 
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Packed token</returns>
        protected TokenData UnpackToken(String token)
        {
            var data = CryptoFacade.AESEcryption.FromAesString(token);
            if (data == null)
                throw new InvalidTokenException();

            var tokenObject =  JObject.Parse(data).ToObject<TokenData>();
            if (tokenObject == null)
                throw new InvalidTokenException();

            return tokenObject;
        }
    }
}
