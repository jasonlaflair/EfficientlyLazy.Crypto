using System.ComponentModel;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary><see cref="RC2"/> Key Size</summary>
    public enum RC2KeySize
    {
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key40Bit = 40,
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key48Bit = 48,
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key56Bit = 56,
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key64Bit = 64,
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key72Bit = 72,
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key80Bit = 80,
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key88Bit = 88,
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key96Bit = 96,
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key104Bit = 104,
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key112Bit = 112,
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key120Bit = 120,
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key128Bit = 128
    }
}