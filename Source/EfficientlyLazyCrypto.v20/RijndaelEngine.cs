using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Security.Permissions;

namespace EfficientlyLazyCrypto
{
    /// <summary>
    /// Encryption/Decryption using <see cref="RijndaelManaged"/>.
    /// </summary>
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public sealed class RijndaelEngine : ICryptoEngine
    {
        private readonly ICryptoTransform _encryptor;
        private readonly ICryptoTransform _decryptor;
        private readonly byte _minimumDataSaltLength;
        private readonly byte _maximumDataSaltLength;
        private readonly Encoding _textEncoding;

        /// <summary>
        /// Initializes a new instance of the <see cref="RijndaelEngine"/> class.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public RijndaelEngine(IRijndaelParameters parameters)
        {
            ValidateParameters(parameters);

            // Initialization vector converted to a byte array.  Get bytes of initialization vector.
            byte[] initVectorBytes = DataConversion.ToBytes(parameters.InitVector, parameters.Encoding);

            // Salt used for password hashing (to generate the key, not during encryption) converted to a byte array.
            // Get bytes of salt (used in hashing).
            byte[] saltValueBytes = parameters.EncryptionKeySalt == null || parameters.EncryptionKeySalt.Length == 0 ? new byte[8] : Encoding.ASCII.GetBytes(DataConversion.ToString(parameters.EncryptionKeySalt));

            var symmetricKey = new RijndaelManaged();

            var password = new Rfc2898DeriveBytes(DataConversion.ToString(parameters.Key), saltValueBytes, parameters.PasswordIterations);

            // Convert key to a byte array adjusting the size from bits to bytes.
            byte[] keyBytes = password.GetBytes((int)parameters.KeySize / 8);

            // If we do not have initialization vector, we cannot use the CBC mode.
            // The only alternative is the ECB mode (which is not as good).
            symmetricKey.Mode = (initVectorBytes.Length == 0) ? CipherMode.ECB : CipherMode.CBC;

            // Create encryptor and decryptor, which we will use for cryptographic operations.
            _encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            _decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

            _minimumDataSaltLength = parameters.MinimumDataSaltLength;
            _maximumDataSaltLength = parameters.MaximumDataSaltLength;

            _textEncoding = parameters.Encoding;
        }

        /// <summary>
        /// Validate IRijndaelParameters for proper property settings
        /// </summary>
        /// <param name="parameters">IRijndaelParameters to validate</param>
        public static void ValidateParameters(IRijndaelParameters parameters)
        {
            if (parameters == null)
            {
                throw new InvalidRijndaelParameterException(parameters, "IRijndaelRarameters cannot be null");
            }
            
            if (!(parameters.InitVector.Length == 0 || parameters.InitVector.Length == 16))
            {
                throw new InvalidRijndaelParameterException(parameters, "InitVector", parameters.InitVector.Length,
                                                      "InitVector must be a length of 0 or 16");
            }
            
            if (parameters.PasswordIterations <= 0)
            {
                throw new InvalidRijndaelParameterException(parameters, "PasswordIterations", parameters.PasswordIterations,
                                                      "PasswordIterations must be greater than 0");
            }
            
            if (parameters.MaximumDataSaltLength < parameters.MinimumDataSaltLength)
            {
                throw new InvalidRijndaelParameterException(parameters, "MaximumDataSaltLength cannot be less than MinimumDataSaltLength");
            }
            
            if (parameters.MinimumDataSaltLength != 0 && parameters.MinimumDataSaltLength < RijndaelParameters.MINIMUM_SET_SALT_LENGTH)
            {
                throw new InvalidRijndaelParameterException(parameters, "MinimumDataSaltLength", parameters.MinimumDataSaltLength,
                                                      string.Format("MinimumDataSaltLength cannot be smaller than {0}",
                                                                    RijndaelParameters.MINIMUM_SET_SALT_LENGTH));
            }
            
            if (parameters.MaximumDataSaltLength != 0 && parameters.MaximumDataSaltLength > RijndaelParameters.MAXIMUM_SET_SALT_LENGTH)
            {
                throw new InvalidRijndaelParameterException(parameters, "MaximumDataSaltLength", parameters.MaximumDataSaltLength,
                                                      string.Format("MaximumDataSaltLength cannot be larger than {0}",
                                                                    RijndaelParameters.MAXIMUM_SET_SALT_LENGTH));
            }

           if (parameters.Encoding == null)
           {
               throw new InvalidRijndaelParameterException(parameters, "Encoding", parameters.Encoding, "An Encoding must be defined");
           }
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
                MemoryStream memoryStream = null;
                CryptoStream cryptoStream = null;

                try
                {
                    // Add salt at the beginning of the plain text bytes (if needed).
                    byte[] plainTextBytesWithSalt = AddSalt(plaintext);

                    memoryStream = new MemoryStream();

                    // To perform encryption, we must use the Write mode.
                    cryptoStream = new CryptoStream(memoryStream, _encryptor, CryptoStreamMode.Write);

                    // Start encrypting data.
                    cryptoStream.Write(plainTextBytesWithSalt, 0, plainTextBytesWithSalt.Length);

                    // Finish the encryption operation.
                    cryptoStream.FlushFinalBlock();

                    // Move encrypted data from memory into a byte array.
                    cipherTextBytes = memoryStream.ToArray();
                }
                catch (Exception ex)
                {
                    //cipherTextBytes = null;
                    throw new CryptographicException("Unable to Encrypt requested data", ex);
                }
                finally
                {
                    if (cryptoStream != null) cryptoStream.Dispose();
                    if (memoryStream != null) memoryStream.Dispose();
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
            return Convert.ToBase64String(Encrypt(_textEncoding.GetBytes(plaintext)));
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
                MemoryStream memoryStream = null;
                CryptoStream cryptoStream = null;

                try
                {
                    memoryStream = new MemoryStream(cipherText);

                    // To perform decryption, we must use the Read mode.
                    cryptoStream = new CryptoStream(memoryStream, _decryptor, CryptoStreamMode.Read);

                    // Since we do not know how big decrypted value will be, use the same
                    // size as cipher text. Cipher text is always longer than plain text
                    // (in block cipher encryption), so we will just use the number of
                    // decrypted data byte after we know how big it is.
                    var decryptedBytes = new byte[cipherText.Length];

                    // Decrypting data and get the count of plain text bytes.
                    int decryptedByteCount = cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);

                    int saltLen = 0;

                    // If we are using salt, get its length from the first 4 bytes of plain text data.
                    if (_maximumDataSaltLength > 0 && _maximumDataSaltLength >= _minimumDataSaltLength)
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
                finally
                {
                    if (cryptoStream != null) cryptoStream.Dispose();
                    if (memoryStream != null) memoryStream.Dispose();
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
            return _textEncoding.GetString(Decrypt(Convert.FromBase64String(cipherText)));
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
            if (_minimumDataSaltLength == 0 || _maximumDataSaltLength == 0)
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
            var saltLen = DataGeneration.RandomInteger(_minimumDataSaltLength, _maximumDataSaltLength);

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

        #endregion
    }
}