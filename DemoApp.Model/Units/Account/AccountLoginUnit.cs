using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Dal.Response;
using DemoApp.Model.Units.Base;
using Microsoft.Extensions.Logging;
using Monee.Logic.DbLayer;

namespace DemoApp.Model.Units.Account
{
    /// <summary>
    /// authorize user
    /// </summary>
    internal class AccountLoginUnit : RequestResultUnitAbstract<RespLogin, ReqLogin>
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="request">Request object</param>
        public AccountLoginUnit(ILogger logger, DataBaseContext context, ReqLogin request) 
            : base(logger, context, request) {}

        protected override void Init()
        {
            base.Init();
        }
    }
}
