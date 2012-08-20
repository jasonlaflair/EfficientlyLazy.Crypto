using System;
using System.Windows.Forms;

namespace EfficientlyLazy.Crypto.Demo.UserControls
{
    public class CryptoUserControl : UserControl
    {
        public virtual string DisplayName
        {
            get
            {
                throw new InvalidOperationException("Method needs to be overridden");
            }
        }

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

        protected virtual bool ValidateParameters()
        {
            throw new InvalidOperationException("Method needs to be overridden");
        }

        public virtual bool CanEncrypt
        {
            get
            {
                throw new InvalidOperationException("Method needs to be overridden");
            }
        }

        protected virtual string EngineEncrypt(string clearText)
        {
            throw new InvalidOperationException("Method needs to be overridden");
        }

        public virtual bool CanDecrypt
        {
            get
            {
                throw new InvalidOperationException("Method needs to be overridden");
            }
        }

        protected virtual string EngineDecrypt(string encryptedText)
        {
            throw new InvalidOperationException("Method needs to be overridden");
        }
    }
}