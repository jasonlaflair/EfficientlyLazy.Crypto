using System.Windows.Forms;

namespace EfficientlyLazy.Crypto.Demo.UserControls
{
    public abstract class CryptoUserControl : UserControl
    {
        public abstract string DisplayName { get; }

        public virtual string Encrypt(string clearText)
        {
            return ValidateParameters()
                       ? EngineEncrypt(clearText)
                       : string.Empty;
        }

        public virtual string Decrypt(string encryptedText)
        {
            return ValidateParameters()
                       ? EngineDecrypt(encryptedText)
                       : string.Empty;
        }

        protected abstract bool ValidateParameters();

        public abstract bool CanEncrypt { get; }
        protected abstract string EngineEncrypt(string clearText);

        public abstract bool CanDecrypt { get; }
        protected abstract string EngineDecrypt(string encryptedText);
    }
}