using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.Exceptions.Api;
using DemoApp.Model.Exceptions.Critical;
using DemoApp.Model.Utils.Factories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Monee.Logic.DbLayer;
using Moq;

namespace DemoApp.MSTests
{
    [TestClass]
    public partial class UnitFactoryTests
    {
        private DataBaseContext _context;
        private ILogger _logger;

        [TestInitialize]
        public void TestInitialize()
        {
            _context = Mock.Of<DataBaseContext>();
            _logger = Mock.Of<ILogger>();
        }

        [TestMethod]
        public void UnitFactory_SuccessTest()
        {
            var unit = UnitFactory
                .Create()
                .SetRequestType<RequestBase>()
                .SetResultType<ResponseBase>()
                .SetUnitType<UnitTestFactoryMokUnit>()
                .CreateUnit(_logger, _context, new RequestBase());

            unit.Should().NotBeNull(); 
        }

        [TestMethod]
        public void UnitFactory_CreateWithoutRequestTest()
        {
            var unit = UnitFactory
                .Create()
                .AddRequestObject(new RequestBase())
                .SetResultType<ResponseBase>()
                .SetUnitType<UnitTestFactoryMokUnit>()
                .CreateUnit(_logger, _context);

            unit.Should().NotBeNull();
        }



        [TestMethod]
        [ExpectedException(typeof(UserNotFoundOrPasswordAreNotValidException))]
        public void UnitFactory_MissingRequestTest()
        {
            var unit = UnitFactory
                .Create()
                .SetResultType<ResponseBase>()
                .SetUnitType<UnitTestFactoryMokUnit>()
                .CreateUnit(_logger, _context,new RequestBase());
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundOrPasswordAreNotValidException))]
        public void UnitFactory_MissingResultTest()
        {
            var unit = UnitFactory
                .Create()
                .SetRequestType<RequestBase>()
                .SetUnitType<UnitTestFactoryMokUnit>()
                .CreateUnit(_logger, _context,new RequestBase());
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundOrPasswordAreNotValidException))]
        public void UnitFactory_MissingUnitTest()
        {
            var unit = UnitFactory
                .Create()
                .SetResultType<ResponseBase>()
                .SetRequestType<RequestBase>()
                .CreateUnit(_logger, _context,new RequestBase());
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
                .CreateUnit(_logger, _context,new RequestBase());
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
                .CreateUnit(_logger, _context,new RequestBase());
        }
    }
}
