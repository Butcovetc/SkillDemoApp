using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Account;
using DemoApp.Model.DbContext.Entity;
using DemoApp.Model.Services.Interfaces;
using DemoApp.Model.Utils;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Monee.Logic.DbLayer;

namespace DemoApp.MSTests.Account
{
    class Account_GetAllAccounts_Test : TestInitializerBase
    {
        IAccountService _service;
        private IServiceScope _scope;


        /// <summary>
        /// Database context
        /// </summary>
        DataBaseContext Context => _scope.ServiceProvider.GetRequiredService<DataBaseContext>();

        [TestInitialize]
        public void TestInitializeMethod()
        {
            ConfigureServieProvider();

            _scope = base.ServiceProvider.CreateScope();
            _service = _scope.ServiceProvider.GetRequiredService<IAccountService>();
        }

        [TestCleanup]
        public void TestCleanupMethod()
        {
            if (_scope != null)
                _scope.Dispose();
        }

        [TestMethod]
        public void Account_GetAllAccount_Test()
        {
            var context = this.Context;

            context.Users.RemoveRange(context.Users.ToList());
            context.SaveChanges();

            List<ApplicationUserEntity> users = GenerateUsers();

            context.AddRange(users);
            context.SaveChanges();
            
            RespLogin result = GetToken(context);

            var resultAllAccounts = _service.GetAllAccountsAsync(new RequestTokenBased
            {
                Token = result.Token
            }).Result;

            resultAllAccounts.Error.Should().Be(Model.Dal.ErrorCodeEnum.Success);
            resultAllAccounts.Items.Should().NotBeNullOrEmpty();

            var itemDict = resultAllAccounts.Items.ToDictionary(x => x.Id);

            foreach (var account in users)
            {
                var resultItem = itemDict[account.Id];
                resultItem.Email.Should().Be(account.Email);
                resultItem.Login.Should().Be(account.Login);
            }
        }

        private RespLogin GetToken(DataBaseContext context)
        {
            var pass = Faker.StringFaker.AlphaNumeric(10);
            var user = new ApplicationUserEntity
            {
                Login = Faker.StringFaker.AlphaNumeric(5),
                Email = Faker.InternetFaker.Email(),
                PassHash = CryptoFacade.EncryptPass(pass)
            };

            context.Users.Add(user);

            context.SaveChanges();

            var reqLogin = new ReqLogin
            {
                Login = user.Login,
                Password = pass
            };

            var result = _service.LoginAsync(reqLogin).Result;
            return result;
        }

        private static List<ApplicationUserEntity> GenerateUsers()
        {
            var users = new List<ApplicationUserEntity>();

            for (int i = 0; i < 10; i++)
            {
                users.Add(new ApplicationUserEntity() 
                { 
                    Email = Faker.InternetFaker.Email(),
                    Login = Faker.StringFaker.AlphaNumeric(10),
                    PassHash = CryptoFacade.EncryptPass(Faker.StringFaker.AlphaNumeric(10)),
                });
            }

            return users;
        }
    }
}
