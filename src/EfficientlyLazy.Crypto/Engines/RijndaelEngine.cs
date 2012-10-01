using System.Security;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary>
    /// Encryption/Decryption using <see cref="RijndaelManaged"/>.
    /// </summary>
    public sealed class RijndaelEngine : AbstractSymmetricEngine<RijndaelKeySize>
    {
        ///<summary>
        /// Initializes a new instance of the <see cref="RijndaelEngine"/> object.
        ///</summary>
        ///<param name="key">Represents the secret key for the algorithm</param>
        public RijndaelEngine(string key)
            : base(key, RijndaelKeySize.Key256Bit)
        {
        }

        ///<summary>
        /// Initializes a new instance of the <see cref="RijndaelEngine"/> object.
        ///</summary>
        ///<param name="key">Represents the secret key for the algorithm</param>
        public RijndaelEngine(SecureString key)
            : base(key, RijndaelKeySize.Key256Bit)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherMode"></param>
        /// <returns></returns>
        protected override SymmetricAlgorithm GenerateAlgorithmEngine(CipherMode cipherMode)
        {
            return new RijndaelManaged
                {
                    Mode = cipherMode
                };
        }
    }
}