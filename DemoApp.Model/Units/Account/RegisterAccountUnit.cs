using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Dal.Response.Account;
using DemoApp.Model.Dal.Response.Base;
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
    internal class RegisterAccountUnit : AuthorizationBasedUnit<RespRegistration, ReqRegister>
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="request">Request object</param>
        public RegisterAccountUnit(ILogger logger, DataBaseContext context, ReqRegister request) 
            : base(logger, context, request) {}

        /// <summary>
        /// Application user entity object
        /// </summary>
        private ApplicationUserEntity? _user;

        protected override void Init()
        {
            base.Init();

            ArgumetMissingException.ThrowIfNullOrEmpty(Request.Login,"Login should contains proper data");
            ArgumetMissingException.ThrowIfNullOrEmpty(Request.Password, "Password should contains proper data");
            ArgumetMissingException.ThrowIfNullOrEmpty(Request.Email, "Email should contains proper data");

            _user = Context
                .Users
                .FirstOrDefault(x => x.Login == Request.Login);

            if (_user != null)
                throw new WrongArgumentException($"User with login '{Request.Login}' already exists");
        }

        protected override void Proceed()
        {
            base.Proceed();

            var user = new ApplicationUserEntity
            {
                Email = Request.Email,
                Login = Request.Login,
                PassHash = CryptoFacade.EncryptPass(Request.Password),
            };

            Context.Users.Add(user);    

            Context.SaveChanges();

            Result.Id = user.Id;
            
            SetSuccess();
        }
    }
}
