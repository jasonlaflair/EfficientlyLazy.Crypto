using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EfficientlyLazyCrypto
{
    /// <summary>
    /// Generation of true random data.
    /// </summary>
    public class DataGenerator
    {
        private static Random _random;

        public const string _uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string _lowercase = "abcdefghijklmnopqrstuvwxyz";
        public const string _numbers = "0123456789";
        public const string _specials = "`~!@#$%^&*()-_=+[]{}\\|;:'\",<.>/?";

        private int _minimum;
        private int _maximum;
        private List<char> _characterPool;

        ///<summary>
        ///</summary>
        ///<param name="minimum"></param>
        ///<param name="maximum"></param>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        public DataGenerator(int minimum, int maximum)
            : this(minimum, maximum, false, false, false, false)
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="minimum"></param>
        ///<param name="maximum"></param>
        ///<param name="includeUppercase"></param>
        ///<param name="includeLowercase"></param>
        ///<param name="includeNumbers"></param>
        ///<param name="includeSpecials"></param>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        public DataGenerator(int minimum, int maximum, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecials)
        {
            if (minimum <= 0)
            {
                throw new ArgumentOutOfRangeException("minimum", "minimum must be greater than 0");
            }
            if (maximum <= 0)
            {
                throw new ArgumentOutOfRangeException("maximum", "maximum must be greater than 0");
            }
            if (minimum > maximum)
            {
                throw new ArgumentOutOfRangeException("maximum", "maximum must be greater than or equal to minimum");
            }

            _minimum = minimum;
            _maximum = maximum;
            _characterPool = GenerateCharacterPool(includeUppercase, includeLowercase, includeNumbers, includeSpecials);

            _random = new Random(GenerateSeedValue());
        }

        ///<summary>
        ///</summary>
        ///<param name="minimum"></param>
        ///<param name="maximum"></param>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        public void ResetLengths(int minimum, int maximum)
        {
            if (minimum <= 0)
            {
                throw new ArgumentOutOfRangeException("minimum", "minimum must be greater than 0");
            }
            if (maximum <= 0)
            {
                throw new ArgumentOutOfRangeException("maximum", "maximum must be greater than 0");
            }
            if (minimum > maximum)
            {
                throw new ArgumentOutOfRangeException("maximum", "maximum must be greater than or equal to minimum");
            }

            _minimum = minimum;
            _maximum = maximum;
        }

        ///<summary>
        ///</summary>
        ///<param name="includeUppercase"></param>
        ///<param name="includeLowercase"></param>
        ///<param name="includeNumbers"></param>
        ///<param name="includeSpecials"></param>
        ///<exception cref="ArgumentException"></exception>
        public void ResetCharacterRequirements(bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecials)
        {
            if (!(includeUppercase || includeLowercase || includeNumbers || includeSpecials))
            {
                throw new ArgumentException("at least one character include requirement must be specified");
            }

            _characterPool = GenerateCharacterPool(includeUppercase, includeLowercase, includeNumbers, includeSpecials);
        }

        static DataGenerator()
        {
            _random = new Random(GenerateSeedValue());
        }

        /// <summary>
        /// Generates a random <see cref="int"/>.
        /// </summary>
        /// <param name="minimumValue">Minimum value (inclusive).</param>
        /// <param name="maximumValue">Maximum value (inclusive).</param>
        /// <returns>Random <see cref="int"/> value between the <paramref name="minimumValue"/> and <paramref name="maximumValue"/> (inclusive).</returns>
        /// <remarks>
        /// This methods overcomes the limitations of .NET Framework's Random
        /// class, which - when initialized multiple times within a very short
        /// period of time - can generate the same "random" number.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><c>maxValue</c> is out of range.</exception>
        public static int Integer(int minimumValue, int maximumValue)
        {
            if (minimumValue <= 0)
            {
                throw new ArgumentOutOfRangeException("minimumValue", "minimumValue must be greater than 0");
            }
            if (maximumValue <= 0)
            {
                throw new ArgumentOutOfRangeException("maximumValue", "maximumValue must be greater than 0");
            }
            if (minimumValue > maximumValue)
            {
                throw new ArgumentOutOfRangeException("maximumValue", "maximumValue must be greater than or equal to minimumValue");
            }

            return _random.Next(minimumValue, maximumValue);
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public int Integer()
        {
            return _random.Next(_minimum, _maximum);
        }

        ///<summary>
        ///</summary>
        ///<param name="minimumLength"></param>
        ///<param name="maximumLength"></param>
        ///<param name="includeUppercase"></param>
        ///<param name="includeLowercase"></param>
        ///<param name="includeNumbers"></param>
        ///<param name="includeSpecials"></param>
        ///<returns></returns>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        ///<exception cref="ArgumentException"></exception>
        public static string String(int minimumLength, int maximumLength, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecials)
        {
            if (minimumLength <= 0)
            {
                throw new ArgumentOutOfRangeException("minimumLength", "minimumLength must be greater than 0");
            }
            if (maximumLength <= 0)
            {
                throw new ArgumentOutOfRangeException("maximumLength", "maximumLength must be greater than 0");
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

            return GenerateString(characterPool, minimumLength, maximumLength);
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public string String()
        {
            return GenerateString(_characterPool, _minimum, _maximum);
        }

        private static string GenerateString(IList<char> characterPool, int minimumLength, int maximumLength)
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

            if (includeUppercase) masterCharacterPool.AddRange(_uppercase);
            if (includeLowercase) masterCharacterPool.AddRange(_lowercase);
            if (includeNumbers) masterCharacterPool.AddRange(_numbers);
            if (includeSpecials) masterCharacterPool.AddRange(_specials);

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