using DemoApp.Model.Utils;
using FluentAssertions;
using System.Security.Cryptography;
using System.Text;

namespace DemoApp.MSTests.Facades
{
    [TestClass]
    internal class CryptoFacadeTests:TestInitializerBase
    {
        [TestMethod]
        public void CryptoFacade_EncryptPasswordTest() {
            var password = Faker.StringFaker.AlphaNumeric(20);

            var result = CryptoFacade.EncryptPass(password);

            result.Should().NotBeNullOrWhiteSpace();

            var strToEncrypt = $"{Settings.UserPassWordEncryptionSalt}{password}{Settings.UserPassWordEncryptionSalt}";
            var expPass = Encoding.UTF8.GetString(
                SHA256.Create().ComputeHash(
                    Encoding.UTF8.GetBytes(strToEncrypt)));
            
        }


        [TestMethod]
        public void CryptoFacade_To_And_FromAesBinary_Test()
        {
            var dataToEncrypt = Faker.StringFaker.AlphaNumeric(40);

            var dataEncrypted = CryptoFacade.AESEcryption.ToAes(dataToEncrypt);

            dataEncrypted.Should().NotBeNullOrEmpty();
            
            var decryptedData = CryptoFacade.AESEcryption.FromAes(dataEncrypted);

            decryptedData.Should().Be(dataToEncrypt);
        }

        [TestMethod]
        public void CryptoFacade_To_And_FromAesString_Test()
        {
            var dataToEncrypt = Faker.StringFaker.AlphaNumeric(40);

            var dataEncrypted = CryptoFacade.AESEcryption.ToAesString(dataToEncrypt);

            dataEncrypted.Should().NotBeNullOrEmpty();

            var decryptedData = CryptoFacade.AESEcryption.FromAesString(dataEncrypted);

            decryptedData.Should().Be(dataToEncrypt);
        }
    }
}
