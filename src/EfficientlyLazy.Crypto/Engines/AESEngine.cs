using System.Security;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary>
    /// <see cref="ICryptoEngine"/> based on <see cref="AesManaged"/>.
    /// </summary>
    /// <remarks>This engine is not available in the v2.0 framework</remarks>
    public sealed class AesEngine : AbstractSymmetricEngine<AesKeySize>
    {
        ///<summary>
        /// Initializes a new instance of the <see cref="ICryptoEngine"/> based on <see cref="AesManaged"/>.
        ///</summary>
        ///<param name="key">Represents the key for the algorithm</param>
        public AesEngine(string key)
            : base(key, AesKeySize.Key256Bit)
        {
            SetInitVector("                ");
        }

        ///<summary>
        /// Initializes a new instance of the <see cref="ICryptoEngine"/> based on <see cref="AesManaged"/>.
        ///</summary>
        ///<param name="key">Represents the key for the algorithm</param>
        public AesEngine(SecureString key)
            : base(key, AesKeySize.Key256Bit)
        {
            SetInitVector("                ");
        }

        /// <summary>
        /// Generates the <see cref="SymmetricAlgorithm"/> based on <see cref="AesManaged"/>
        /// </summary>
        /// <param name="cipherMode"><see cref="CipherMode"/> set for the generated <see cref="SymmetricAlgorithm"/></param>
        /// <returns><see cref="SymmetricAlgorithm"/> based on <see cref="AesManaged"/></returns>
        protected override SymmetricAlgorithm GenerateAlgorithmEngine(CipherMode cipherMode)
        {
            return new AesManaged
                {
                    Mode = cipherMode
                };
        }
    }
}