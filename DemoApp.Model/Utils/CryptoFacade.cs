using DemoApp.Model.DbContext.Entity;
using DemoApp.Model.Exceptions.Critical;
using System.Security.Cryptography;
using System.Text;

namespace DemoApp.Model.Utils
{
    /// <summary>
    /// Crypto facade
    /// </summary>
    public static partial class CryptoFacade
    {
        private static String? _salt;

        /// <summary>
        /// Set salt for a future operations
        /// </summary>
        /// <param name="salt"></param>
        public static void SetSalt(String salt)
            => _salt = salt;

        /// <summary>
        /// Encrypts password
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static String EncryptPass(String pass)
        {
            pass = WrapWithSalt(pass);

            byte[] data = Encoding.UTF8.GetBytes(pass);
            data = SHA256.Create().ComputeHash(data);
            return Encoding.UTF8.GetString(data);
        }

        /// <summary>
        /// Wraps & encode pass
        /// </summary>
        /// <param name="pass">Password string</param>
        /// <returns>Wrapped string ready to be hashed</returns>
        /// <exception cref="KernerException">If salt is not set</exception>
        private static string WrapWithSalt(string pass)
        {
            if (_salt == null)
                throw new KernerException("Salt not set or empty. Use SetSalt before usage");

            return _salt + pass + _salt;
        }
    }
}
