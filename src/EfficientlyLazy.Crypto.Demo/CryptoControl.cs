using System.Windows.Forms;

namespace EfficientlyLazy.Crypto.Demo
{
    public class CryptoUserControl : UserControl
    {
        public virtual string DisplayName { get; private set; }

        public virtual string Encrypt(string clearText)
        {
            return string.Empty;
        }

        public virtual string Decrypt(string encryptedText)
        {
            return string.Empty;
        }
    }
}