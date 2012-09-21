using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace EfficientlyLazy.Crypto
{
//    /// <summary>
//    /// 
//    /// </summary>
//    public static class CryptoEngineBuilder
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="algorithm"></param>
//        /// <param name="key"></param>
//        /// <returns></returns>
//        public static ISymmetricConfiguration<TripleDESKeySize> Configure(TripleDESKeySize keySize, string key)
//        {
//            return new SymmetricConfiguration<TripleDESKeySize>(keySize, key);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="algorithm"></param>
//        /// <param name="key"></param>
//        /// <returns></returns>
//        public static ISymmetricConfiguration Configure(SymmetricAlgorithmType algorithm, SecureString key)
//        {
//            return new SymmetricConfiguration(algorithm, key);
//        }

//        private class SymmetricConfiguration<T> : ISymmetricConfiguration<T> where T : struct 
//        {
//            private SymmetricAlgorithmType Algorithm { get; set; }
//            private SecureString Key { get; set; }
//            private SecureString InitVector { get; set; }
//            private int? RandomSaltMinimumLength { get; set; }
//            private int? RandomSaltMaximumLength { get; set; }
//            private SecureString Salt { get; set; }
//            private KeySize? KeySize { get; set; }
//            private int? PasswordIterations { get; set; }
//            private Encoding Encoding { get; set; }
//            private string HashAlgorithm { get; set; }

//            public SymmetricConfiguration(SymmetricAlgorithmType algorithm, string key)
//                : this(algorithm, ToSecureString(key))
//            {
//            }

//            public SymmetricConfiguration(SymmetricAlgorithmType algorithm, SecureString key)
//            {
//                Algorithm = algorithm;
//                Key = key;
//                InitVector = null;
//                RandomSaltMinimumLength = null;
//                RandomSaltMaximumLength = null;
//                Salt = null;
//                KeySize = null;
//                PasswordIterations = null;
//                Encoding = null;
//                HashAlgorithm = null;
//            }

//            public ISymmetricConfiguration SetInitVector(string initVector)
//            {
//                if (initVector == null)
//                {
//                    throw new ArgumentNullException("initVector", "InitVector cannot be null");
//                }

//                if (!(initVector.Length == 0 || initVector.Length == 16))
//                {
//                    throw new ArgumentOutOfRangeException("initVector", "InitVector must be a length of 0 or 16");
//                }

//                InitVector = ToSecureString(initVector);

//                return this;
//            }

//            ///<summary>
//            /// Sets the initialization vector (IV) for the algorithm
//            ///</summary>
//            ///<param name="initVector">The initialization vector (IV) for the algorithm</param>
//            ///<returns></returns>
//            ///<exception cref="ArgumentNullException"></exception>
//            ///<exception cref="ArgumentOutOfRangeException"></exception>
//            public ISymmetricConfiguration SetInitVector(SecureString initVector)
//            {
//                if (initVector == null)
//                {
//                    throw new ArgumentNullException("initVector", "InitVector cannot be null");
//                }

//                if (!(initVector.Length == 0 || initVector.Length == 16))
//                {
//                    throw new ArgumentOutOfRangeException("initVector", "InitVector must be a length of 0 or 16");
//                }

//                initVector.MakeReadOnly();
//                InitVector = initVector;

//                return this;
//            }

//            ///<summary>
//            /// Sets the minimum and maximum lengths of the random salt used in encryption/decryption
//            ///</summary>
//            /// <remarks>If both are set to 0, no random salt will be used.</remarks>
//            ///<param name="minimumLength">Minimum salt length, must be greater than 0 (unless both minimum and maximum are set to 0)</param>
//            ///<param name="maximumLength">Maximum salt length, must be greater than 0 (unless both minimum and maximum are set to 0)</param>
//            ///<returns></returns>
//            ///<exception cref="ArgumentOutOfRangeException"></exception>
//            public ISymmetricConfiguration SetRandomSaltLength(int minimumLength, int maximumLength)
//            {
//                if (minimumLength < 4 && maximumLength >= 4)
//                {
//                    throw new ArgumentOutOfRangeException("minimumLength", minimumLength, "minimumLength must be greater than or equal to 4 or equal to 0");
//                }
//                if (maximumLength < 4 & minimumLength >= 4)
//                {
//                    throw new ArgumentOutOfRangeException("maximumLength", maximumLength, "maximumLength must be greater than or equal to 4 or equal to 0");
//                }
//                if (maximumLength < minimumLength)
//                {
//                    throw new ArgumentOutOfRangeException("maximumLength", string.Format("maximumLength ({0}) must be greater than or equal to minimumLength ({1})", maximumLength, minimumLength));
//                }

//                RandomSaltMinimumLength = minimumLength;
//                RandomSaltMaximumLength = maximumLength;

//                return this;
//            }

//            ///<summary>
//            /// Sets the key salt used to derive the key
//            ///</summary>
//            ///<param name="salt">Key salt used to derive the key</param>
//            ///<returns></returns>
//            ///<exception cref="ArgumentNullException"></exception>
//            public ISymmetricConfiguration SetSalt(string salt)
//            {
//                if (salt == null)
//                {
//                    throw new ArgumentNullException("salt", "salt cannot be null");
//                }

//                Salt = ToSecureString(salt);

//                return this;
//            }

//            ///<summary>
//            /// Sets the key salt used to derive the key
//            ///</summary>
//            ///<param name="salt">Key salt used to derive the key</param>
//            ///<returns></returns>
//            ///<exception cref="ArgumentNullException"></exception>
//            public ISymmetricConfiguration SetSalt(SecureString salt)
//            {
//                if (salt == null)
//                {
//                    throw new ArgumentNullException("salt", "salt cannot be null");
//                }

//                salt.MakeReadOnly();
//                Salt = salt;

//                return this;
//            }

//            ///<summary>
//            /// Sets the size of the secret key used by the algorithm
//            ///</summary>
//            ///<param name="keySize">The size of the secret key used by the algorithm</param>
//            ///<returns></returns>
//            public ISymmetricConfiguration SetKeySize(KeySize keySize)
//            {
//                KeySize = keySize;

//                return this;
//            }

//            ///<summary>
//            /// Sets the number of iterations for the operation
//            ///</summary>
//            ///<param name="iterations">The number of iterations for the operation</param>
//            ///<returns></returns>
//            ///<exception cref="ArgumentOutOfRangeException"></exception>
//            public ISymmetricConfiguration SetIterations(int iterations)
//            {
//                if (iterations <= 0)
//                {
//                    throw new ArgumentOutOfRangeException("iterations", iterations, "iterations must be greater than 0");
//                }

//                PasswordIterations = iterations;

//                return this;
//            }

//            ///<summary>
//            /// Sets the character encoding
//            ///</summary>
//            ///<param name="encoding">The character encoding</param>
//            ///<returns></returns>
//            ///<exception cref="ArgumentNullException"></exception>
//            public ISymmetricConfiguration SetEncoding(Encoding encoding)
//            {
//                if (encoding == null)
//                {
//                    throw new ArgumentNullException("encoding", "encoding cannot be null");
//                }

//                Encoding = encoding;

//                return this;
//            }

//            /// <summary>
//            /// 
//            /// </summary>
//            /// <param name="hashAlgorithm"></param>
//            /// <returns></returns>
//            [Obsolete("Used in old key generation using the now Obsolite PasswordDeriveBytes", false)]
//            public ISymmetricConfiguration SetHashAlgorithm(string hashAlgorithm)
//            {
//                HashAlgorithm = hashAlgorithm;

//                return this;
//            }

//            private static SecureString ToSecureString(IEnumerable<char> text)
//            {
//                var ss = new SecureString();

//                foreach (var ch in text)
//                {
//                    ss.AppendChar(ch);
//                }

//                ss.MakeReadOnly();

//                return ss;
//            }

//            public ICryptoEngine Build()
//            {
//                SymmetricEngineBase engine;

//                switch (Algorithm)
//                {
//                    case SymmetricAlgorithmType.Rijndael:
//                        engine = new RijndaelEngine(Key);
//                        break;
//                    case SymmetricAlgorithmType.RC2:
//                        engine = new RC2Engine(Key);
//                        break;
//                    case SymmetricAlgorithmType.DES:
//                        engine = new DESEngine(Key);
//                        break;
//                    case SymmetricAlgorithmType.TripleDES:
//                        engine = new TripleDESEngine(Key);
//                        break;
//                    default:
//                        throw new ArgumentOutOfRangeException();
//                }

//                if (InitVector != null)
//                {
//                    engine.SetInitVector(InitVector);
//                }

//                if (RandomSaltMinimumLength.HasValue && RandomSaltMaximumLength.HasValue)
//                {
//                    engine.SetRandomSaltLength(RandomSaltMinimumLength.Value, RandomSaltMaximumLength.Value);
//                }

//                if (Salt != null)
//                {
//                    engine.SetSalt(Salt);
//                }

//                if (KeySize == null)
//                {
//                    throw new InvalidOperationException();
//                }
                
//                engine.SetKeySize(KeySize.Value);

//                if (PasswordIterations.HasValue)
//                {
//                    engine.SetIterations(PasswordIterations.Value);
//                }

//                if (Encoding != null)
//                {
//                    engine.SetEncoding(Encoding);
//                }

//                if (HashAlgorithm != null)
//                {
//#pragma warning disable 612,618
//                    engine.SetHashAlgorithm(HashAlgorithm);
//#pragma warning restore 612,618
//                }

//                return engine;
//            }
//        }
//    }
}