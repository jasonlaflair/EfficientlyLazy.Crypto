using System;
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

        ///<summary>
        /// Sets the <see cref="DPAPIKeyType"/> to use for the crypto engine.
        ///</summary>
        ///<param name="keyType"><see cref="DPAPIKeyType"/></param>
        ///<returns></returns>
        public IDPAPIParameters SetKeyType(DPAPIKeyType keyType)
        {
            KeyType = keyType;

            return this;
        }

        ///<summary>
        /// Sets the entropy for the cryptography parameters.
        ///</summary>
        ///<param name="entropy">Entropy specified as a string.</param>
        ///<returns></returns>
        public IDPAPIParameters SetEntropy(string entropy)
        {
            Entropy = DataConversion.ToSecureString(entropy, true);

            return this;
        }

        ///<summary>
        /// Sets the entropy for the cryptography parameters.
        ///</summary>
        ///<param name="entropy">Entropy specified as a <see cref="SecureString" />.</param>
        ///<returns></returns>
        public IDPAPIParameters SetEntropy(SecureString entropy)
        {
            if (entropy == null)
                throw new ArgumentNullException("entropy", "paramenter cannot be null");

            Entropy = entropy;
            
            if (!Entropy.IsReadOnly()) Entropy.MakeReadOnly();

            return this;
        }

        ///<summary>
        /// Sets the encoding for the cryptography parameters.
        ///</summary>
        ///<param name="encoding"><see cref="Encoding"/> to use.</param>
        ///<returns></returns>
        public IDPAPIParameters SetEncoding(Encoding encoding)
        {
            Encoding = encoding;

            return this;
        }

        private DPAPIParameters(DPAPIKeyType keyType)
        {
            KeyType = keyType;
            Entropy = DataConversion.ToSecureString(string.Empty, true);
            Encoding = Encoding.UTF8;
        }

        ///<summary>
        ///</summary>
        ///<param name="keyType"></param>
        ///<returns></returns>
        public static DPAPIParameters Create(DPAPIKeyType keyType)
        {
            return new DPAPIParameters(keyType);
        }
    }
}