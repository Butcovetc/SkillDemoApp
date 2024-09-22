using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Dal.Response;
using DemoApp.Model.Units.Base;

namespace DemoApp.Model.Units.Account
{
    public class AccountLoginUnit : RequestResultUnitAbstract<RespLogin, ReqLogin>
    {
        public AccountLoginUnit(ReqLogin request) : base(request)
        {
        }


        protected override void Init()
        {
            //No auth requered
            //base.Init();
        }

    }
}
