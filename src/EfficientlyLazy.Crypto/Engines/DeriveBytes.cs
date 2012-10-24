using System;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto.Engines
{
    internal static class DeriveBytes
    {
        public static byte[] Generate<T>(string key, byte[] saltValueBytes, HashType hashType, int passwordIterations, T keySize)
        {
            byte[] keyBytes;
            PasswordDeriveBytes password = null;

            try
            {
                password = new PasswordDeriveBytes(key, saltValueBytes, hashType.ToString(), passwordIterations);

#pragma warning disable 612,618
                keyBytes = password.GetBytes(Convert.ToInt32(keySize) / 8);
#pragma warning restore 612,618
            }
            finally
            {
#if !NET20 && !NET35
                if (password != null) password.Dispose();
#endif
            }

            return keyBytes;
        }

        public static byte[] Generate<T>(string key, byte[] saltValueBytes, int passwordIterations, T keySize)
        {
            byte[] keyBytes;
            Rfc2898DeriveBytes password = null;

            try
            {
                password = new Rfc2898DeriveBytes(key, saltValueBytes, passwordIterations);

                keyBytes = password.GetBytes(Convert.ToInt32(keySize) / 8);
            }
            finally
            {
#if !NET20 && !NET35
                if (password != null) password.Dispose();
#endif
            }

            return keyBytes;
        }
    }
}