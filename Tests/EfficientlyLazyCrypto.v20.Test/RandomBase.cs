using System;
using System.Collections.Generic;
using System.Text;

namespace EfficientlyLazyCrypto.Test
{
    public class RandomBase
    {
        protected static string GenerateClearText()
        {
            return DataGeneration.RandomString(new RandomStringRequirements(50, 300)
                .AddCharacterSet(CharacterSet.AllLowercase())
                .AddCharacterSet(CharacterSet.AllNumeric())
                .AddCharacterSet(CharacterSet.AllSpecial())
                .AddCharacterSet(CharacterSet.AllUppercase()));
        }

        protected static string GeneratePassPhrase()
        {
            return DataGeneration.RandomString(new RandomStringRequirements(100, 500)
                .AddCharacterSet(CharacterSet.AllLowercase())
                .AddCharacterSet(CharacterSet.AllNumeric())
                .AddCharacterSet(CharacterSet.AllSpecial())
                .AddCharacterSet(CharacterSet.AllUppercase()));
        }

        protected static string GenerateRandomSalt()
        {
            return DataGeneration.RandomString(new RandomStringRequirements(50, 250)
                .AddCharacterSet(CharacterSet.AllLowercase())
                .AddCharacterSet(CharacterSet.AllNumeric())
                .AddCharacterSet(CharacterSet.AllSpecial())
                .AddCharacterSet(CharacterSet.AllUppercase()));
        }

        protected static string GenerateInitVector()
        {
            return DataGeneration.RandomString(new RandomStringRequirements(16, 16)
                .AddCharacterSet(CharacterSet.AllLowercase())
                .AddCharacterSet(CharacterSet.AllNumeric())
                .AddCharacterSet(CharacterSet.AllSpecial())
                .AddCharacterSet(CharacterSet.AllUppercase()));
        }
    }
}
