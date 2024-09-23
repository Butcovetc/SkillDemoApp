using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.Exceptions.Api;
using DemoApp.Model.Exceptions.Critical;
using DemoApp.Model.Utils.Factories;
using FluentAssertions;

namespace DemoApp.MSTests
{
    [TestClass]
    public partial class UnitFactoryTests
    {
        [TestMethod]
        public void UnitFactory_SuccessTest()
        {
            var unit = UnitFactory
                .Create()
                .SetRequestType<RequestBase>()
                .SetResultType<ResponseBase>()
                .SetUnitType<UnitTestFactoryMokUnit>()
                .CreateUnit(new RequestBase());

            unit.Should().NotBeNull(); 
        }

        [TestMethod]
        public void UnitFactory_CreateEmptyTest()
        {
            var unit = UnitFactory
                .Create()
                .AddRequestObject(new RequestBase())
                .SetResultType<ResponseBase>()
                .SetUnitType<UnitTestFactoryMokUnit>()
                .CreateUnit();

            unit.Should().NotBeNull();
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumetMissingException))]
        public void UnitFactory_MissingRequestTest()
        {
            var unit = UnitFactory
                .Create()
                .SetResultType<ResponseBase>()
                .SetUnitType<UnitTestFactoryMokUnit>()
                .CreateUnit(new RequestBase());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumetMissingException))]
        public void UnitFactory_MissingResultTest()
        {
            var unit = UnitFactory
                .Create()
                .SetRequestType<RequestBase>()
                .SetUnitType<UnitTestFactoryMokUnit>()
                .CreateUnit(new RequestBase());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumetMissingException))]
        public void UnitFactory_MissingUnitTest()
        {
            var unit = UnitFactory
                .Create()
                .SetResultType<ResponseBase>()
                .SetRequestType<RequestBase>()
                .CreateUnit(new RequestBase());
        }

        [TestMethod]
        [ExpectedException (typeof(KernerException))]
        public void UnitFactory_EmptyConstructorTypeTest()
        {
            var unit = UnitFactory
                .Create()
                .SetRequestType<RequestBase>()
                .SetResultType<ResponseBase>()
                .SetUnitType<UnitTestFactory_EmptyContructor_MokUnit>()
                .CreateUnit(new RequestBase());
        }

        [TestMethod]
        [ExpectedException(typeof(KernerException))]
        public void UnitFactory_WrongRequestTypeTest()
        {
            var unit = UnitFactory
                .Create()
                .SetRequestType<RequestBase>()
                .SetResultType<ResponseBase>()
                .SetUnitType<UnitTestFactory_EmptyContructor_MokUnit>()
                .CreateUnit(new RequestBase());
        }
    }
}
