// // Copyright 2008-2009 LaFlair.NET
// // 
// // Licensed under the Apache License, Version 2.0 (the "License");
// // you may not use this file except in compliance with the License.
// // You may obtain a copy of the License at
// // 
// //     http://www.apache.org/licenses/LICENSE-2.0
// // 
// // Unless required by applicable law or agreed to in writing, software
// // distributed under the License is distributed on an "AS IS" BASIS,
// // WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// // See the License for the specific language governing permissions and
// // limitations under the License.
// 
namespace EfficientlyLazy.Crypto
{
    using System;
    using System.ComponentModel;
    using System.Security.Cryptography;

    /// <summary>Algorithms used for Data Hashing</summary>
    public enum Algorithm
    {
        /// <summary>MD5 Hashing</summary>
        [Obsolete("Should not be used as it has been proven insecure", true)]
        MD5 = 5,
        /// <summary>SHA1 Hashing</summary>
        SHA1 = 1,
        /// <summary>SHA256 Hashing</summary>
        SHA256 = 256,
        /// <summary>SHA384 Hashing</summary>
        SHA384 = 384,
        /// <summary>SHA512 Hashing</summary>
        SHA512 = 512
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
    public enum KeySize
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