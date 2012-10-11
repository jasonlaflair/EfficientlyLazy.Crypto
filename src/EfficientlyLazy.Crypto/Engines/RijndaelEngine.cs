using System.Security;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary>
    /// <see cref="ICryptoEngine"/> based on <see cref="RijndaelManaged"/>.
    /// </summary>
    public sealed class RijndaelEngine : AbstractSymmetricEngine<RijndaelKeySize>
    {
        ///<summary>
        /// Initializes a new instance of the <see cref="ICryptoEngine"/> based on <see cref="RijndaelManaged"/>.
        ///</summary>
        ///<param name="key">Represents the key for the algorithm</param>
        public RijndaelEngine(string key)
            : base(key, RijndaelKeySize.Key256Bit)
        {
        }

        ///<summary>
        /// Initializes a new instance of the <see cref="ICryptoEngine"/> based on <see cref="RijndaelManaged"/>.
        ///</summary>
        ///<param name="key">Represents the key for the algorithm</param>
        public RijndaelEngine(SecureString key)
            : base(key, RijndaelKeySize.Key256Bit)
        {
        }

        /// <summary>
        /// Generates the <see cref="SymmetricAlgorithm"/> based on <see cref="RijndaelManaged"/>
        /// </summary>
        /// <param name="cipherMode"><see cref="CipherMode"/> set for the generated <see cref="SymmetricAlgorithm"/></param>
        /// <returns><see cref="SymmetricAlgorithm"/> based on <see cref="RijndaelManaged"/></returns>
        protected override SymmetricAlgorithm GenerateAlgorithmEngine(CipherMode cipherMode)
        {
            return new RijndaelManaged
                {
                    Mode = cipherMode
                };
        }
    }
}