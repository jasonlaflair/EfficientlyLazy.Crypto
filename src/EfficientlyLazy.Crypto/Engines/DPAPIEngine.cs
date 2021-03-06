﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using EfficientlyLazy.Crypto.Configuration;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary>
    /// Encryption/Decryption using the windows crypto API.
    /// </summary>
    public sealed class DPAPIEngine : ICryptoEngine
    {
        ///<summary>
        /// Initializes a new instance of the <see cref="DPAPIEngine"/> object.
        ///</summary>
        ///<param name="keyType">Defines the method (<see cref="DPAPIKeyType"/>) to use for encryption/decryption.</param>
        public DPAPIEngine(DPAPIKeyType keyType)
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
        /// Method (<see cref="DPAPIKeyType"/>) to use for encryption/decryption.
        ///</summary>
        public DPAPIKeyType KeyType { get; private set; }

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
        public byte[] Encrypt(byte[] plaintext)
        {
            return DPAPIEncrypt(KeyType, plaintext, Encoding.GetBytes(ToString(Entropy)));
        }

        /// <summary>
        /// Encrypts the specified plain text to a string.
        /// </summary>
        /// <param name="plaintext">The plain text to encrypt.</param>
        /// <returns>String of encrypted data.</returns>
        public string Encrypt(string plaintext)
        {
            return Convert.ToBase64String(Encrypt(Encoding.GetBytes(plaintext)));
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] cipherText)
        {
            return DPAPIDecrypt(cipherText, Encoding.GetBytes(ToString(Entropy)));
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public string Decrypt(string cipherText)
        {
            return Encoding.GetString(Decrypt(Convert.FromBase64String(cipherText)));
        }

        private static SecureSection GetSecureConfigSection()
        {
            ConfigurationManager.RefreshSection("SecureConfig");
            return (SecureSection)ConfigurationManager.GetSection("SecureConfig");
        }

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        ///<returns></returns>
        public string GetSetting(string key)
        {
            var config = GetSecureConfigSection();

            if (config == null)
            {
                return string.Empty;
            }

            var setting = config.Settings[key];

            if (setting == null)
            {
                return string.Empty;
            }

            return setting.IsEncrypted ? Decrypt(setting.Value) : setting.Value;
        }

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        ///<returns></returns>
        public SqlConnectionStringBuilder GetSqlConnectionString(string key)
        {
            var config = GetSecureConfigSection();

            if (config == null)
            {
                return null;
            }

            var conn = config.SqlConnectionStrings[key];

            return conn == null ? null : conn.GetBuilder(this);
        }

        #endregion

        #region DPAPI Helper functions

        // DPAPI key initialization flags.
        private const int CRYPTPROTECT_LOCAL_MACHINE = 0x4;
        private const int CRYPTPROTECT_UI_FORBIDDEN = 0x1;

        private static byte[] DPAPIEncrypt(DPAPIKeyType keyType, byte[] plainTextBytes, byte[] entropyBytes)
        {
            // Create Null BLOBs to hold data, they will be initialized later.
            var plainTextBlob = DPAPINativeDataBlob.Null();
            var cipherTextBlob = DPAPINativeDataBlob.Null();
            var entropyBlob = DPAPINativeDataBlob.Null();

            // We only need prompt structure because it is a required parameter.
            var prompt = DPAPINativeCryptPotectPromptStruct.Default();

            byte[] cipherTextBytes;

            try
            {
                // Convert plaintext bytes into a BLOB structure.
                plainTextBlob = DPAPINativeDataBlob.Init(plainTextBytes); // InitBLOB(plainTextBytes);

                // Convert entropy bytes into a BLOB structure.
                entropyBlob = DPAPINativeDataBlob.Init(entropyBytes); // InitBLOB(entropyBytes);

                // Disable any types of UI.
                var flags = CRYPTPROTECT_UI_FORBIDDEN;

                // When using machine-specific key, set up machine flag.
                if (keyType == DPAPIKeyType.MachineKey)
                {
                    flags |= CRYPTPROTECT_LOCAL_MACHINE;
                }

                // Call DPAPI to encrypt data.
                var success = CryptProtectData(ref plainTextBlob, string.Empty, ref entropyBlob, IntPtr.Zero, ref prompt, flags, ref cipherTextBlob);

                // Check the result.
                if (!success)
                {
                    // If operation failed, retrieve last Win32 error.
                    var errCode = Marshal.GetLastWin32Error();

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

        private static byte[] DPAPIDecrypt(byte[] cipherText, byte[] entropy)
        {
            // Create BLOBs to hold data.
            var plainTextBlob = new DPAPINativeDataBlob();
            var cipherTextBlob = new DPAPINativeDataBlob();
            var entropyBlob = new DPAPINativeDataBlob();

            // We only need prompt structure because it is a required parameter.
            var prompt = DPAPINativeCryptPotectPromptStruct.Default();

            byte[] plainTextBytes;

            try
            {
                // Convert ciphertext bytes into a BLOB structure.
                cipherTextBlob = DPAPINativeDataBlob.Init(cipherText);

                // Convert entropy bytes into a BLOB structure.
                entropyBlob = DPAPINativeDataBlob.Init(entropy);

                // Initialize description string.
                var description = String.Empty;

                // Call DPAPI to decrypt data.
                var success = CryptUnprotectData(ref cipherTextBlob, ref description, ref entropyBlob, IntPtr.Zero, ref prompt, CRYPTPROTECT_UI_FORBIDDEN, ref plainTextBlob);

                // Check the result.
                if (!success)
                {
                    // If operation failed, retrieve last Win32 error.
                    var errCode = Marshal.GetLastWin32Error();

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

            foreach (var ch in text)
            {
                ss.AppendChar(ch);
            }

            ss.MakeReadOnly();

            return ss;
        }

        private static string ToString(SecureString secureString)
        {
            string text;

            var ptr = IntPtr.Zero;

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

        // Wrapper for DPAPI CryptProtectData function.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptProtectData(ref DPAPINativeDataBlob plainText,
                                                    string description,
                                                    ref DPAPINativeDataBlob entropy,
                                                    IntPtr reserved,
                                                    ref DPAPINativeCryptPotectPromptStruct prompt,
                                                    int flags,
                                                    ref DPAPINativeDataBlob cipherText);

        // Wrapper for DPAPI CryptUnprotectData function.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptUnprotectData(ref DPAPINativeDataBlob cipherText,
                                                      ref string description,
                                                      ref DPAPINativeDataBlob entropy,
                                                      IntPtr reserved,
                                                      ref DPAPINativeCryptPotectPromptStruct prompt,
                                                      int flags,
                                                      ref DPAPINativeDataBlob plainText);

        #endregion

        #region DPAPI Structures

        #region Nested type: DPAPINativeCryptProtectPromptFlags

        ///<summary>
        /// Indicates when prompts to the user are to be displayed.
        ///</summary>
        [Flags]
        internal enum DPAPINativeCryptProtectPromptFlags
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
        internal struct DPAPINativeCryptPotectPromptStruct : IDisposable
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
            public static DPAPINativeCryptPotectPromptStruct Default()
            {
                return new DPAPINativeCryptPotectPromptStruct
                       {
                           Size = Marshal.SizeOf(typeof(DPAPINativeCryptPotectPromptStruct)),
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
            }
        }

        #endregion

        #region Nested type: DPAPINativeDATABLOB

        ///<summary>
        /// Structure that holds the encrypted data.
        ///</summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct DPAPINativeDataBlob : IDisposable
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
            public static DPAPINativeDataBlob Null()
            {
                return new DPAPINativeDataBlob
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
            public static DPAPINativeDataBlob Init(byte[] data)
            {
                // Use empty array for null parameter.
                if (data == null)
                {
                    data = new byte[0];
                }

                var blob = new DPAPINativeDataBlob
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

        #region Dispose

        private bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            // This object will be cleaned up by the Dispose method. 
            // Therefore, you should call GC.SupressFinalize to 
            // take this object off the finalization queue 
            // and prevent finalization code for this object 
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if (!_disposed)
            {
                // If disposing equals true, dispose all managed and unmanaged resources. 
                if (disposing)
                {
                    Entropy.Dispose();
                }

                // Call the appropriate methods to clean up unmanaged resources here. 
                // If disposing is false, only the following code is executed.
                

                // Note disposing has been done.
                _disposed = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~DPAPIEngine()
        {
            // Do not re-create Dispose clean-up code here. 
            // Calling Dispose(false) is optimal in terms of 
            // readability and maintainability.
            Dispose(false);
        }

        #endregion
    }
}