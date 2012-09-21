using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto
{
    /// <summary>
    /// 
    /// </summary>
    public enum SymmetricAlgorithmType
    {
        /// <summary>
        /// 
        /// </summary>
        Rijndael,
        /// <summary>
        /// 
        /// </summary>
        RC2,
        /// <summary>
        /// 
        /// </summary>
        DES,
        /// <summary>
        /// 
        /// </summary>
        TripleDES
    }

    /// <summary>Algorithms used for Data Hashing</summary>
    public enum Algorithm
    {
        /// <summary>MD5 Hashing</summary>
        [Obsolete("Should not be used as it has been proven insecure", false)]
        MD5 = 5,
        /// <summary>SHA1 Hashing</summary>
        SHA1 = 1,
        /// <summary>SHA256 Hashing</summary>
        SHA256 = 256,
        /// <summary>SHA384 Hashing</summary>
        SHA384 = 384,
        /// <summary>SHA512 Hashing</summary>
        SHA512 = 512,
        /// <summary>RIPEMD160 Hashing</summary>
        RIPEMD160 = 160,
    }

    /// <summary>DPAPI Key Type</summary>
    public enum KeyType
    {
        /// <summary>Encrypt at the User Level</summary>
        [Description("User Level")]
        UserKey = 1,
        /// <summary>Encrypt at the Machine Level</summary>
        [Description("Machine Level")]
        MachineKey = 0
    }

    /// <summary><see cref="Rijndael"/> Key Size</summary>
    public enum RijndaelKeySize
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

    /// <summary><see cref="TripleDES"/> Key Size</summary>
    public enum TripleDESKeySize
    {
        /// <summary>128bit key length</summary>
        [Description("128bit")]
        Key128Bit = 128,
        /// <summary>192bit key length</summary>
        [Description("192bit")]
        Key192Bit = 192
    }

    /// <summary><see cref="DES"/> Key Size</summary>
    public enum DESKeySize
    {
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key64Bit = 64
    }

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