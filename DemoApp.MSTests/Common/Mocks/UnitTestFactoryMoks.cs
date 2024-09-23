using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.Units.Base;

namespace DemoApp.MSTests
{
    /// <summary>
    /// Mock unit doing nothing
    /// </summary>
    internal class UnitTestFactoryMokUnit : RequestResultUnitAbstract<ResponseBase, RequestBase>
    {
        public UnitTestFactoryMokUnit(RequestBase request) : base(request)
        {
        }
    }


    /// <summary>
    /// Mock unit doing nothing
    /// </summary>
    internal class UnitTestFactory_EmptyContructor_MokUnit : RequestResultUnitAbstract<ResponseBase, RequestBase>
    {
        public UnitTestFactory_EmptyContructor_MokUnit() : base(new()) { }
    }
}
