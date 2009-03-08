using System;
using System.Runtime.InteropServices;

namespace EfficientlyLazyCrypto
{
    ///<summary>
    /// Structure that holds the encrypted data.
    ///</summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct DPAPINative_DATA_BLOB : IDisposable
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
        public static DPAPINative_DATA_BLOB Null()
        {
            return new DPAPINative_DATA_BLOB
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
        public static DPAPINative_DATA_BLOB Init(byte[] data)
        {
            // Use empty array for null parameter.
            if (data == null) data = new byte[0];

            var blob = new DPAPINative_DATA_BLOB
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
}