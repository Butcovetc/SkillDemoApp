using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Dal.Response;
using DemoApp.Model.Units.Base;

namespace DemoApp.Model.Units.Account
{
    /// <summary>
    /// authorize user
    /// </summary>
    public class AccountLoginUnit : RequestResultUnitAbstract<RespLogin, ReqLogin>
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="request">Request object</param>
        public AccountLoginUnit(ReqLogin request) : base(request) {}

        protected override void Init()
        {
            base.Init();
        }
    }
}
