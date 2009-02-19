using System.Security;
using System.Text;

namespace EfficientlyLazyCrypto
{
    /// <summary>
    /// Parameters used for the <see cref="DPAPIEngine"/>.
    /// </summary>
    public interface IDPAPIParameters
    {
        /// <summary>
        /// The entropy to use for the crypto engine.
        /// </summary>
        /// <value>The encryption entropy.</value>
        SecureString Entropy { get; }

        /// <summary>
        /// The <see cref="DPAPIKeyType"/> to use for the cryto engine.
        /// </summary>
        /// <value>Defined by the <see cref="DPAPIKeyType"/>.</value>
        DPAPIKeyType KeyType { get; }

        /// <summary>
        /// Defines the character encoding to use for string encryption
        /// </summary>
        Encoding Encoding { get; }

        ///<summary>
        /// Sets the <see cref="DPAPIKeyType"/> to use for the crypto engine.
        ///</summary>
        ///<param name="keyType"><see cref="DPAPIKeyType"/></param>
        ///<returns></returns>
        IDPAPIParameters SetKeyType(DPAPIKeyType keyType);

        ///<summary>
        /// Sets the entropy for the cryptography parameters.
        ///</summary>
        ///<param name="entropy">Entropy specified as a string.</param>
        ///<returns></returns>
        IDPAPIParameters SetEntropy(string entropy);

        ///<summary>
        /// Sets the entropy for the cryptography parameters.
        ///</summary>
        ///<param name="entropy">Entropy specified as a <see cref="SecureString" />.</param>
        ///<returns></returns>
        IDPAPIParameters SetEntropy(SecureString entropy);

        ///<summary>
        /// Sets the encoding for the cryptography parameters.
        ///</summary>
        ///<param name="encoding"><see cref="Encoding"/> to use.</param>
        ///<returns></returns>
        IDPAPIParameters SetEncoding(Encoding encoding);
    }
}