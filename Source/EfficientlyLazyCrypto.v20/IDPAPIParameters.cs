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
    }
}