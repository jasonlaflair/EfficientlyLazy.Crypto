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

        public IRijndaelParameters SetKey(SecureString key)
        {
            Key = key;

            if (!Key.IsReadOnly()) Key.MakeReadOnly();

            return this;
        }

        public IRijndaelParameters SetKey(string key)
        {
            Key = DataConversion.ToSecureString(key, true);

            return this;
        }

        public IRijndaelParameters SetInitVector(SecureString initVector)
        {
            InitVector = initVector;

            if (!InitVector.IsReadOnly()) InitVector.MakeReadOnly();

            return this;
        }

        public IRijndaelParameters SetInitVector(string initVector)
        {
            InitVector = DataConversion.ToSecureString(initVector, true);

            return this;
        }

        public IRijndaelParameters SetRandomSaltLength(byte min, byte max)
        {
            MinimumDataSaltLength = min;
            MaximumDataSaltLength = max;

            return this;
        }

        public IRijndaelParameters SetSaltData(SecureString saltData)
        {
            EncryptionKeySalt = saltData;

            if (!EncryptionKeySalt.IsReadOnly()) EncryptionKeySalt.MakeReadOnly();

            return this;
        }

        public IRijndaelParameters SetSaltData(string saltData)
        {
            EncryptionKeySalt = DataConversion.ToSecureString(saltData, true);

            return this;
        }

        public IRijndaelParameters SetKeySize(RijndaelKeySize keySize)
        {
            KeySize = keySize;

            return this;
        }

        public IRijndaelParameters SetPasswordIterations(byte iterations)
        {
            PasswordIterations = iterations;

            return this;
        }

        public IRijndaelParameters SetEncoding(Encoding encoding)
        {
            Encoding = encoding;

            return this;
        }

        private RijndaelParameters(SecureString key)
        {
            Key = key;
            InitVector = DataConversion.ToSecureString(string.Empty, true);
            MinimumDataSaltLength = 0;
            MaximumDataSaltLength = 0;
            EncryptionKeySalt = DataConversion.ToSecureString(string.Empty);
            KeySize = RijndaelKeySize.Key256Bit;
            PasswordIterations = 1;
            Encoding = Encoding.UTF8;
        }


        public static RijndaelParameters Create(string key)
        {
            return new RijndaelParameters(DataConversion.ToSecureString(key, true));
        }
    }
}