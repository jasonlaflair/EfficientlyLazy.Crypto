using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

namespace EfficientlyLazy.Crypto
{
    /// <summary>
    /// Character sets to use in string generation
    /// </summary>
    [Flags]
    public enum CharacterSets
    {
        ///<summary>Characters: none</summary>
        None = 0,
        ///<summary>Characters: ABCDEFGHIJKLMNOPQRSTUVWXYZ</summary>
        Uppercase = 1,
        ///<summary>Characters: abcdefghijklmnopqrstuvwxyz</summary>
        Lowercase = 2,
        ///<summary>Characters: 0123456789</summary>
        Numeric = 4,
        ///<summary>Characters: `~!@#$%^&amp;*()-_=+[]{}\\|;:'\",&lt;.&gt;/?</summary>
        Special = 8,
        ///<summary>Characters: All character sets; <see cref="Uppercase"/> <see cref="Lowercase"/> <see cref="Numeric"/> <see cref="Special"/></summary>
        All = Uppercase | Lowercase | Numeric | Special
    }

    /// <summary>
    /// Generation of true random data.
    /// This overcomes the limitations of .NET Framework's Random
    /// class, which - when initialized multiple times within a very short
    /// period of time - can generate the same "random" number.
    /// </summary>
    public static class DataGenerator
    {
        ///<summary>Characters: abcdefghijklmnopqrstuvwxyz</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2211:NonConstantFieldsShouldNotBeVisible")]
        public static ReadOnlyCollection<char> LowercaseCharacters = new ReadOnlyCollection<char>(new[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            });

        ///<summary>Characters: 0123456789</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2211:NonConstantFieldsShouldNotBeVisible")]
        public static ReadOnlyCollection<char> NumericCharacters = new ReadOnlyCollection<char>(new[]
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            });

        ///<summary>Characters: `~!@#$%^&amp;*()-_=+[]{}\\|;:'\",&lt;.&gt;/?</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2211:NonConstantFieldsShouldNotBeVisible")]
        public static ReadOnlyCollection<char> SpecialCharacters = new ReadOnlyCollection<char>(new[]
            {
                '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', ']', '{', '}', '\\', '|', ';', ':', '\'', '"', ',', '<', '.', '>', '/', '?'
            });

        ///<summary>Characters: `~!@#$%^&amp;*()-_=+[]{}\\|;:'\",&lt;.&gt;/?</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2211:NonConstantFieldsShouldNotBeVisible")]
        public static ReadOnlyCollection<char> UppercaseCharacters = new ReadOnlyCollection<char>(new[]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            });

        private static readonly Random _random;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static DataGenerator()
        {
            _random = new Random(GenerateSeedValue());

            _defaultCharacterPool = GenerateCharacterPool(CharacterSets.All);
        }

        private static readonly ReadOnlyCollection<char> _defaultCharacterPool;

        /// <summary>
        /// Generates a random number within a specified range.
        /// </summary>
        ///<param name="minimumValue">The inclusive lower bound of the random number returned.</param>
        ///<param name="maximumValue">The exclusive upper bound of the random number returned. maximumValue must be greater than or equal to minimumValue.</param>
        /// <returns>Returns a random number within a specified range.</returns>
        ///<exception cref="ArgumentOutOfRangeException">minimumValue is greater than maximumValue.</exception>
        public static int NextInteger(int minimumValue, int maximumValue)
        {
            if (minimumValue > maximumValue)
            {
                throw new ArgumentOutOfRangeException("maximumValue", "maximumValue must be greater than or equal to minimumValue");
            }

            return _random.Next(minimumValue, maximumValue);
        }

        ///<summary>
        /// Generates a nonnegative random number.
        ///</summary>
        ///<returns>Returns a nonnegative random number.</returns>
        public static int NextInteger()
        {
            return _random.Next();
        }

        /// <summary>
        /// Generates a random number between 0.0 and 1.0.
        /// </summary>
        /// <returns>Returns a random number between 0.0 and 1.0.</returns>
        public static double NextDouble()
        {
            return _random.NextDouble();
        }

        ///<summary>
        /// Fills the elements of a specified array of bytes with random bytes.
        ///</summary>
        ///<param name="buffer">An array of bytes to contain random numbers.</param>
        ///<exception cref="ArgumentNullException">buffer is null</exception>
        ///<exception cref="ArgumentOutOfRangeException">buffer length is 0</exception>
        public static void Bytes(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer", "buffer cannot be null");
            }
            if (buffer.Length == 0)
            {
                throw new ArgumentOutOfRangeException("buffer", "buffer length cannot be 0");
            }

            _random.NextBytes(buffer);
        }

        ///<summary>
        /// Fills the elements of an array of bytes with random numbers.
        ///</summary>
        ///<param name="minimumLength">The inclusive lower bound of the byte array length returned.</param>
        ///<param name="maximumLength">The exclusive upper bound of the byte array length returned. maximumLength must be greater than or equal to minimumLength.</param>
        ///<returns>Returns byte array between specified lengths, filled with random bytes.</returns>
        ///<exception cref="ArgumentOutOfRangeException">minimumLength is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">maximumLength is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">minimumLength is greater than maximumLength.</exception>
        public static byte[] Bytes(int minimumLength, int maximumLength)
        {
            if (minimumLength <= 0)
            {
                throw new ArgumentOutOfRangeException("minimumLength", minimumLength, "minimumLength must be greater than 0");
            }
            if (maximumLength <= 0)
            {
                throw new ArgumentOutOfRangeException("maximumLength", maximumLength, "maximumLength must be greater than 0");
            }
            if (minimumLength > maximumLength)
            {
                throw new ArgumentOutOfRangeException("maximumLength", "maximumLength must be greater than or equal to minimumLength");
            }

            var length = _random.Next(minimumLength, maximumLength);

            var buffer = new byte[length];

            _random.NextBytes(buffer);

            return buffer;
        }

        ///<summary>
        /// Fills the elements of an array of bytes with random numbers.
        ///</summary>
        ///<param name="length">The array length returned.</param>
        ///<returns>Returns byte array with length specified filled with random bytes.</returns>
        ///<exception cref="ArgumentOutOfRangeException">length is less than or equal to 0.</exception>
        public static byte[] Bytes(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException("length", length, "length must be greater than 0");
            }

            var buffer = new byte[length];

            _random.NextBytes(buffer);

            return buffer;
        }

        ///<summary>
        /// Generates a random string between the specifed lengths using the specified character sets
        ///</summary>
        ///<param name="minimumValue">The inclusive lower length of the random string returned.</param>
        ///<param name="maximumValue">The exclusive upper length of the random string returned. maximumValue must be greater than or equal to minimumValue.</param>
        ///<param name="characterSets">Includes the <see cref="CharacterSets"/> to use in the generated random string</param>
        ///<returns>Returns a random string between the specifed lengths using the specified character sets</returns>
        ///<exception cref="ArgumentOutOfRangeException">minimumValue is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">maximumValue is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">minimumValue is greater than maximumValue.</exception>
        ///<exception cref="ArgumentException">At least one character sets must be used.</exception>
        public static string NextString(int minimumValue, int maximumValue, CharacterSets characterSets)
        {
            if (minimumValue <= 0)
            {
                throw new ArgumentOutOfRangeException("minimumValue", minimumValue, "minimumValue must be greater than 0");
            }
            if (maximumValue <= 0)
            {
                throw new ArgumentOutOfRangeException("maximumValue", maximumValue, "maximumValue must be greater than 0");
            }
            if (minimumValue > maximumValue)
            {
                throw new ArgumentOutOfRangeException("maximumValue", "maximumValue must be greater than or equal to minimumValue");
            }
            if (!(IncludeSet(CharacterSets.Uppercase, characterSets) || IncludeSet(CharacterSets.Lowercase, characterSets) || IncludeSet(CharacterSets.Numeric, characterSets) || IncludeSet(CharacterSets.Special, characterSets)))
            {
                throw new ArgumentException("at least one character set must be specified");
            }

            var characterPool = GenerateCharacterPool(characterSets);

            return RandomString(characterPool, minimumValue, maximumValue);
        }

        ///<summary>
        /// Generates a random string between the specifed lengths using the specified character list
        ///</summary>
        ///<param name="minimumLength">The inclusive lower length of the random string returned.</param>
        ///<param name="maximumLength">The exclusive upper length of the random string returned. maximumLength must be greater than or equal to minimumLength.</param>
        ///<param name="characterList">List of characters to use when generating random strings.</param>
        ///<returns>Returns a random string between the specifed lengths using the specified character list</returns>
        ///<exception cref="ArgumentOutOfRangeException">minimumValue is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">maximumValue is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">minimumValue is greater than maximumValue.</exception>
        ///<exception cref="ArgumentException">At least one character must be specified</exception>
        public static string NextString(int minimumLength, int maximumLength, IList<char> characterList)
        {
            if (minimumLength <= 0)
            {
                throw new ArgumentOutOfRangeException("minimumLength", minimumLength, "minimumLength must be greater than 0");
            }
            if (maximumLength <= 0)
            {
                throw new ArgumentOutOfRangeException("maximumLength", maximumLength, "maximumLength must be greater than 0");
            }
            if (minimumLength > maximumLength)
            {
                throw new ArgumentOutOfRangeException("maximumLength", "maximumLength must be greater than or equal to minimumLength");
            }
            if (characterList.Count == 0)
            {
                throw new ArgumentException("At least one character must be specified");
            }

            var characterPool = RandomizeCharacterPool(characterList);

            return RandomString(characterPool, minimumLength, maximumLength);
        }

        ///<summary>
        /// Generates a random string between the specifed default lengths using the specified default character sets
        ///</summary>
        ///<returns>Returns a random string between the specifed default lengths using the specified default character sets</returns>
        public static string NextString(int minimumLength, int maximumLength)
        {
            return RandomString(_defaultCharacterPool, minimumLength, maximumLength);
        }

        ///<summary>
        /// Generates a random string between the specifed default lengths using the specified default character sets
        ///</summary>
        ///<returns>Returns a random string between the specifed default lengths using the specified default character sets</returns>
        public static string NextString()
        {
            return NextString(32, 4096);
        }

        private static string RandomString(IList<char> characterPool, int minimumValue, int maximumValue)
        {
            var length = _random.Next(minimumValue, maximumValue);

            var data = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var randomChar = characterPool[_random.Next(0, characterPool.Count - 1)];
                data.Append(randomChar);
            }

            return data.ToString();
        }

        private static int GenerateSeedValue()
        {
            // We will make up an integer seed from 4 bytes of this array.
            var randomBytes = new byte[4];

            // Generate 4 random bytes.
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            var seed = ((randomBytes[0] & 0x7f) << 24) | (randomBytes[1] << 16) | (randomBytes[2] << 8) | (randomBytes[3]);

            return seed;
        }

        private static bool IncludeSet(CharacterSets option, CharacterSets current)
        {
            return current == (current | option);
        }

        private static ReadOnlyCollection<char> GenerateCharacterPool(CharacterSets characterSets)
        {
            var masterCharacterPool = new List<char>();

            if (IncludeSet(CharacterSets.Uppercase, characterSets))
            {
                masterCharacterPool.AddRange(UppercaseCharacters);
            }
            if (IncludeSet(CharacterSets.Lowercase, characterSets))
            {
                masterCharacterPool.AddRange(LowercaseCharacters);
            }
            if (IncludeSet(CharacterSets.Numeric, characterSets))
            {
                masterCharacterPool.AddRange(NumericCharacters);
            }
            if (IncludeSet(CharacterSets.Special, characterSets))
            {
                masterCharacterPool.AddRange(SpecialCharacters);
            }

            return RandomizeCharacterPool(masterCharacterPool);
        }

        private static ReadOnlyCollection<char> RandomizeCharacterPool(IEnumerable<char> charList)
        {
            var newList = new List<char>(charList);

            for (var randomPasses = 0; randomPasses <= 4; randomPasses++)
            {
                for (var idx = newList.Count - 1; idx > 0; --idx)
                {
                    var tempPosition = _random.Next(idx);
                    var tempChar = newList[idx];
                    newList[idx] = newList[tempPosition];
                    newList[tempPosition] = tempChar;
                }
            }

            return new ReadOnlyCollection<char>(newList);
        }
    }
}