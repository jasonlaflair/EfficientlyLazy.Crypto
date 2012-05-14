using System;
using System.Text;

namespace EfficientlyLazy.Crypto.Demo.UserControls
{
    public partial class DPAPIEngineControl : CryptoUserControl
    {
        public DPAPIEngineControl()
        {
            InitializeComponent();

            cmbKeyType.DataSource = EnumerationConversions.GetEnumDescriptions(typeof (KeyType));
            cmbKeyType.SelectedItem = EnumerationConversions.GetEnumDescription(KeyType.UserKey);

            cmbEncoding.DisplayMember = "EncodingName";
            cmbEncoding.Items.Add(Encoding.ASCII);
            cmbEncoding.Items.Add(Encoding.Default);
            cmbEncoding.Items.Add(Encoding.Unicode);
            cmbEncoding.Items.Add(Encoding.UTF32);
            cmbEncoding.Items.Add(Encoding.UTF7);
            cmbEncoding.Items.Add(Encoding.UTF8);
            cmbEncoding.SelectedItem = Encoding.Default;
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
            var keyType = EnumerationConversions.GetEnumName<KeyType>(cmbKeyType.SelectedItem.ToString());

            var engine = new DPAPIEngine(keyType);

            if (cbxUseEntropy.Checked)
            {
                engine.SetEntropy(txtEntropy.Text);
            }

            if (cbxUseEncoding.Checked)
            {
                engine.SetEncoding(cmbEncoding.SelectedItem as Encoding);
            }

            return engine;
        }

        protected override bool ValidateParameters()
        {
            return true;
        }

        public override bool CanEncrypt { get { return true; } }

        protected override string EngineEncrypt(string clearText)
        {
            ICryptoEngine engine = GenerateEngine();

            return engine.Encrypt(clearText);
        }

        public override bool CanDecrypt { get { return true; } }

        protected override string EngineDecrypt(string encryptedText)
        {
            ICryptoEngine engine = GenerateEngine();

            return engine.Decrypt(encryptedText);
        }

        private void cbxUseEntropy_CheckedChanged(object sender, EventArgs e)
        {
            txtEntropy.Enabled = cbxUseEntropy.Checked;
        }

        private void cbxUseEncoding_CheckedChanged(object sender, EventArgs e)
        {
            cmbEncoding.Enabled = cbxUseEncoding.Checked;
        }
    }
}