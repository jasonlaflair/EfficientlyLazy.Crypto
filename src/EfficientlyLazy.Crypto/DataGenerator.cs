using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EfficientlyLazy.Crypto
{
    /// <summary>
    /// Generation of true random data.
    /// This overcomes the limitations of .NET Framework's Random
    /// class, which - when initialized multiple times within a very short
    /// period of time - can generate the same "random" number.
    /// </summary>
    public class DataGenerator
    {
        ///<summary>Characters: abcdefghijklmnopqrstuvwxyz</summary>
        public const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";

        ///<summary>Characters: 0123456789</summary>
        public const string NUMERIC_CHARACTERS = "0123456789";

        ///<summary>Characters: `~!@#$%^&amp;*()-_=+[]{}\\|;:'\",&lt;.&gt;/?</summary>
        public const string SPECIAL_CHARACTERS = "`~!@#$%^&*()-_=+[]{}\\|;:'\",<.>/?";

        ///<summary>Characters: ABCDEFGHIJKLMNOPQRSTUVWXYZ</summary>
        public const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static Random _random;

        private List<char> _characterPool;
        private int _maximum;
        private int _minimum;

        static DataGenerator()
        {
            _random = new Random(GenerateSeedValue());
        }

        ///<summary>
        /// Represents a pseudo-random number generator, a device that produces a sequence of numbers that meet certain statistical requirements for randomness.
        ///</summary>
        ///<param name="minimum">The inclusive lower bound of the random number or string length returned.</param>
        ///<param name="maximum">The exclusive upper bound of the random number or string length returned. maximum must be greater than or equal to minimum.</param>
        ///<exception cref="ArgumentOutOfRangeException">minimum is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">maximum is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">minimum is greater than maximum.</exception>
        public DataGenerator(int minimum, int maximum)
            : this(minimum, maximum, true, true, true, true)
        {
        }

        ///<summary>
        /// Represents a pseudo-random number generator, a device that produces a sequence of numbers that meet certain statistical requirements for randomness.
        ///</summary>
        ///<param name="minimum">The inclusive lower bound of the random number or string length returned.</param>
        ///<param name="maximum">The exclusive upper bound of the random number or string length returned. maximum must be greater than or equal to minimum.</param>
        ///<param name="includeUppercase">Includes the <see cref="UPPERCASE_CHARACTERS"/> in the generated random string</param>
        ///<param name="includeLowercase">Includes the <see cref="LOWERCASE_CHARACTERS"/> in the generated random string</param>
        ///<param name="includeNumbers">Includes the <see cref="NUMERIC_CHARACTERS"/> in the generated random string</param>
        ///<param name="includeSpecials">Includes the <see cref="SPECIAL_CHARACTERS"/> in the generated random string</param>
        ///<exception cref="ArgumentOutOfRangeException">minimum is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">maximum is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">minimum is greater than maximum.</exception>
        public DataGenerator(int minimum, int maximum, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecials)
        {
            if (minimum <= 0)
            {
                throw new ArgumentOutOfRangeException("minimum", minimum, "minimum must be greater than 0");
            }
            if (maximum <= 0)
            {
                throw new ArgumentOutOfRangeException("maximum", maximum, "maximum must be greater than 0");
            }
            if (minimum > maximum)
            {
                throw new ArgumentOutOfRangeException("maximum", "maximum must be greater than or equal to minimum");
            }
            if (!(includeUppercase || includeLowercase || includeNumbers || includeSpecials))
            {
                throw new ArgumentException("at least one character include requirement must be specified");
            }

            _minimum = minimum;
            _maximum = maximum;
            _characterPool = GenerateCharacterPool(includeUppercase, includeLowercase, includeNumbers, includeSpecials);

            _random = new Random(GenerateSeedValue());
        }

        ///<summary>
        /// Sets the lower and upper bound of the random number or string length returned.
        ///</summary>
        ///<param name="minimum">The inclusive lower bound of the random number or string length returned.</param>
        ///<param name="maximum">The exclusive upper bound of the random number or string length returned. maximum must be greater than or equal to minimum.</param>
        ///<exception cref="ArgumentOutOfRangeException">minimum is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">maximum is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">minimum is greater than maximum.</exception>
        public void ResetLengths(int minimum, int maximum)
        {
            if (minimum <= 0)
            {
                throw new ArgumentOutOfRangeException("minimum", minimum, "minimum must be greater than 0");
            }
            if (maximum <= 0)
            {
                throw new ArgumentOutOfRangeException("maximum", maximum, "maximum must be greater than 0");
            }
            if (minimum > maximum)
            {
                throw new ArgumentOutOfRangeException("maximum", "maximum must be greater than or equal to minimum");
            }

            _minimum = minimum;
            _maximum = maximum;
        }

        ///<summary>
        /// Defines the character sets used when generated string values.
        ///</summary>
        ///<param name="includeUppercase">Includes the <see cref="UPPERCASE_CHARACTERS"/> in the generated random string</param>
        ///<param name="includeLowercase">Includes the <see cref="LOWERCASE_CHARACTERS"/> in the generated random string</param>
        ///<param name="includeNumbers">Includes the <see cref="NUMERIC_CHARACTERS"/> in the generated random string</param>
        ///<param name="includeSpecials">Includes the <see cref="SPECIAL_CHARACTERS"/> in the generated random string</param>
        ///<exception cref="ArgumentException">At least one of the 4 character sets must be used.</exception>
        public void ResetCharacterRequirements(bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecials)
        {
            if (!(includeUppercase || includeLowercase || includeNumbers || includeSpecials))
            {
                throw new ArgumentException("at least one character include requirement must be specified");
            }

            _characterPool = GenerateCharacterPool(includeUppercase, includeLowercase, includeNumbers, includeSpecials);
        }

        /// <summary>
        /// Generates a random number within a specified range.
        /// </summary>
        ///<param name="minimum">The inclusive lower bound of the random number returned.</param>
        ///<param name="maximum">The exclusive upper bound of the random number returned. maximum must be greater than or equal to minimum.</param>
        /// <returns>Returns a random number within a specified range.</returns>
        ///<exception cref="ArgumentOutOfRangeException">minimum is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">maximum is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">minimum is greater than maximum.</exception>
        public static int RandomInteger(int minimum, int maximum)
        {
            if (minimum <= 0)
            {
                throw new ArgumentOutOfRangeException("minimum", minimum, "minimum must be greater than 0");
            }
            if (maximum <= 0)
            {
                throw new ArgumentOutOfRangeException("maximum", maximum, "maximum must be greater than 0");
            }
            if (minimum > maximum)
            {
                throw new ArgumentOutOfRangeException("maximum", "maximum must be greater than or equal to minimum");
            }

            return _random.Next(minimum, maximum);
        }

        ///<summary>
        /// Generates a random number within a specified range.
        ///</summary>
        ///<returns>Returns a random number within the configured range.</returns>
        public int NextInteger()
        {
            return _random.Next(_minimum, _maximum);
        }

        /// <summary>
        /// Returns a random number between 0.0 and 1.0.
        /// </summary>
        /// <returns>A double-precision floating point number greater than or equal to 0.0, and less than 1.0.</returns>
        public static double RandomDouble()
        {
            return _random.NextDouble();
        }

        /// <summary>
        /// Returns a random number between 0.0 and 1.0.
        /// </summary>
        /// <returns>A double-precision floating point number greater than or equal to 0.0, and less than 1.0.</returns>
        public double NextDouble()
        {
            return _random.NextDouble();
        }

        ///<summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        ///</summary>
        ///<param name="buffer">An array of bytes to contain random numbers.</param>
        ///<exception cref="ArgumentNullException">buffer is null</exception>
        public static void RandomBytes(byte[] buffer)
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
        /// Fills the elements of a specified array of bytes with random numbers.
        ///</summary>
        ///<param name="buffer">An array of bytes to contain random numbers.</param>
        ///<exception cref="ArgumentNullException">buffer is null</exception>
        public void NextBytes(byte[] buffer)
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
        /// Generates a random string between the specifed lengths using the specified character sets
        ///</summary>
        ///<param name="minimumLength">The inclusive lower length of the random string returned.</param>
        ///<param name="maximumLength">The exclusive upper length of the random string returned. maximumLength must be greater than or equal to minimumLength.</param>
        ///<param name="includeUppercase">Includes the <see cref="UPPERCASE_CHARACTERS"/> in the generated random string</param>
        ///<param name="includeLowercase">Includes the <see cref="LOWERCASE_CHARACTERS"/> in the generated random string</param>
        ///<param name="includeNumbers">Includes the <see cref="NUMERIC_CHARACTERS"/> in the generated random string</param>
        ///<param name="includeSpecials">Includes the <see cref="SPECIAL_CHARACTERS"/> in the generated random string</param>
        ///<returns>Returns a random string between the specifed lengths using the specified character sets</returns>
        ///<exception cref="ArgumentOutOfRangeException">minimumLength is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">maximumLength is less than or equal to 0.</exception>
        ///<exception cref="ArgumentOutOfRangeException">minimumLength is greater than maximumLength.</exception>
        ///<exception cref="ArgumentException">At least one of the 4 character sets must be used.</exception>
        public static string RandomString(int minimumLength, int maximumLength, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecials)
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
            if (!(includeUppercase || includeLowercase || includeNumbers || includeSpecials))
            {
                throw new ArgumentException("at least one character include requirement must be specified");
            }

            List<char> characterPool = GenerateCharacterPool(includeUppercase, includeLowercase, includeNumbers, includeSpecials);

            return RandomString(characterPool, minimumLength, maximumLength);
        }

        ///<summary>
        /// Generates a random string between the specifed lengths using the specified character sets
        ///</summary>
        ///<returns>Returns a random string between the specifed lengths using the specified character sets</returns>
        public string NextString()
        {
            return RandomString(_characterPool, _minimum, _maximum);
        }

        private static string RandomString(IList<char> characterPool, int minimumLength, int maximumLength)
        {
            int length = _random.Next(minimumLength, maximumLength);

            StringBuilder data = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                char randomChar = characterPool[_random.Next(0, characterPool.Count - 1)];
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

            int seed = ((randomBytes[0] & 0x7f) << 24) | (randomBytes[1] << 16) | (randomBytes[2] << 8) | (randomBytes[3]);

            return seed;
        }

        private static List<char> GenerateCharacterPool(bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecials)
        {
            List<char> masterCharacterPool = new List<char>();

            if (includeUppercase)
            {
                masterCharacterPool.AddRange(UPPERCASE_CHARACTERS);
            }
            if (includeLowercase)
            {
                masterCharacterPool.AddRange(LOWERCASE_CHARACTERS);
            }
            if (includeNumbers)
            {
                masterCharacterPool.AddRange(NUMERIC_CHARACTERS);
            }
            if (includeSpecials)
            {
                masterCharacterPool.AddRange(SPECIAL_CHARACTERS);
            }

            // randomize masterCharacterPool
            for (int randomPasses = 0; randomPasses <= 4; randomPasses++)
            {
                for (int idx = masterCharacterPool.Count - 1; idx > 0; --idx)
                {
                    int tempPosition = _random.Next(idx);
                    char tempChar = masterCharacterPool[idx];
                    masterCharacterPool[idx] = masterCharacterPool[tempPosition];
                    masterCharacterPool[tempPosition] = tempChar;
                }
            }

            return masterCharacterPool;
        }
    }
}