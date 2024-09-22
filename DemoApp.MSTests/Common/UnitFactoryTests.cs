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
        public void UnitFactorySuccessTest()
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
        [ExpectedException(typeof(ArgumetMissingException))]
        public void UnitFactoryMissingRequestTest()
        {
            var unit = UnitFactory
                .Create()
                .SetResultType<ResponseBase>()
                .SetUnitType<UnitTestFactoryMokUnit>()
                .CreateUnit(new RequestBase());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumetMissingException))]
        public void UnitFactoryMissingResultTest()
        {
            var unit = UnitFactory
                .Create()
                .SetRequestType<RequestBase>()
                .SetUnitType<UnitTestFactoryMokUnit>()
                .CreateUnit(new RequestBase());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumetMissingException))]
        public void UnitFactoryMissingUnitTest()
        {
            var unit = UnitFactory
                .Create()
                .SetResultType<ResponseBase>()
                .SetRequestType<RequestBase>()
                .CreateUnit(new RequestBase());
        }

        [TestMethod]
        [ExpectedException (typeof(KernerErrorException))]
        public void UnitFactoryEmptyConstructorTypeTest()
        {
            var unit = UnitFactory
                .Create()
                .SetRequestType<RequestBase>()
                .SetResultType<ResponseBase>()
                .SetUnitType<UnitTestFactory_EmptyContructor_MokUnit>()
                .CreateUnit(new RequestBase());
        }

        [TestMethod]
        [ExpectedException(typeof(KernerErrorException))]
        public void UnitFactoryWrongRequestTypeTest()
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
