using System.Security;
using System.Text;

namespace EfficientlyLazyCrypto
{
    /// <summary>
    /// Parameters used for the <see cref="DPAPIEngine"/>.
    /// </summary>
    public sealed class DPAPIParameters : IDPAPIParameters
    {
        /// <summary>
        /// The entropy to use for the crypto engine.
        /// </summary>
        /// <value>The entropy is stored in a <see cref="SecureString"/>.</value>
        public SecureString Entropy { get; private set; }

        /// <summary>
        /// The <see cref="DPAPIKeyType"/> to use for the crypto engine.
        /// </summary>
        /// <value>Defined by the <see cref="DPAPIKeyType"/>.</value>
        public DPAPIKeyType KeyType { get; private set; }

       /// <summary>
        /// Defines the character encoding to use for string encryption
        /// </summary>
        public Encoding Encoding { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DPAPIParameters"/> class.
        /// </summary>
        /// <param name="keyType">The <see cref="DPAPIKeyType"/> to use for the crypto engine.</param>
        public DPAPIParameters(DPAPIKeyType keyType) 
            : this(keyType, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DPAPIParameters"/> class.
        /// </summary>
        /// <param name="keyType">The <see cref="DPAPIKeyType"/> to use for the crypto engine.</param>
        /// <param name="entropy">The entropy to use for the crypto engine.</param>
        public DPAPIParameters(DPAPIKeyType keyType, string entropy) 
            : this(keyType, DataConversion.ToSecureString(entropy))
        {
        }

       /// <summary>
        /// Initializes a new instance of the <see cref="DPAPIParameters"/> class.
        /// </summary>
        /// <param name="keyType">Type of the key.</param>
        /// <param name="entropy">The entropy.</param>
        public DPAPIParameters(DPAPIKeyType keyType, SecureString entropy)
           : this(keyType, entropy, Encoding.UTF8)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DPAPIParameters"/> class.
        /// </summary>
        /// <param name="keyType">Type of the key.</param>
        /// <param name="entropy">The entropy.</param>
        /// <param name="encoding">Character encoding to use.</param>
        public DPAPIParameters(DPAPIKeyType keyType, SecureString entropy, Encoding encoding)
        {
            KeyType = keyType;
            Entropy = entropy;
           Encoding = encoding;

            if (entropy != null && !entropy.IsReadOnly()) Entropy.MakeReadOnly();
        }
    }
}