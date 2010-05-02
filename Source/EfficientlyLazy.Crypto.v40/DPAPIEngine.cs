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
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Cryptography;
    using System.Security.Permissions;
    using System.Text;

    /// <summary>
    /// Encryption/Decryption using the windows crypto API.
    /// </summary>
    public sealed class DPAPIEngine : ICryptoEngine
    {
        ///<summary>
        /// Initializes a new instance of the <see cref="DPAPIEngine"/> object.
        ///</summary>
        ///<param name="keyType">Defines the method (<see cref="EfficientlyLazy.Crypto.KeyType"/>) to use for encryption/decryption.</param>
        public DPAPIEngine(KeyType keyType)
        {
            KeyType = keyType;
            Entropy = ToSecureString(string.Empty);
            Encoding = Encoding.Default;
        }

        ///<summary>
        /// Additional entropy used for encryption/decryption.
        ///</summary>
        public SecureString Entropy { get; private set; }

        ///<summary>
        /// Method (<see cref="EfficientlyLazy.Crypto.KeyType"/>) to use for encryption/decryption.
        ///</summary>
        public KeyType KeyType { get; private set; }

        ///<summary>
        /// Character encoding to use during encryption/decryption.
        ///</summary>
        public Encoding Encoding { get; private set; }

        #region ICryptoEngine Members

        /// <summary>
        /// Encrypts the specified plain text to a byte array.
        /// </summary>
        /// <param name="plaintext">The plain text to encrypt.</param>
        /// <returns>Byte array of encrypted data.</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public byte[] Encrypt(byte[] plaintext)
        {
            return DPAPIEncrypt(KeyType, plaintext, Encoding.GetBytes(ToString(Entropy)));
        }

        /// <summary>
        /// Encrypts the specified plain text to a string.
        /// </summary>
        /// <param name="plaintext">The plain text to encrypt.</param>
        /// <returns>String of encrypted data.</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public string Encrypt(string plaintext)
        {
            return Convert.ToBase64String(Encrypt(Encoding.GetBytes(plaintext)));
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public byte[] Decrypt(byte[] cipherText)
        {
            return DPAPIDecrypt(cipherText, Encoding.GetBytes(ToString(Entropy)));
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public string Decrypt(string cipherText)
        {
            return Encoding.GetString(Decrypt(Convert.FromBase64String(cipherText)));
        }

        /////<summary>
        /////</summary>
        /////<param name="key">Key name given to the setting in the config file.</param>
        /////<returns>The setting value if available, if not, String.Empty is returned.</returns>
        //public string GetSettingFromConfiguration(string key)
        //{
        //    return GetSettingFromConfiguration(key, string.Empty);
        //}

        /////<summary>
        /////</summary>
        /////<param name="key">Name given to the setting in the config file.</param>
        /////<param name="defaultValue">Value returned if the setting key is not found.</param>
        /////<returns>The setting value if available, if not, the defaultValue is returned.</returns>
        //public string GetSettingFromConfiguration(string key, string defaultValue)
        //{
        //    string decryptedValue = defaultValue;

        //    ConfigurationManager.RefreshSection("encryptedConfig");

        //    var encryptedConfigHandler = (EncryptedConfigurationSection)ConfigurationManager.GetSection("encryptedConfig");

        //    foreach (EncryptedSettingElement element in encryptedConfigHandler.Settings)
        //    {
        //        if (string.Compare(element.Key, key, StringComparison.CurrentCultureIgnoreCase) != 0)
        //        {
        //            continue;
        //        }

        //        decryptedValue = Decrypt(element.EncryptedValue);
        //        break;
        //    }

        //    return decryptedValue;
        //}

        /////<summary>
        /////</summary>
        /////<param name="alias">Alias name given to the connection string in the config file.</param>
        /////<returns>The connection string value if available, if not, String.Empty is returned.</returns>
        //public string GetConnectionStringFromConfiguration(string alias)
        //{
        //    return GetConnectionStringFromConfiguration(alias, string.Empty);
        //}

        /////<summary>
        /////</summary>
        /////<param name="alias">Alias given to the connection string in the config file.</param>
        /////<param name="defaultValue">Value returned if the connection string alias is not found.</param>
        /////<returns>The connection string value if available, if not, the defaultValue is returned.</returns>
        //public string GetConnectionStringFromConfiguration(string alias, string defaultValue)
        //{
        //    string decryptedConnectionString = defaultValue;

        //    ConfigurationManager.RefreshSection("encryptedConfig");

        //    var encryptedConfigHandler = (EncryptedConfigurationSection)ConfigurationManager.GetSection("encryptedConfig");

        //    foreach (EncryptedConnectionStringElement element in encryptedConfigHandler.Settings)
        //    {
        //        if (string.Compare(element.Alias, alias, StringComparison.CurrentCultureIgnoreCase) != 0)
        //        {
        //            continue;
        //        }

        //        decryptedConnectionString = Decrypt(element.EncryptedConnectionString);
        //        break;
        //    }

        //    return decryptedConnectionString;
        //}

        #endregion

        #region DPAPI Helper functions

        // DPAPI key initialization flags.
        private const int CRYPTPROTECT_LOCAL_MACHINE = 0x4;
        private const int CRYPTPROTECT_UI_FORBIDDEN = 0x1;

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private static byte[] DPAPIEncrypt(KeyType keyType, byte[] plainTextBytes, byte[] entropyBytes)
        {
            // Create Null BLOBs to hold data, they will be initialized later.
            var plainTextBlob = DPAPINativeDATABLOB.Null();
            var cipherTextBlob = DPAPINativeDATABLOB.Null();
            var entropyBlob = DPAPINativeDATABLOB.Null();

            // We only need prompt structure because it is a required parameter.
            var prompt = DPAPINativeCRYPTPROTECTPROMPTSTRUCT.Default();

            byte[] cipherTextBytes;

            try
            {
                // Convert plaintext bytes into a BLOB structure.
                plainTextBlob = DPAPINativeDATABLOB.Init(plainTextBytes); // InitBLOB(plainTextBytes);

                // Convert entropy bytes into a BLOB structure.
                entropyBlob = DPAPINativeDATABLOB.Init(entropyBytes); // InitBLOB(entropyBytes);

                // Disable any types of UI.
                int flags = CRYPTPROTECT_UI_FORBIDDEN;

                // When using machine-specific key, set up machine flag.
                if (keyType == KeyType.MachineKey)
                {
                    flags |= CRYPTPROTECT_LOCAL_MACHINE;
                }

                // Call DPAPI to encrypt data.
                bool success = ProtectData(ref plainTextBlob, string.Empty, ref entropyBlob, IntPtr.Zero, ref prompt, flags, ref cipherTextBlob);

                // Check the result.
                if (!success)
                {
                    // If operation failed, retrieve last Win32 error.
                    int errCode = Marshal.GetLastWin32Error();

                    // Win32Exception will contain error message corresponding
                    // to the Windows error code.
                    throw new CryptographicException("CryptProtectData failed.", new Win32Exception(errCode));
                }

                // Allocate memory to hold ciphertext.
                cipherTextBytes = new byte[cipherTextBlob.DataLength];

                // Copy ciphertext from the BLOB to a byte array.
                Marshal.Copy(cipherTextBlob.DataPointer, cipherTextBytes, 0, cipherTextBlob.DataLength);
            }
            catch (Exception ex)
            {
                throw new CryptographicException("DPAPI was unable to encrypt data.", ex);
            }
            finally
            {
                // Free all memory allocated for BLOBs.
                plainTextBlob.Dispose();
                cipherTextBlob.Dispose();
                entropyBlob.Dispose();

                prompt.Dispose();
            }

            // Return the result.
            return cipherTextBytes;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private static byte[] DPAPIDecrypt(byte[] cipherText, byte[] entropy)
        {
            // Create BLOBs to hold data.
            var plainTextBlob = new DPAPINativeDATABLOB();
            var cipherTextBlob = new DPAPINativeDATABLOB();
            var entropyBlob = new DPAPINativeDATABLOB();

            // We only need prompt structure because it is a required parameter.
            var prompt = DPAPINativeCRYPTPROTECTPROMPTSTRUCT.Default();

            byte[] plainTextBytes;

            try
            {
                // Convert ciphertext bytes into a BLOB structure.
                cipherTextBlob = DPAPINativeDATABLOB.Init(cipherText);

                // Convert entropy bytes into a BLOB structure.
                entropyBlob = DPAPINativeDATABLOB.Init(entropy);

                // Initialize description string.
                string description = String.Empty;

                // Call DPAPI to decrypt data.
                bool success = UnprotectData(ref cipherTextBlob, ref description, ref entropyBlob, IntPtr.Zero, ref prompt,
                                             CRYPTPROTECT_UI_FORBIDDEN, ref plainTextBlob);

                // Check the result.
                if (!success)
                {
                    // If operation failed, retrieve last Win32 error.
                    int errCode = Marshal.GetLastWin32Error();

                    // Win32Exception will contain error message corresponding
                    // to the Windows error code.
                    throw new CryptographicException("CryptUnprotectData failed.", new Win32Exception(errCode));
                }

                // Allocate memory to hold plaintext.
                plainTextBytes = new byte[plainTextBlob.DataLength];

                // Copy ciphertext from the BLOB to a byte array.
                Marshal.Copy(plainTextBlob.DataPointer, plainTextBytes, 0, plainTextBlob.DataLength);
            }
            catch (Exception ex)
            {
                throw new CryptographicException("DPAPI was unable to decrypt data.", ex);
            }
            finally
            {
                // Free all memory allocated for BLOBs.
                plainTextBlob.Dispose();
                cipherTextBlob.Dispose();
                entropyBlob.Dispose();

                prompt.Dispose();
            }

            // Return the result.
            return plainTextBytes;
        }

        private static SecureString ToSecureString(IEnumerable<char> text)
        {
            var ss = new SecureString();

            foreach (char ch in text)
            {
                ss.AppendChar(ch);
            }

            ss.MakeReadOnly();

            return ss;
        }

        private static string ToString(SecureString secureString)
        {
            string text;

            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.SecureStringToBSTR(secureString);
                text = Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(ptr);
            }

            return text;
        }

        #endregion

        #region DPAPI Native Methods

        ///<summary>
        /// Performs encryption on the data in a <see cref="DPAPINativeDATABLOB"/> structure
        ///</summary>
        ///<param name="plainText">Structure that contains the plaintext to be encrypted.</param>
        ///<param name="description">A readable description of the data to be encrypted.</param>
        ///<param name="entropy">Structure that contains a password or other additional entropy used to encrypt the data.</param>
        ///<param name="reserved">Reserved for future use and must be set to NULL.</param>
        ///<param name="prompt">Structure that provides information about where and when prompts are to be displayed and what the content of those prompts should be.</param>
        ///<param name="flags">Crypt Protection</param>
        ///<param name="cipherText">Structure that receives the encrypted data.</param>
        ///<returns>If the function succeeds, then <c>TRUE</c> else <c>FALSE</c>.</returns>
        private static bool ProtectData(ref DPAPINativeDATABLOB plainText,
                                        string description,
                                        ref DPAPINativeDATABLOB entropy,
                                        IntPtr reserved,
                                        ref DPAPINativeCRYPTPROTECTPROMPTSTRUCT prompt,
                                        int flags,
                                        ref DPAPINativeDATABLOB cipherText)
        {
            return CryptProtectData(ref plainText, description, ref entropy, reserved, ref prompt, flags, ref cipherText);
        }

        // Wrapper for DPAPI CryptProtectData function.
        [DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptProtectData(ref DPAPINativeDATABLOB plainText,
                                                    string description,
                                                    ref DPAPINativeDATABLOB entropy,
                                                    IntPtr reserved,
                                                    ref DPAPINativeCRYPTPROTECTPROMPTSTRUCT prompt,
                                                    int flags,
                                                    ref DPAPINativeDATABLOB cipherText);

        ///<summary>
        /// Decrypts and does an integrity check of the data in a <see cref="DPAPINativeDATABLOB"/> structure
        ///</summary>
        ///<param name="cipherText">Structure that contains the encrypted data.</param>
        ///<param name="description">A readable description of the data to be encrypted.</param>
        ///<param name="entropy">Structure that contains a password or other additional entropy used to encrypt the data.</param>
        ///<param name="reserved">Reserved for future use and must be set to NULL.</param>
        ///<param name="prompt">Structure that provides information about where and when prompts are to be displayed and what the content of those prompts should be.</param>
        ///<param name="flags">Crypt Protection</param>
        ///<param name="plainText">Structure that receives the decrypted data.</param>
        ///<returns>If the function succeeds, then <c>TRUE</c> else <c>FALSE</c>.</returns>
        private static bool UnprotectData(ref DPAPINativeDATABLOB cipherText,
                                          ref string description,
                                          ref DPAPINativeDATABLOB entropy,
                                          IntPtr reserved,
                                          ref DPAPINativeCRYPTPROTECTPROMPTSTRUCT prompt,
                                          int flags,
                                          ref DPAPINativeDATABLOB plainText)
        {
            return CryptUnprotectData(ref cipherText, ref description, ref entropy, reserved, ref prompt, flags, ref plainText);
        }

        // Wrapper for DPAPI CryptUnprotectData function.
        [DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptUnprotectData(ref DPAPINativeDATABLOB cipherText,
                                                      ref string description,
                                                      ref DPAPINativeDATABLOB entropy,
                                                      IntPtr reserved,
                                                      ref DPAPINativeCRYPTPROTECTPROMPTSTRUCT prompt,
                                                      int flags,
                                                      ref DPAPINativeDATABLOB plainText);

        #endregion

        #region DPAPI Structures

        #region Nested type: DPAPINativeCryptProtectPromptFlags

        ///<summary>
        /// Indicates when prompts to the user are to be displayed.
        ///</summary>
        [Flags]
        private enum DPAPINativeCryptProtectPromptFlags
        {
            ///<summary>
            /// This flag can be combined with CRYPTPROTECT_PROMPT_ON_PROTECT to enforce the UI (user interface) policy of the caller. When CryptUnprotectData is called, the dwPromptFlags specified in the CryptProtectData call are enforced.
            ///</summary>
            PromptOnUnprotect = 0x1,

            ///<summary>
            /// This flag is used to provide the prompt for the protect phase.
            ///</summary>
            PromptOnProtect = 0x2
        }

        #endregion

        #region Nested type: DPAPINativeCRYPTPROTECTPROMPTSTRUCT

        /// <summary>
        /// Provides the text of a prompt and information about when and where that prompt is to be displayed when using the CryptProtectData and CryptUnprotectData functions.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct DPAPINativeCRYPTPROTECTPROMPTSTRUCT : IDisposable
        {
            /// <summary>
            /// The size, in bytes, of this structure.
            /// </summary>
            public int Size { get; set; }

            /// <summary>
            /// Indicates when prompts to the user are to be displayed.
            /// </summary>
            public DPAPINativeCryptProtectPromptFlags PromptFlags { get; set; }

            /// <summary>
            /// Window handle to the parent window.
            /// </summary>
            public IntPtr Handle { get; set; }

            /// <summary>
            /// A string containing the text of a prompt to be displayed.
            /// </summary>
            public string Prompt { get; set; }

            ///<summary>
            /// Creates a default instance of CRYPTPROTECT_PROMPTSTRUCT.
            ///</summary>
            ///<returns>The default instance of CRYPTPROTECT_PROMPTSTRUCT</returns>
            public static DPAPINativeCRYPTPROTECTPROMPTSTRUCT Default()
            {
                return new DPAPINativeCRYPTPROTECTPROMPTSTRUCT
                       {
                           Size = Marshal.SizeOf(typeof (DPAPINativeCRYPTPROTECTPROMPTSTRUCT)),
                           PromptFlags = 0,
                           Handle = IntPtr.Zero,
                           Prompt = null
                       };
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                if (Handle != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(Handle);
                }

                GC.SuppressFinalize(this);
            }
        }

        #endregion

        #region Nested type: DPAPINativeDATABLOB

        ///<summary>
        /// Structure that holds the encrypted data.
        ///</summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct DPAPINativeDATABLOB : IDisposable
        {
            ///<summary>
            /// Holds the length of the data
            ///</summary>
            public int DataLength { get; set; }

            ///<summary>
            /// Pointer to the byte string that contains the text to be encrypted.
            ///</summary>
            public IntPtr DataPointer { get; set; }

            ///<summary>
            /// Creates an empty DATA_BLOB.
            ///</summary>
            ///<returns>An empty DATA_BLOB</returns>
            public static DPAPINativeDATABLOB Null()
            {
                return new DPAPINativeDATABLOB
                       {
                           DataLength = 0,
                           DataPointer = IntPtr.Zero
                       };
            }

            ///<summary>
            /// Creates the structure that holds byte[] data to be encrypted.
            ///</summary>
            ///<param name="data">Data to be encrypted.</param>
            ///<returns>Structure that holds byte[] data to be encrypted.</returns>
            ///<exception cref="MemberAccessException">Unable to allocate data buffer for BLOB structure</exception>
            public static DPAPINativeDATABLOB Init(byte[] data)
            {
                // Use empty array for null parameter.
                if (data == null)
                {
                    data = new byte[0];
                }

                var blob = new DPAPINativeDATABLOB
                           {
                               DataPointer = Marshal.AllocHGlobal(data.Length),
                               DataLength = data.Length
                           };

                // Make sure that memory allocation was successful.
                // With the null check on the data parameter, I don't think this is needed.
                //if (blob.pbData == IntPtr.Zero)
                //    throw new MemberAccessException("Unable to allocate data buffer for BLOB structure.");

                // Copy data from original source to the BLOB structure.
                Marshal.Copy(data, 0, blob.DataPointer, data.Length);

                return blob;
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                if (DataPointer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(DataPointer);
                }

                GC.SuppressFinalize(this);
            }
        }

        #endregion

        #endregion

        ///<summary>
        /// Sets additional entropy used for encryption/decryption
        ///</summary>
        ///<param name="entropy">Additional entropy used for encryption/decryption</param>
        public DPAPIEngine SetEntropy(string entropy)
        {
            Entropy = ToSecureString(entropy);

            return this;
        }

        ///<summary>
        /// Sets additional entropy used for encryption/decryption
        ///</summary>
        ///<param name="entropy">Additional entropy used for encryption/decryption</param>
        public DPAPIEngine SetEntropy(SecureString entropy)
        {
            entropy.MakeReadOnly();
            Entropy = entropy;

            return this;
        }

        ///<summary>
        /// Sets character encoding to use during encryption/decryption.
        ///</summary>
        ///<param name="encoding">Character encoding to use during encryption/decryption.</param>
        ///<exception cref="ArgumentNullException">encoding is null</exception>
        public DPAPIEngine SetEncoding(Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "encoding cannot be null");
            }

            Encoding = encoding;

            return this;
        }
    }
}