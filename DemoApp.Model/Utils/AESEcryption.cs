using System.Security.Cryptography;
using System.Text;

namespace DemoApp.Model.Utils
{
    public static partial class CryptoFacade
    {
        internal class AESEcryption
        {
            /// <summary>
            /// Shoulb be stored in usert secrets for safty reasons
            /// </summary>
            private static byte[] iv = [45, 78, 34, 157, 79, 45, 231, 32, 222, 111, 243, 123, 214, 34, 56, 78];
            private static byte[] aesKey =
            [
                12, 43, 13, 67, 12, 31, 23, 132, 55, 93, 24, 56, 76,
                28, 95, 142, 95, 63, 29, 61, 22, 123, 212, 34, 22, 11,
                31, 41, 123, 129,234,12
            ];

            /// <summary>
            /// Decrypt base64 and AES
            /// </summary>
            /// <param name="source">Source string</param>
            /// <returns></returns>
            public static String FromAesString(String source) 
                => FromAes(Convert.FromBase64String(source));

            /// <summary>
            /// Ecrypt to string and base64
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            public static String ToAesString(String str) 
                => Convert.ToBase64String(ToAes(str));

            public static String FromAes(byte[] toConvert)
                => DecryptStringFromBytes_Aes(toConvert, aesKey, iv);

            public static byte[] ToAes(String source)
                => EncryptStringToBytes_Aes(source, aesKey, iv);

            private static string DecryptStringFromBytes_Aes(
                byte[] cipherText,
                byte[] key,
                byte[] iv)
            {
                if (cipherText == null || cipherText.Length <= 0)
                    throw new ArgumentNullException("cipherText");
                if (key == null || key.Length <= 0)
                    throw new ArgumentNullException("key");
                if (iv == null || iv.Length <= 0)
                    throw new ArgumentNullException("iv");
                string plaintext = null;
                using (Aes aesAlg = Aes.Create())
                {
                    if (aesAlg == null)
                        throw new Exception();
                    aesAlg.Key = key;
                    aesAlg.IV = iv;
                    var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for decryption.
                    using (var msDecrypt = new MemoryStream(cipherText))
                        using (var csDecrypt = new CryptoStream(msDecrypt
                            , decryptor, CryptoStreamMode.Read))
                            using (var srDecrypt = new StreamReader(csDecrypt))
                                plaintext = srDecrypt.ReadToEnd();
                }
                return plaintext;
            }

            private static byte[] EncryptStringToBytes_Aes(
               string plainText,
               byte[] key,
               byte[] iv)
            {
                if (plainText == null || plainText.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (key == null || key.Length <= 0)
                    throw new ArgumentNullException("key");
                if (iv == null || iv.Length <= 0)
                    throw new ArgumentNullException("key");
                byte[] encrypted;
                using (var aesAlg = Aes.Create())
                {
                    if (aesAlg == null)
                        throw new Exception();
                    aesAlg.Key = key;
                    aesAlg.IV = iv;
                    var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(
                            msEncrypt,
                            encryptor,
                            CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }
                return encrypted;
            }

        }
    }
}
