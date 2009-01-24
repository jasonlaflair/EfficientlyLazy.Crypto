using System.Collections.Generic;

namespace EfficientlyLazyCrypto
{
    /// <summary>CharacterSet for use in DataGeneration</summary>
    public struct CharacterSet
    {
        ///<summary>
        ///</summary>
        public List<char> Characters { get; private set; }

        ///<summary>
        /// When used for <see href="DataGeneration">Data Generation</see> indicates the minimum number of characters required from this CharacterSet.
        ///</summary>
        public int MinimumRequired { get; private set; }

        ///<summary>
        ///</summary>
        ///<param name="characters"></param>
        public CharacterSet(List<char> characters)
            : this(characters, 0)
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="characters"></param>
        public CharacterSet(string characters)
            : this(characters, 0)
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="characters"></param>
        ///<param name="minimumCharactersRequired"></param>
        public CharacterSet(List<char> characters, int minimumCharactersRequired)
            : this()
        {
            Characters = characters;
            MinimumRequired = minimumCharactersRequired;
        }

        ///<summary>
        ///</summary>
        ///<param name="characters"></param>
        ///<param name="minimumCharactersRequired"></param>
        public CharacterSet(string characters, int minimumCharactersRequired)
            : this()
        {
            Characters = new List<char>(characters.ToCharArray());
            MinimumRequired = minimumCharactersRequired;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static CharacterSet AllUppercase()
        {
            return AllUppercase(0);
        }

        ///<summary>
        ///</summary>
        ///<param name="minimumCharactersRequired"></param>
        ///<returns></returns>
        public static CharacterSet AllUppercase(int minimumCharactersRequired)
        {
            return new CharacterSet
                       {
                           Characters = new List<char>("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()),
                           MinimumRequired = minimumCharactersRequired
                       };
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static CharacterSet AllLowercase()
        {
            return AllLowercase(0);
        }

        ///<summary>
        ///</summary>
        ///<param name="minimumCharactersRequired"></param>
        ///<returns></returns>
        public static CharacterSet AllLowercase(int minimumCharactersRequired)
        {
            return new CharacterSet
                       {
                           Characters = new List<char>("abcdefghijklmnopqrstuvwxyz".ToCharArray()),
                           MinimumRequired = minimumCharactersRequired
                       };
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static CharacterSet AllNumeric()
        {
            return AllNumeric(0);
        }

        ///<summary>
        ///</summary>
        ///<param name="minimumCharactersRequired"></param>
        ///<returns></returns>
        public static CharacterSet AllNumeric(int minimumCharactersRequired)
        {
            return new CharacterSet
                       {
                           Characters = new List<char>("0123456789".ToCharArray()),
                           MinimumRequired = minimumCharactersRequired
                       };
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static CharacterSet AllSpecial()
        {
            return AllSpecial(0);
        }

        ///<summary>
        ///</summary>
        ///<param name="minimumCharactersRequired"></param>
        ///<returns></returns>
        public static CharacterSet AllSpecial(int minimumCharactersRequired)
        {
            return new CharacterSet
                       {
                           Characters = new List<char>("`~!@#$%^&*()-_=+[]{}\\|;:'\",<.>/?".ToCharArray()),
                           MinimumRequired = minimumCharactersRequired
                       };
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static CharacterSet Empty()
        {
            return new CharacterSet
                       {
                           Characters = new List<char>(),
                           MinimumRequired = 0
                       };
        }
    }
}
