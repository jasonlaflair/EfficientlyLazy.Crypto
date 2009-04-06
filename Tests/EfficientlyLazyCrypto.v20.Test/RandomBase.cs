using System.Security;

namespace EfficientlyLazyCrypto.Test
{
    public class RandomBase
    {
        public enum Encodings
        {
            None,
            ASCII,
            Unicode,
            UTF32,
            UTF7,
            UTF8
        }

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
            return DataGenerator.RandomString(min, max, true, true, true, true);
        }

        protected static string GenerateClearText()
        {
            return DataGenerator.RandomString(50, 300, true, true, true, true);
        }

        protected static string GeneratePassPhrase()
        {
            return DataGenerator.RandomString(100, 500, true, true, true, true);
        }

        protected static string GenerateRandomSalt()
        {
            return DataGenerator.RandomString(50, 250, true, true, true, true);
        }

        protected static string GenerateInitVector()
        {
            return DataGenerator.RandomString(16, 16, true, true, true, true);
        }
    }
}
