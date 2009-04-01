using System;
using System.Collections.Generic;
using System.Text;

namespace EfficientlyLazyCrypto.Test
{
    public class RandomBase
    {
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
