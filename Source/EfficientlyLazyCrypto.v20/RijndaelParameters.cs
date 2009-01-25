using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace EfficientlyLazyCrypto
{
    /// <summary>
    /// Parameters used for the <see cref="RijndaelEngine"/>.
    /// </summary>
    public sealed class RijndaelParameters : IRijndaelParameters
    {
        /// <summary>
        /// Minimum salt length allowed if salt values are defined.
        /// </summary>
        public const byte MINIMUM_SET_SALT_LENGTH = 4;

        /// <summary>
        /// Maximum salt length allowed if salt values are defined.
        /// </summary>
        public const byte MAXIMUM_SET_SALT_LENGTH = 254;

        /// <summary>
        /// Gets the key used for the crypto engine.
        /// </summary>
        /// <value>The key is stored in a <see cref="SecureString"/>.</value>
        public SecureString Key { get; private set; }

        /// <summary>
        /// Gets the initialization vector used for the crypto engine.
        /// </summary>
        /// <value>Initialization vector (<see cref="SymmetricAlgorithm.IV"/>) stored in <see cref="SecureString"/>.</value>
        public SecureString InitVector { get; private set; }

        /// <summary>
        /// Gets the minimum length of salt to include in the encrypted data.
        /// </summary>
        /// <value>The minimum length of salt to include in the encrypted data.</value>
        public byte MinimumDataSaltLength { get; private set; }

        /// <summary>
        /// Gets The maximum length of salt to include in the encrypted data.
        /// </summary>
        /// <value>The minimum length.</value>
        public byte MaximumDataSaltLength { get; private set; }

        /// <summary>
        /// Gets the salt value to use when generating the crypto key.
        /// </summary>
        /// <value><see cref="SecureString"/></value>
        public SecureString EncryptionKeySalt { get; private set; }

        /// <summary>
        /// Gets the size, in bits, of the secret key used.
        /// </summary>
        /// <value>The size of the key defined by <see cref="RijndaelKeySize"/>.</value>
        public RijndaelKeySize KeySize { get; private set; }

        /// <summary>
        /// Gets the number of password iterations used during generation.
        /// </summary>
        /// <value>The number of password iterations.</value>
        public byte PasswordIterations { get; private set; }

        /// <summary>
        /// Defines the Encoding to use for string encryption
        /// </summary>
        public Encoding Encoding { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RijndaelParameters"/> class.
        /// </summary>
        /// <param name="key">The key to use for the crypto engine.</param>
        public RijndaelParameters(string key)
            : this(key, string.Empty, 0, 0, string.Empty, RijndaelKeySize.Key256Bit, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RijndaelParameters"/> class.
        /// </summary>
        /// <param name="key">The key to use for the crypto engine.</param>
        /// <param name="initVector">The initialization vector to use for the crypto engine.</param>
        public RijndaelParameters(string key, string initVector)
            : this(key, initVector, 0, 0, string.Empty, RijndaelKeySize.Key256Bit, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RijndaelParameters"/> class.
        /// </summary>
        /// <param name="key">The key to use for the crypto engine.</param>
        /// <param name="initVector">The initialization vector to use for the crypto engine.</param>
        /// <param name="minimumDataSaltLength"></param>
        /// <param name="maximumDataSaltLength"></param>
        public RijndaelParameters(string key, string initVector, byte minimumDataSaltLength, byte maximumDataSaltLength)
            : this(key, initVector, minimumDataSaltLength, maximumDataSaltLength, string.Empty, RijndaelKeySize.Key256Bit, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RijndaelParameters"/> class.
        /// </summary>
        /// <param name="key">The key to use for the crypto engine.</param>
        /// <param name="initVector">The initialization vector to use for the crypto engine.</param>
        /// <param name="minimumDataSaltLength"></param>
        /// <param name="maximumDataSaltLength"></param>
        /// <param name="encryptionKeySalt"></param>
        public RijndaelParameters(string key, string initVector, byte minimumDataSaltLength, byte maximumDataSaltLength, string encryptionKeySalt)
            : this(key, initVector, minimumDataSaltLength, maximumDataSaltLength, encryptionKeySalt, RijndaelKeySize.Key256Bit, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RijndaelParameters"/> class.
        /// </summary>
        /// <param name="key">The key to use for the crypto engine.</param>
        /// <param name="initVector">The initialization vector to use for the crypto engine.</param>
        /// <param name="minimumDataSaltLength"></param>
        /// <param name="maximumDataSaltLength"></param>
        /// <param name="encryptionKeySalt"></param>
        /// <param name="keySize">The size of the key to use.</param>
        public RijndaelParameters(string key, string initVector, byte minimumDataSaltLength, byte maximumDataSaltLength, string encryptionKeySalt, RijndaelKeySize keySize)
            : this(key, initVector, minimumDataSaltLength, maximumDataSaltLength, encryptionKeySalt, keySize, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RijndaelParameters"/> class.
        /// </summary>
        /// <param name="key">The key to use for the crypto engine.</param>
        /// <param name="initVector">The initialization vector to use for the crypto engine.</param>
        /// <param name="minimumDataSaltLength"></param>
        /// <param name="maximumDataSaltLength"></param>
        /// <param name="encryptionKeySalt"></param>
        /// <param name="keySize">The size of the key to use.</param>
        /// <param name="passwordIterations">The number of password iterations.</param>
        public RijndaelParameters(string key, string initVector, byte minimumDataSaltLength, byte maximumDataSaltLength, string encryptionKeySalt, RijndaelKeySize keySize, byte passwordIterations)
            : this(key, initVector, minimumDataSaltLength, maximumDataSaltLength, encryptionKeySalt, keySize, passwordIterations, Encoding.UTF8)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RijndaelParameters"/> class.
        /// </summary>
        /// <param name="key">The key to use for the crypto engine.</param>
        /// <param name="initVector">The initialization vector to use for the crypto engine.</param>
        /// <param name="minimumDataSaltLength"></param>
        /// <param name="maximumDataSaltLength"></param>
        /// <param name="encryptionKeySalt"></param>
        /// <param name="keySize">The size of the key to use.</param>
        /// <param name="passwordIterations">The number of password iterations.</param>
        /// <param name="encoding">Defines the Encoding to use for string encryption.</param>
        public RijndaelParameters(string key, string initVector, byte minimumDataSaltLength, byte maximumDataSaltLength, string encryptionKeySalt, RijndaelKeySize keySize, byte passwordIterations, Encoding encoding)
        {
            Key = DataConversion.ToSecureString(key, true);
            InitVector = DataConversion.ToSecureString(initVector, true);
            MinimumDataSaltLength = minimumDataSaltLength;
            MaximumDataSaltLength = maximumDataSaltLength;
            EncryptionKeySalt = DataConversion.ToSecureString(encryptionKeySalt, true);
            KeySize = keySize;
            PasswordIterations = passwordIterations;
            Encoding = encoding;
        }
    }
}