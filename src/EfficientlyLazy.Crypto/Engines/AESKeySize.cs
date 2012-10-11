using System.ComponentModel;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary><see cref="AesManaged"/> Key Size</summary>
    /// <remarks>This engine is not available in the v2.0 framework</remarks>
    public enum AesKeySize
    {
        /// <summary>128bit key length</summary>
        [Description("128bit")]
        Key128Bit = 128,
        /// <summary>192bit key length</summary>
        [Description("192bit")]
        Key192Bit = 192,
        /// <summary>256bit key length</summary>
        [Description("256bit")]
        Key256Bit = 256
    }
}