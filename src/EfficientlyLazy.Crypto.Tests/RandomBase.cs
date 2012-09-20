using System.Security;

namespace EfficientlyLazy.Crypto.Tests
{

    public class RandomBase
    {
        #region Encodings enum

        public enum Encodings
        {
            None,
            ASCII,
            Unicode,
            UTF32,
            UTF7,
            UTF8
        }

        #endregion

        protected static SecureString ToSS(string value)
        {
            SecureString ss = new SecureString();
            foreach (char ch in value)
            {
                ss.AppendChar(ch);
            }

            return ss;
        }

        protected static string GenerateText(int min, int max)
        {
            return DataGenerator.String(min, max, CharacterSet.All);
        }

        protected static string GenerateClearText()
        {
            return DataGenerator.String(50, 300, CharacterSet.All);
        }

        protected static string GeneratePassPhrase()
        {
            return DataGenerator.String(100, 500, CharacterSet.All);
        }

        protected static string GenerateRandomSalt()
        {
            return DataGenerator.String(50, 250, CharacterSet.All);
        }

        protected static string GenerateInitVector()
        {
            return DataGenerator.String(16, 16, CharacterSet.All);
        }
    }
}