using System.Security.Permissions;

namespace EfficientlyLazyCrypto
{
   /// <summary>
   /// Encryption/Decryption interface
   /// </summary>
   public interface ICryptoEngine
   {
      /// <summary>
      /// Encrypts the specified plain text.
      /// </summary>
      /// <param name="plaintext">The plain text.</param>
      /// <returns></returns>
      [SecurityPermission(SecurityAction.LinkDemand,Flags=SecurityPermissionFlag.UnmanagedCode)]
      byte[] Encrypt(byte[] plaintext);

      /// <summary>
      /// Encrypts the specified plain text.
      /// </summary>
      /// <param name="plaintext">The plain text.</param>
      /// <returns></returns>
      [SecurityPermission(SecurityAction.LinkDemand,Flags=SecurityPermissionFlag.UnmanagedCode)]
      string Encrypt(string plaintext);

      /// <summary>
      /// Encrypts the specified input file.
      /// </summary>
      /// <param name="inputFile">The input file.</param>
      /// <param name="outputFile">The encrypted file.</param>
      /// <returns></returns>
      [SecurityPermission(SecurityAction.LinkDemand,Flags=SecurityPermissionFlag.UnmanagedCode)]
      bool Encrypt(string inputFile,string outputFile);

      /// <summary>
      /// Decrypts the specified cipher text.
      /// </summary>
      /// <param name="cipherText">The cipher text.</param>
      /// <returns></returns>
      [SecurityPermission(SecurityAction.LinkDemand,Flags=SecurityPermissionFlag.UnmanagedCode)]
      byte[] Decrypt(byte[] cipherText);

      /// <summary>
      /// Decrypts the specified cipher text.
      /// </summary>
      /// <param name="cipherText">The cipher text.</param>
      /// <returns></returns>
      [SecurityPermission(SecurityAction.LinkDemand,Flags=SecurityPermissionFlag.UnmanagedCode)]
      string Decrypt(string cipherText);

      /// <summary>
      /// Decrypts the specified encrypted file.
      /// </summary>
      /// <param name="inputFile">The encrypted file.</param>
      /// <param name="outputFile">The output file.</param>
      /// <returns></returns>
      [SecurityPermission(SecurityAction.LinkDemand,Flags=SecurityPermissionFlag.UnmanagedCode)]
      bool Decrypt(string inputFile,string outputFile);
   }
}