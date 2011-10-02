using System;
using System.Text;

namespace EfficientlyLazy.Crypto.Demo
{
    public partial class DPAPIEngineControl : CryptoUserControl
    {
        public DPAPIEngineControl()
        {
            InitializeComponent();

            cbxKeyType.DataSource = EnumerationConversions.GetEnumDescriptions(typeof (KeyType));
            cbxKeyType.SelectedItem = EnumerationConversions.GetEnumDescription(KeyType.UserKey);

            cbxEncoding.DisplayMember = "EncodingName";
            cbxEncoding.Items.Add(Encoding.ASCII);
            cbxEncoding.Items.Add(Encoding.Default);
            cbxEncoding.Items.Add(Encoding.Unicode);
            cbxEncoding.Items.Add(Encoding.UTF32);
            cbxEncoding.Items.Add(Encoding.UTF7);
            cbxEncoding.Items.Add(Encoding.UTF8);
            cbxEncoding.SelectedItem = Encoding.Default;
        }

        public override string DisplayName
        {
            get
            {
                return "DPAPI Encryption/Decryption";
            }
        }

        private void DPAPIEngineControl_Load(object sender, EventArgs e)
        {
        }

        private ICryptoEngine GenerateEngine()
        {
            KeyType keyType = EnumerationConversions.GetEnumName<KeyType>(cbxKeyType.SelectedItem.ToString());

            return new DPAPIEngine(keyType)
                .SetEntropy(txtEntropy.Text)
                .SetEncoding(cbxEncoding.SelectedItem as Encoding);
        }

        public override string Encrypt(string clearText)
        {
            ICryptoEngine engine = GenerateEngine();

            return engine.Encrypt(clearText);
        }

        public override string Decrypt(string encryptedText)
        {
            ICryptoEngine engine = GenerateEngine();

            return engine.Decrypt(encryptedText);
        }
    }
}