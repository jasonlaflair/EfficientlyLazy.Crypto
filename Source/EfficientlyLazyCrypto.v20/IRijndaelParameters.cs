using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace EfficientlyLazyCrypto
{
    /// <summary>
    /// Parameters used for the <see cref="RijndaelEngine"/>.
    /// </summary>
    public interface IRijndaelParameters
    {
        /// <summary>
        /// Gets the key used for the crypto engine.
        /// </summary>
        /// <value>The key is stored in a <see cref="SecureString"/>.</value>
        SecureString Key { get; }
        
        /// <summary>
        /// Gets the initialization vector used for the crypto engine.
        /// </summary>
        /// <value>Initialization vector (<see cref="SymmetricAlgorithm.IV"/>) stored in <see cref="SecureString"/>.</value>
        SecureString InitVector { get; }

        /// <summary>
        /// Gets the minimum length of salt to include in the encrypted data.
        /// </summary>
        /// <value>The minimum length of salt to include in the encrypted data.</value>
        byte MinimumDataSaltLength { get; }

        /// <summary>
        /// Gets The maximum length of salt to include in the encrypted data.
        /// </summary>
        /// <value>The minimum length.</value>
        byte MaximumDataSaltLength { get; }

        /// <summary>
        /// Gets the salt value to use when generating the crypto key.
        /// </summary>
        /// <value><see cref="SecureString"/></value>
        SecureString EncryptionKeySalt { get; }

        /// <summary>
        /// Gets the size, in bits, of the secret key used.
        /// </summary>
        /// <value>The size of the key defined by <see cref="RijndaelKeySize"/>.</value>
        RijndaelKeySize KeySize { get; }

        /// <summary>
        /// Gets the number of password iterations used during generation.
        /// </summary>
        /// <value>The number of password iterations.</value>
        byte PasswordIterations { get; }

        /// <summary>
        /// Defines the character encoding to use for string encryption
        /// </summary>
        Encoding Encoding { get; }

        IRijndaelParameters SetKey(SecureString key);
        IRijndaelParameters SetKey(string key);

        IRijndaelParameters SetInitVector(SecureString initVector);
        IRijndaelParameters SetInitVector(string initVector);

        IRijndaelParameters SetRandomSaltLength(byte min, byte max);

        IRijndaelParameters SetSaltData(SecureString saltData);
        IRijndaelParameters SetSaltData(string saltData);

        IRijndaelParameters SetKeySize(RijndaelKeySize keySize);

        IRijndaelParameters SetPasswordIterations(byte iterations);

        IRijndaelParameters SetEncoding(Encoding encoding);
    }
}