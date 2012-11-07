using System;
using System.Security;
using System.Text;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISymmetricEngine<T> : ICryptoEngine
    {
        /// <summary>
        /// Sets the initialization vector (IV).
        /// </summary>
        /// <param name="initVector">Initialization vector (IV).</param>
        /// <returns></returns>
        ISymmetricEngine<T> SetInitVector(string initVector);

        /// <summary>
        /// Sets the initialization vector (IV) for the algorithm
        /// </summary>
        /// <param name="initVector">Initialization vector (IV).</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        ISymmetricEngine<T> SetInitVector(SecureString initVector);

        /// <summary>
        /// Sets the minimum and maximum lengths of the random salt used in encryption/decryption
        /// </summary>
        /// <param name="minimumLength">Minimum salt length, must be greater than 0 (unless both minimum and maximum are set to 0)</param>
        /// <param name="maximumLength">Maximum salt length, must be greater than 0 (unless both minimum and maximum are set to 0)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <remarks>
        /// If both are set to 0, no random salt will be used.
        /// </remarks>
        ISymmetricEngine<T> SetRandomSaltLength(int minimumLength, int maximumLength);

        /// <summary>
        /// Sets the key salt used to derive the key
        /// </summary>
        /// <param name="salt">Key salt used to derive the key</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        ISymmetricEngine<T> SetSalt(string salt);

        /// <summary>
        /// Sets the key salt used to derive the key
        /// </summary>
        /// <param name="salt">Key salt used to derive the key</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        ISymmetricEngine<T> SetSalt(SecureString salt);

        /// <summary>
        /// Sets the size of the key used by the algorithm
        /// </summary>
        /// <param name="keySize">The size of the key used by the algorithm</param>
        /// <returns></returns>
        ISymmetricEngine<T> SetKeySize(T keySize);

        /// <summary>
        /// Sets the number of iterations for the operation
        /// </summary>
        /// <param name="iterations">The number of iterations for the operation</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        ISymmetricEngine<T> SetIterations(int iterations);

        /// <summary>
        /// Sets the character encoding
        /// </summary>
        /// <param name="encoding">The character encoding</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        ISymmetricEngine<T> SetEncoding(Encoding encoding);

        /// <summary>
        /// Obsolete as it was used to indicate the hash used for the now obsolete PasswordDeriveBytes
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <returns></returns>
        [Obsolete("Used in old key generation using the now Obsolite PasswordDeriveBytes", false)]
        ISymmetricEngine<T> SetHashAlgorithm(HashType hashAlgorithm);
    }
}
