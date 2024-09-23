using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.Units.Base;
using Microsoft.Extensions.Logging;
using Monee.Logic.DbLayer;
using Moq;

namespace DemoApp.MSTests
{
    /// <summary>
    /// Mock unit doing nothing
    /// </summary>
    internal class UnitTestFactoryMokUnit : RequestResultUnitAbstract<ResponseBase, RequestBase>
    {
        public UnitTestFactoryMokUnit(ILogger logger, DataBaseContext context, RequestBase request) : base(logger, context,request)
        {
        }
    }


    /// <summary>
    /// Mock unit doing nothing
    /// </summary>
    internal class UnitTestFactory_EmptyContructor_MokUnit : RequestResultUnitAbstract<ResponseBase, RequestBase>
    {
        public UnitTestFactory_EmptyContructor_MokUnit() 
            : base(Mock.Of<ILogger>(),Mock.Of<DataBaseContext>(),new ()) { }
    }
}
