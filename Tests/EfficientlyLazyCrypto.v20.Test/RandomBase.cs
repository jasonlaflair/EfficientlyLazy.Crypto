using System;
using System.Collections.Generic;
using System.Text;

namespace EfficientlyLazyCrypto.Test
{
    public class RandomBase
    {
        protected static string GenerateClearText()
        {
            return DataGenerator.String(50, 300, true, true, true, true);
        }

        protected static string GeneratePassPhrase()
        {
            return DataGenerator.String(100, 500, true, true, true, true);
        }

        protected static string GenerateRandomSalt()
        {
            return DataGenerator.String(50, 250, true, true, true, true);
        }

        protected static string GenerateInitVector()
        {
            return DataGenerator.String(16, 16, true, true, true, true);
        }
    }
}
