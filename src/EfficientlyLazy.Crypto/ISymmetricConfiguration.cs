using System.Security;
using System.Text;

namespace EfficientlyLazy.Crypto
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISymmetricConfiguration<T> where T : struct 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initVector"></param>
        /// <returns></returns>
        ISymmetricConfiguration<T> SetInitVector(string initVector);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initVector"></param>
        /// <returns></returns>
        ISymmetricConfiguration<T> SetInitVector(SecureString initVector);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="minimumLength"></param>
        /// <param name="maximumLength"></param>
        /// <returns></returns>
        ISymmetricConfiguration<T> SetRandomSaltLength(int minimumLength, int maximumLength);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salt"></param>
        /// <returns></returns>
        ISymmetricConfiguration<T> SetSalt(string salt);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salt"></param>
        /// <returns></returns>
        ISymmetricConfiguration<T> SetSalt(SecureString salt);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keySize"></param>
        /// <returns></returns>
        ISymmetricConfiguration<T> SetKeySize(T keySize);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterations"></param>
        /// <returns></returns>
        ISymmetricConfiguration<T> SetIterations(int iterations);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        ISymmetricConfiguration<T> SetEncoding(Encoding encoding);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashAlgorithm"></param>
        /// <returns></returns>
        ISymmetricConfiguration<T> SetHashAlgorithm(string hashAlgorithm);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ICryptoEngine Build();
    }
}
