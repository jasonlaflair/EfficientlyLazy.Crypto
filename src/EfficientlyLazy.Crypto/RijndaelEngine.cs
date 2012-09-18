using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using EfficientlyLazy.Crypto.Configuration;

namespace EfficientlyLazy.Crypto
{
    /// <summary>
    /// Encryption/Decryption using <see cref="RijndaelManaged"/>.
    /// </summary>
    public sealed class RijndaelEngine : ICryptoEngine
    {
        private ICryptoTransform _decryptor;
        private ICryptoTransform _encryptor;

        ///<summary>
        /// Initializes a new instance of the <see cref="RijndaelEngine"/> object.
        ///</summary>
        ///<param name="key">Represents the secret key for the algorithm</param>
        public RijndaelEngine(string key)
        {
            Key = ToSecureString(key);
            InitVector = ToSecureString(string.Empty);
            RandomSaltMinimumLength = 0;
            RandomSaltMaximumLength = 0;
            Salt = ToSecureString(string.Empty);
            KeySize = KeySize.Key256Bit;
            PasswordIterations = 10;
            Encoding = Encoding.Default;

            GenerateEngine();
        }

        ///<summary>
        /// Initializes a new instance of the <see cref="RijndaelEngine"/> object.
        ///</summary>
        ///<param name="key">Represents the secret key for the algorithm</param>
        public RijndaelEngine(SecureString key)
        {
            key.MakeReadOnly();

            Key = key;
            InitVector = ToSecureString(string.Empty);
            RandomSaltMinimumLength = 0;
            RandomSaltMaximumLength = 0;
            Salt = ToSecureString(string.Empty);
            KeySize = KeySize.Key256Bit;
            PasswordIterations = 10;
            Encoding = Encoding.Default;

            GenerateEngine();
        }

        ///<summary>
        /// Represents the secret key for the algorithm
        ///</summary>
        public SecureString Key { get; private set; }

        ///<summary>
        /// Represents the initialization vector (IV) for the algorithm
        ///</summary>
        public SecureString InitVector { get; private set; }

        ///<summary>
        /// Minimum length of the random salt used in encryption/decryption.  If 0, no random salt will be used.
        ///</summary>
        public int RandomSaltMinimumLength { get; private set; }

        ///<summary>
        /// Maximum length of the random salt used in encryption/decryption.  If 0, no random salt will be used.
        ///</summary>
        public int RandomSaltMaximumLength { get; private set; }

        ///<summary>
        /// Key salt used to derive the key
        ///</summary>
        public SecureString Salt { get; private set; }

        ///<summary>
        /// Represents the size, in bits, of the secret key used by the algorithm
        ///</summary>
        public KeySize KeySize { get; private set; }

        ///<summary>
        /// The number of iterations for the operation
        ///</summary>
        public int PasswordIterations { get; private set; }

        ///<summary>
        /// Represents the character encoding
        ///</summary>
        public Encoding Encoding { get; private set; }

        /// <summary>
        /// Used in old key generation using the now Obsolite PasswordDeriveBytes
        /// </summary>
        public string HashAlgorithm { get; private set; }

        #region ICryptoEngine Members

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] plaintext)
        {
            // byte array for encrypted data
            byte[] cipherTextBytes;

            // Let's make cryptographic operations thread-safe.
            lock (_encryptor)
            {
                try
                {
                    // Add salt at the beginning of the plain text bytes (if needed).
                    var plainTextBytesWithSalt = AddSalt(plaintext);

                    using (var memoryStream = new MemoryStream())
                    {
                        // To perform encryption, we must use the Write mode.
                        using (var cryptoStream = new CryptoStream(memoryStream, _encryptor, CryptoStreamMode.Write))
                        {
                            // Start encrypting data.
                            cryptoStream.Write(plainTextBytesWithSalt, 0, plainTextBytesWithSalt.Length);

                            // Finish the encryption operation.
                            cryptoStream.FlushFinalBlock();
                        }

                        // Move encrypted data from memory into a byte array.
                        cipherTextBytes = memoryStream.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    throw new CryptographicException("Unable to Encrypt requested data", ex);
                }
            }

            // Return encrypted data.
            return cipherTextBytes;
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        public string Encrypt(string plaintext)
        {
            return Convert.ToBase64String(Encrypt(Encoding.GetBytes(plaintext)));
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] cipherText)
        {
            byte[] plainTextBytes;

            // Let's make cryptographic operations thread-safe.
            lock (_decryptor)
            {
                try
                {
                    // Since we do not know how big decrypted value will be, use the same
                    // size as cipher text. Cipher text is always longer than plain text
                    // (in block cipher encryption), so we will just use the number of
                    // decrypted data byte after we know how big it is.
                    var decryptedBytes = new byte[cipherText.Length];

                    int decryptedByteCount;

                    using (var ms = new MemoryStream(cipherText))
                    {
                        // To perform decryption, we must use the Read mode.
                        using (var cs = new CryptoStream(ms, _decryptor, CryptoStreamMode.Read))
                        {
                            decryptedByteCount = cs.Read(decryptedBytes, 0, decryptedBytes.Length);
                        }
                    }

                    var saltLen = 0;

                    // If we are using salt, get its length from the first 4 bytes of plain text data.
                    if (RandomSaltMaximumLength > 0 && RandomSaltMaximumLength >= RandomSaltMinimumLength)
                    {
                        saltLen = (decryptedBytes[0] & 0x03) | (decryptedBytes[1] & 0x0c) | (decryptedBytes[2] & 0x30) |
                                  (decryptedBytes[3] & 0xc0);
                    }

                    // Allocate the byte array to hold the original plain text (without salt).
                    plainTextBytes = new byte[decryptedByteCount - saltLen];

                    // Copy original plain text discarding the salt value if needed.
                    Array.Copy(decryptedBytes, saltLen, plainTextBytes, 0, decryptedByteCount - saltLen);
                }
                catch (Exception ex)
                {
                    throw new CryptographicException("Unable to decrypt requested data", ex);
                }
            }

            // Return original plain text value.
            return plainTextBytes;
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public string Decrypt(string cipherText)
        {
            return Encoding.GetString(Decrypt(Convert.FromBase64String(cipherText)));
        }

        private static SecureSection GetSecureConfigSection()
        {
            ConfigurationManager.RefreshSection("SecureConfig");
            return (SecureSection)ConfigurationManager.GetSection("SecureConfig");
        }

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        ///<returns></returns>
        public string GetSetting(string key)
        {
            var config = GetSecureConfigSection();

            if (config == null)
            {
                return string.Empty;
            }

            var setting = config.Settings[key];

            if (setting == null)
            {
                return string.Empty;
            }

            return setting.IsEncrypted ? Decrypt(setting.Value) : setting.Value;
        }

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        ///<returns></returns>
        public SqlConnectionStringBuilder GetSqlConnectionString(string key)
        {
            var config = GetSecureConfigSection();

            if (config == null)
            {
                return null;
            }

            var conn = config.SqlConnectionStrings[key];

            return conn == null ? null : conn.GetBuilder(this);
        }

        #endregion

        #region Rijndael Helper functions

        /// <summary>
        /// Adds an array of randomly generated bytes at the beginning of the
        /// array holding original plain text value.
        /// </summary>
        /// <param name="plainTextBytes">
        /// Byte array containing original plain text value.
        /// </param>
        /// <returns>
        /// Either original array of plain text bytes (if salt is not used) or a
        /// modified array containing a randomly generated salt added at the 
        /// beginning of the plain text bytes. 
        /// </returns>
        private byte[] AddSalt(byte[] plainTextBytes)
        {
            if (RandomSaltMinimumLength == 0 || RandomSaltMaximumLength == 0)
            {
                return plainTextBytes;
            }

            // Generate the salt.
            var saltBytes = GenerateSalt();

            // Allocate array which will hold salt and plain text bytes.
            var plainTextBytesWithSalt = new byte[plainTextBytes.Length + saltBytes.Length];

            // First, copy salt bytes.
            Array.Copy(saltBytes, plainTextBytesWithSalt, saltBytes.Length);

            // Append plain text bytes to the salt value.
            Array.Copy(plainTextBytes, 0, plainTextBytesWithSalt, saltBytes.Length, plainTextBytes.Length);

            return plainTextBytesWithSalt;
        }

        /// <summary>
        /// Generates an array holding cryptographically strong bytes.
        /// </summary>
        /// <returns>
        /// Array of randomly generated bytes.
        /// </returns>
        /// <remarks>
        /// Salt size will be defined at random or exactly as specified by the
        /// minSlatLen and maxSaltLen parameters passed to the object constructor.
        /// The first four bytes of the salt array will contain the salt length
        /// split into four two-bit pieces.
        /// </remarks>
        private byte[] GenerateSalt()
        {
            var saltLen = DataGenerator.Integer(RandomSaltMinimumLength, RandomSaltMaximumLength);

            // Allocate byte array to hold our salt.
            var salt = new byte[saltLen];

            // Populate salt with cryptographically strong bytes.
            var rng = new RNGCryptoServiceProvider();

            rng.GetNonZeroBytes(salt);

            // Split salt length (always one byte) into four two-bit pieces and
            // store these pieces in the first four bytes of the salt array.
            salt[0] = (byte)((salt[0] & 0xfc) | (saltLen & 0x03));
            salt[1] = (byte)((salt[1] & 0xf3) | (saltLen & 0x0c));
            salt[2] = (byte)((salt[2] & 0xcf) | (saltLen & 0x30));
            salt[3] = (byte)((salt[3] & 0x3f) | (saltLen & 0xc0));

            return salt;
        }

        private static SecureString ToSecureString(IEnumerable<char> text)
        {
            var ss = new SecureString();

            foreach (var ch in text)
            {
                ss.AppendChar(ch);
            }

            ss.MakeReadOnly();

            return ss;
        }

        private static string ToString(SecureString secureString)
        {
            string text;

            var ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.SecureStringToBSTR(secureString);
                text = Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(ptr);
            }

            return text;
        }

        #endregion

        ///<summary>
        /// Sets the initialization vector (IV) for the algorithm
        ///</summary>
        ///<param name="initVector">The initialization vector (IV) for the algorithm</param>
        ///<returns></returns>
        ///<exception cref="ArgumentNullException"></exception>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        public RijndaelEngine SetInitVector(string initVector)
        {
            if (initVector == null)
            {
                throw new ArgumentNullException("initVector", "InitVector cannot be null");
            }

            if (!(initVector.Length == 0 || initVector.Length == 16))
            {
                throw new ArgumentOutOfRangeException("initVector", "InitVector must be a length of 0 or 16");
            }

            InitVector = ToSecureString(initVector);

            GenerateEngine();

            return this;
        }

        ///<summary>
        /// Sets the initialization vector (IV) for the algorithm
        ///</summary>
        ///<param name="initVector">The initialization vector (IV) for the algorithm</param>
        ///<returns></returns>
        ///<exception cref="ArgumentNullException"></exception>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        public RijndaelEngine SetInitVector(SecureString initVector)
        {
            if (initVector == null)
            {
                throw new ArgumentNullException("initVector", "InitVector cannot be null");
            }

            if (!(initVector.Length == 0 || initVector.Length == 16))
            {
                throw new ArgumentOutOfRangeException("initVector", "InitVector must be a length of 0 or 16");
            }

            initVector.MakeReadOnly();
            InitVector = initVector;

            GenerateEngine();

            return this;
        }

        ///<summary>
        /// Sets the minimum and maximum lengths of the random salt used in encryption/decryption
        ///</summary>
        /// <remarks>If both are set to 0, no random salt will be used.</remarks>
        ///<param name="minimumLength">Minimum salt length, must be greater than 0 (unless both minimum and maximum are set to 0)</param>
        ///<param name="maximumLength">Maximum salt length, must be greater than 0 (unless both minimum and maximum are set to 0)</param>
        ///<returns></returns>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        public RijndaelEngine SetRandomSaltLength(int minimumLength, int maximumLength)
        {
            if (minimumLength < 4 && maximumLength >= 4)
            {
                throw new ArgumentOutOfRangeException("minimumLength", minimumLength, "minimumLength must be greater than or equal to 4 or equal to 0");
            }
            if (maximumLength < 4 & minimumLength >= 4)
            {
                throw new ArgumentOutOfRangeException("maximumLength", maximumLength, "maximumLength must be greater than or equal to 4 or equal to 0");
            }
            if (maximumLength < minimumLength)
            {
                throw new ArgumentOutOfRangeException("maximumLength", string.Format("maximumLength ({0}) must be greater than or equal to minimumLength ({1})", maximumLength, minimumLength));
            }

            RandomSaltMinimumLength = minimumLength;
            RandomSaltMaximumLength = maximumLength;

            GenerateEngine();

            return this;
        }

        ///<summary>
        /// Sets the key salt used to derive the key
        ///</summary>
        ///<param name="salt">Key salt used to derive the key</param>
        ///<returns></returns>
        ///<exception cref="ArgumentNullException"></exception>
        public RijndaelEngine SetSalt(string salt)
        {
            if (salt == null)
            {
                throw new ArgumentNullException("salt", "salt cannot be null");
            }

            Salt = ToSecureString(salt);

            GenerateEngine();

            return this;
        }

        ///<summary>
        /// Sets the key salt used to derive the key
        ///</summary>
        ///<param name="salt">Key salt used to derive the key</param>
        ///<returns></returns>
        ///<exception cref="ArgumentNullException"></exception>
        public RijndaelEngine SetSalt(SecureString salt)
        {
            if (salt == null)
            {
                throw new ArgumentNullException("salt", "salt cannot be null");
            }

            salt.MakeReadOnly();
            Salt = salt;

            GenerateEngine();

            return this;
        }

        ///<summary>
        /// Sets the size of the secret key used by the algorithm
        ///</summary>
        ///<param name="keySize">The size of the secret key used by the algorithm</param>
        ///<returns></returns>
        public RijndaelEngine SetKeySize(KeySize keySize)
        {
            KeySize = keySize;

            GenerateEngine();

            return this;
        }

        ///<summary>
        /// Sets the number of iterations for the operation
        ///</summary>
        ///<param name="iterations">The number of iterations for the operation</param>
        ///<returns></returns>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        public RijndaelEngine SetIterations(int iterations)
        {
            if (iterations <= 0)
            {
                throw new ArgumentOutOfRangeException("iterations", iterations, "iterations must be greater than 0");
            }

            PasswordIterations = iterations;

            GenerateEngine();

            return this;
        }

        ///<summary>
        /// Sets the character encoding
        ///</summary>
        ///<param name="encoding">The character encoding</param>
        ///<returns></returns>
        ///<exception cref="ArgumentNullException"></exception>
        public RijndaelEngine SetEncoding(Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "encoding cannot be null");
            }

            Encoding = encoding;

            GenerateEngine();

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashAlgorithm"></param>
        /// <returns></returns>
        [Obsolete("Used in old key generation using the now Obsolite PasswordDeriveBytes", false)]
        public RijndaelEngine SetHashAlgorithm(string hashAlgorithm)
        {
            HashAlgorithm = hashAlgorithm;

            GenerateEngine();

            return this;
        }

        private void GenerateEngine()
        {
            // Initialization vector converted to a byte array.  Get bytes of initialization vector.
            var initVectorBytes = Encoding.GetBytes(ToString(InitVector));

            byte[] keyBytes;

            if (!string.IsNullOrEmpty(HashAlgorithm))
            {
                // Salt used for password hashing (to generate the key, not during encryption) converted to a byte array.
                // Get bytes of salt (used in hashing).
                var saltValueBytes = Salt == null || Salt.Length == 0 ? new byte[0] : Encoding.GetBytes(ToString(Salt));
                
                var password = new PasswordDeriveBytes(ToString(Key), saltValueBytes, HashAlgorithm, PasswordIterations);

                // Convert key to a byte array adjusting the size from bits to bytes.
#pragma warning disable 612,618
                keyBytes = password.GetBytes((int)KeySize / 8);
#pragma warning restore 612,618
            }
            else
            {
                // Salt used for password hashing (to generate the key, not during encryption) converted to a byte array.
                // Get bytes of salt (used in hashing).
                var saltValueBytes = Salt == null || Salt.Length == 0 ? new byte[8] : Encoding.GetBytes(ToString(Salt));

                var password = new Rfc2898DeriveBytes(ToString(Key), saltValueBytes, PasswordIterations);

                // Convert key to a byte array adjusting the size from bits to bytes.
                keyBytes = password.GetBytes((int) KeySize/8);
            }

            // If we do not have initialization vector, we cannot use the CBC mode.
            // The only alternative is the ECB mode (which is not as good).
            var symmetricKey = new RijndaelManaged
                                   {
                                       Mode = (initVectorBytes.Length == 0)
                                                  ? CipherMode.ECB
                                                  : CipherMode.CBC
                                   };
            
            // Create encryptor and decryptor, which we will use for cryptographic operations.
            _encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            _decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
        }
    }
}