using System.Security;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary>
    /// <see cref="ICryptoEngine"/> based on <see cref="TripleDESCryptoServiceProvider"/>.
    /// </summary>
    public sealed class TripleDESEngine : AbstractSymmetricEngine<TripleDESKeySize>
    {
        ///<summary>
        /// Initializes a new instance of the <see cref="ICryptoEngine"/> based on <see cref="TripleDESCryptoServiceProvider"/>.
        ///</summary>
        ///<param name="key">Represents the key for the algorithm</param>
        public TripleDESEngine(string key)
            : base(key, TripleDESKeySize.Key192Bit)
        {
        }

        ///<summary>
        /// Initializes a new instance of the <see cref="ICryptoEngine"/> based on <see cref="TripleDESCryptoServiceProvider"/>.
        ///</summary>
        ///<param name="key">Represents the key for the algorithm</param>
        public TripleDESEngine(SecureString key)
            : base(key, TripleDESKeySize.Key192Bit)
        {
        }

        /// <summary>
        /// Generates the <see cref="SymmetricAlgorithm"/> based on <see cref="TripleDESCryptoServiceProvider"/>
        /// </summary>
        /// <param name="cipherMode"><see cref="CipherMode"/> set for the generated <see cref="SymmetricAlgorithm"/></param>
        /// <returns><see cref="SymmetricAlgorithm"/> based on <see cref="TripleDESCryptoServiceProvider"/></returns>
        protected override SymmetricAlgorithm GenerateAlgorithmEngine(CipherMode cipherMode)
        {
            return new TripleDESCryptoServiceProvider
                {
                    Mode = cipherMode
                };
        }
    }
}