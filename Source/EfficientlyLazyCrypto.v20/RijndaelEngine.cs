using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace EfficientlyLazyCrypto
{
    /// <summary>
    /// Encryption/Decryption using <see cref="RijndaelManaged"/>.
    /// </summary>
    public sealed class RijndaelEngine : ICryptoEngine
    {
        private ICryptoTransform _encryptor;
        private ICryptoTransform _decryptor;

        ///<summary>
        ///</summary>
        public SecureString Key { get; private set; }
        ///<summary>
        ///</summary>
        public SecureString InitVector { get; private set; }
        ///<summary>
        ///</summary>
        public int RandomSaltMinimumLength { get; private set; }
        ///<summary>
        ///</summary>
        public int RandomSaltMaximumLength { get; private set; }
        ///<summary>
        ///</summary>
        public SecureString Salt { get; private set; }
        ///<summary>
        ///</summary>
        public RijndaelKeySize KeySize { get; private set; }
        ///<summary>
        ///</summary>
        public int PasswordIterations { get; private set; }
        ///<summary>
        ///</summary>
        public Encoding Encoding { get; private set; }

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        public RijndaelEngine(string key)
        {
            Key = ToSecureString(key);
            InitVector = ToSecureString(string.Empty);
            RandomSaltMinimumLength = 0;
            RandomSaltMaximumLength = 0;
            Salt = ToSecureString(string.Empty);
            KeySize = RijndaelKeySize.Key256Bit;
            PasswordIterations = 10;
            Encoding = Encoding.UTF8;

            GenerateEngine();
        }

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        public RijndaelEngine(SecureString key)
        {
            key.MakeReadOnly();

            Key = key;
            InitVector = ToSecureString(string.Empty);
            RandomSaltMinimumLength = 0;
            RandomSaltMaximumLength = 0;
            Salt = ToSecureString(string.Empty);
            KeySize = RijndaelKeySize.Key256Bit;
            PasswordIterations = 10;
            Encoding = Encoding.UTF8;

            GenerateEngine();
        }

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        ///<returns></returns>
        public RijndaelEngine SetKey(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "Key cannot be null");
            }

            Key = ToSecureString(key);

            GenerateEngine();

            return this;
        }

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        ///<returns></returns>
        public RijndaelEngine SetKey(SecureString key)
        {
            key.MakeReadOnly();
            Key = key;

            GenerateEngine();

            return this;
        }

        ///<summary>
        ///</summary>
        ///<param name="initVector"></param>
        ///<returns></returns>
        public RijndaelEngine SetInitVector(string initVector)
        {
            if (initVector == null)
            {
                throw new ArgumentNullException("initVector", "InitVector cannot be null");
            }

            if (!(initVector.Length == 0 || initVector.Length == 16))
            {
                throw new ArgumentException("InitVector must be a length of 0 or 16", "initVector");
            }

            InitVector = ToSecureString(initVector);

            GenerateEngine();

            return this;
        }

        ///<summary>
        ///</summary>
        ///<param name="initVector"></param>
        ///<returns></returns>
        public RijndaelEngine SetInitVector(SecureString initVector)
        {
            initVector.MakeReadOnly();
            InitVector = initVector;

            GenerateEngine();

            return this;
        }

        ///<summary>
        ///</summary>
        ///<param name="minimumLength"></param>
        ///<param name="maximumLength"></param>
        ///<returns></returns>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        public RijndaelEngine SetRandomSaltLength(int minimumLength, int maximumLength)
        {
            if (minimumLength < 0)
            {
                throw new ArgumentOutOfRangeException("minimumLength", minimumLength, "minimumLength must be greater than or equal to 0");
            }
            if (maximumLength < 0)
            {
                throw new ArgumentOutOfRangeException("maximumLength", maximumLength, "maximumLength must be greater than or equal to 0");
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
        ///</summary>
        ///<param name="salt"></param>
        ///<returns></returns>
        public RijndaelEngine SetSalt(string salt)
        {
            Salt = ToSecureString(salt);

            GenerateEngine();

            return this;
        }

        ///<summary>
        ///</summary>
        ///<param name="salt"></param>
        ///<returns></returns>
        public RijndaelEngine SetSalt(SecureString salt)
        {
            salt.MakeReadOnly();
            Salt = salt;

            GenerateEngine();

            return this;
        }

        ///<summary>
        ///</summary>
        ///<param name="keySize"></param>
        ///<returns></returns>
        public RijndaelEngine SetKeySize(RijndaelKeySize keySize)
        {
            KeySize = keySize;

            GenerateEngine();

            return this;
        }

        ///<summary>
        ///</summary>
        ///<param name="iterations"></param>
        ///<returns></returns>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        public RijndaelEngine SetPasswordIterations(int iterations)
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
        ///</summary>
        ///<param name="encoding"></param>
        ///<returns></returns>
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

        private void GenerateEngine()
        {
            // Initialization vector converted to a byte array.  Get bytes of initialization vector.
            byte[] initVectorBytes = Encoding.GetBytes(ToString(InitVector));

            // Salt used for password hashing (to generate the key, not during encryption) converted to a byte array.
            // Get bytes of salt (used in hashing).
            byte[] saltValueBytes = Salt == null || Salt.Length == 0 ? new byte[8] : Encoding.GetBytes(ToString(Salt));

            var symmetricKey = new RijndaelManaged();

            var password = new Rfc2898DeriveBytes(ToString(Key), saltValueBytes, PasswordIterations);

            // Convert key to a byte array adjusting the size from bits to bytes.
            byte[] keyBytes = password.GetBytes((int)KeySize / 8);

            // If we do not have initialization vector, we cannot use the CBC mode.
            // The only alternative is the ECB mode (which is not as good).
            symmetricKey.Mode = (initVectorBytes.Length == 0) ? CipherMode.ECB : CipherMode.CBC;

            // Create encryptor and decryptor, which we will use for cryptographic operations.
            _encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            _decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
        }

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
                    byte[] plainTextBytesWithSalt = AddSalt(plaintext);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        // To perform encryption, we must use the Write mode.
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, _encryptor, CryptoStreamMode.Write))
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
        /// Encrypts the specified input file.
        /// </summary>
        /// <param name="inputFile">The input file.</param>
        /// <param name="outputFile">The encrypted file.</param>
        /// <returns></returns>
        public bool Encrypt(string inputFile, string outputFile)
        {
            throw new NotImplementedException();
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

                    using (MemoryStream ms = new MemoryStream(cipherText))
                    {
                        // To perform decryption, we must use the Read mode.
                        using (CryptoStream cs = new CryptoStream(ms, _decryptor, CryptoStreamMode.Read))
                        {
                            decryptedByteCount = cs.Read(decryptedBytes, 0, decryptedBytes.Length);
                        }
                    }

                    int saltLen = 0;

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

        /// <summary>
        /// Decrypts the specified encrypted file.
        /// </summary>
        /// <param name="inputFile">The encrypted file.</param>
        /// <param name="outputFile">The output file.</param>
        /// <returns></returns>
        public bool Decrypt(string inputFile, string outputFile)
        {
            throw new NotImplementedException();
        }

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
            byte[] saltBytes = GenerateSalt();

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
            var saltLen = DataGenerator.RandomInteger(RandomSaltMinimumLength, RandomSaltMaximumLength);

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

            foreach (char ch in text)
            {
                ss.AppendChar(ch);
            }

            ss.MakeReadOnly();

            return ss;
        }

        private static string ToString(SecureString secureString)
        {
            string text;

            IntPtr ptr = IntPtr.Zero;

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
    }
}