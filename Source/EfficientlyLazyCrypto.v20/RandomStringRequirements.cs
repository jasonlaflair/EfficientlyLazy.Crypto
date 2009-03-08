using System;
using System.Collections.Generic;

namespace EfficientlyLazyCrypto
{
    ///<summary>
    ///</summary>
    public class RandomStringRequirements
    {
        ///<summary>
        ///</summary>
        public int MinimumLength { get; private set; }
        ///<summary>
        ///</summary>
        public int MaximumLength { get; private set; }
        ///<summary>
        ///</summary>
        public List<CharacterSet> CharacterSets { get; private set; }

        ///<summary>
        ///</summary>
        ///<param name="minimumLength"></param>
        ///<param name="maximumLength"></param>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        ///<exception cref="ArgumentException"></exception>
        public RandomStringRequirements(int minimumLength, int maximumLength)
        {
            if (minimumLength <= 0)
            {
                throw new ArgumentOutOfRangeException("minimumLength", minimumLength, "minimumLength can NOT be less than or equal to 0");
            }
            if (maximumLength <= 0)
            {
                throw new ArgumentOutOfRangeException("maximumLength", maximumLength, "maximumLength can NOT be less than or equal to 0");
            }
            if (minimumLength > maximumLength)
            {
                throw new ArgumentException("minimumLength can NOT be greater than maximumLength");
            }

            MinimumLength = minimumLength;
            MaximumLength = maximumLength;
            CharacterSets = new List<CharacterSet>();
        }

        ///<summary>
        ///</summary>
        ///<param name="minimumLength"></param>
        ///<param name="maximumLength"></param>
        ///<returns></returns>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        ///<exception cref="ArgumentException"></exception>
        public RandomStringRequirements ChangeLength(int minimumLength, int maximumLength)
        {
            if (minimumLength <= 0)
            {
                throw new ArgumentOutOfRangeException("minimumLength", minimumLength, "minimumLength can NOT be less than or equal to 0");
            }
            if (maximumLength <= 0)
            {
                throw new ArgumentOutOfRangeException("maximumLength", maximumLength, "maximumLength can NOT be less than or equal to 0");
            }
            if (minimumLength > maximumLength)
            {
                throw new ArgumentException("minimumLength can NOT be greater than maximumLength");
            }

            MinimumLength = minimumLength;
            MaximumLength = maximumLength;

            return this;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public RandomStringRequirements ClearCharacterSets()
        {
            CharacterSets = new List<CharacterSet>();

            return this;
        }

        ///<summary>
        ///</summary>
        ///<param name="characterSet"></param>
        ///<returns></returns>
        public RandomStringRequirements AddCharacterSet(CharacterSet characterSet)
        {
            CharacterSets.Add(characterSet);

            return this;
        }
    }
}
