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
            return DataGenerator.NextString(min, max, CharacterSets.All);
        }

        protected static string GenerateClearText()
        {
            return DataGenerator.NextString(50, 300, CharacterSets.All);
        }

        protected static string GeneratePassPhrase()
        {
            return DataGenerator.NextString(100, 500, CharacterSets.All);
        }

        protected static string GenerateRandomSalt()
        {
            return DataGenerator.NextString(50, 250, CharacterSets.All);
        }

        protected static string GenerateInitVector()
        {
            return DataGenerator.NextString(16, 16, CharacterSets.All);
        }
    }
}