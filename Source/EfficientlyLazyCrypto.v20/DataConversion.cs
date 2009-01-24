using System;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace EfficientlyLazyCrypto
{
    /// <summary>
    /// Drives the conversion of a <see cref="SecureString"/> to and from a <see cref="string"/> or <see cref="byte"/>[]. 
    /// </summary>
    public static class DataConversion
    {
        /// <summary>
        /// Converts the <see cref="string"/> to a <see cref="SecureString"/>.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to convert.</param>
        /// <returns><see cref="SecureString"/> <c>NOT</c> marked as read only.</returns>
        public static SecureString ToSecureString(string text)
        {
            return ToSecureString(text, false);
        }

        /// <summary>
        /// Converts the <see cref="string"/> to a <see cref="SecureString"/>.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to convert.</param>
        /// <param name="makeReadOnly">If set to <c>true</c> makes the returned <see cref="SecureString"/> read only.</param>
        /// <returns><see cref="SecureString"/></returns>
        public static SecureString ToSecureString(string text, bool makeReadOnly)
        {
            var ss = new SecureString();

            foreach (char ch in text)
            {
                ss.AppendChar(ch);
            }

            if (makeReadOnly) ss.MakeReadOnly();

            return ss;
        }

        /// <summary>
        /// Converts the <see cref="SecureString"/> to a <see cref="string"/>.
        /// </summary>
        /// <param name="secureString">The <see cref="SecureString"/> to convert.</param>
        /// <returns><see cref="string"/></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static string ToString(SecureString secureString)
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

        /// <summary>
        /// Converts the <see cref="SecureString"/> to a <see cref="byte"/>[].
        /// </summary>
        /// <param name="secureString">The <see cref="SecureString"/> to convert.</param>
        /// <returns><see cref="byte"/>[]</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static byte[] ToBytes(SecureString secureString)
        {
            return Encoding.UTF8.GetBytes(ToString(secureString));
        }

        /// <summary>
        /// Converts the <see cref="SecureString"/> to a <see cref="byte"/>[].
        /// </summary>
        ///<param name="secureString">The <see cref="SecureString"/> to convert.</param>
        ///<param name="encoding">Character encoding to use.</param>
        ///<returns><see cref="byte"/>[]</returns>
        public static byte[] ToBytes(SecureString secureString, Encoding encoding)
        {
            return encoding.GetBytes(ToString(secureString));
        }
    }
}