using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Dal.Response;
using DemoApp.Model.DbContext.Entity;
using DemoApp.Model.Exceptions.Api;
using DemoApp.Model.Units.Base;
using DemoApp.Model.Utils;
using Microsoft.Extensions.Logging;
using Monee.Logic.DbLayer;

namespace DemoApp.Model.Units.Account
{
    /// <summary>
    /// authorize user
    /// </summary>
    internal class AccountLoginUnit : AuthorizationBasedUnit<RespLogin, ReqLogin>
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="request">Request object</param>
        public AccountLoginUnit(ILogger logger, DataBaseContext context, ReqLogin request) 
            : base(logger, context, request) {}

        /// <summary>
        /// Application user entity object
        /// </summary>
        private ApplicationUserEntity? _user;

        protected override void Init()
        {
            base.Init();

            ArgumetMissingException.ThrowIfNullOrEmpty(Request.Login);

            ArgumetMissingException.ThrowIfNullOrEmpty(Request.Password);

            _user = Context
                .Users
                .FirstOrDefault(x => x.Login == Request.Login);

            if (_user == null)
                throw new UserNotFoundOrPasswordAreNotValidException();
        }

        protected override void Proceed()
        {
            base.Proceed();

            var encryptedPass = CryptoFacade.EncryptPass(Request.Password);

            if (encryptedPass != _user.PassHash)
                throw new UserNotFoundOrPasswordAreNotValidException();

            _user.SessionKeyUniq = Guid.NewGuid();

            Context.SaveChanges();
            
            Result.Token = PackToken(_user);
            
            SetSuccess();
        
        }
    }
}
