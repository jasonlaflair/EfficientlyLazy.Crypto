using System;
using System.Text;
using System.Windows.Forms;
using EfficientlyLazy.Crypto.Engines;

namespace EfficientlyLazy.Crypto.Demo.UserControls
{
    public partial class AesEngineControl : CryptoUserControl
    {
        public AesEngineControl()
        {
            InitializeComponent();

            cmbKeySize.DataSource = EnumerationConversions.GetEnumDescriptions(typeof(AesKeySize));
            cmbKeySize.SelectedItem = EnumerationConversions.GetEnumDescription(AesKeySize.Key256Bit);

            cmbEncoding.DisplayMember = "EncodingName";
            cmbEncoding.Items.Add(Encoding.ASCII);
            cmbEncoding.Items.Add(Encoding.Unicode);
            cmbEncoding.Items.Add(Encoding.Default);
            cmbEncoding.Items.Add(Encoding.UTF32);
            cmbEncoding.Items.Add(Encoding.UTF7);
            cmbEncoding.Items.Add(Encoding.UTF8);
            cmbEncoding.SelectedItem = Encoding.UTF8;

            cmbHashAlgorithm.DataSource = EnumerationConversions.GetEnumDescriptions(typeof(HashType));
            cmbKeySize.SelectedItem = EnumerationConversions.GetEnumDescription(HashType.None);

            nudSaltMin.Minimum = 0;
            nudSaltMin.Maximum = int.MaxValue;
            nudSaltMin.Value = 0;

            nudSaltMax.Minimum = 0;
            nudSaltMax.Maximum = int.MaxValue;
            nudSaltMax.Value = 0;

            nudIterations.Minimum = 1;
            nudIterations.Maximum = int.MaxValue;
            nudIterations.Value = 10;
        }

        public override string DisplayName { get { return "AES Encryption/Decryption"; } }

        private void AESEngineControl_Load(object sender, EventArgs e)
        {

        }

        private ICryptoEngine GenerateEngine()
        {
            var engine = new AesEngine(txtKey.Text);

            if (cbxUseKeySize.Checked)
            {
                var keySize = EnumerationConversions.GetEnumName<AesKeySize>(cmbKeySize.SelectedItem.ToString());

                engine.SetKeySize(keySize);
            }

            if (cbxUseInitVector.Checked)
            {
                engine.SetInitVector(txtInitVector.Text);
            }

            if (cbxUseKeySalt.Checked)
            {
                engine.SetSalt(txtSalt.Text);
            }

            if (cbxUseRandomSalt.Checked)
            {
                engine.SetRandomSaltLength((int)nudSaltMin.Value, (int)nudSaltMax.Value);
            }

            if (cbxUsePasswordIterations.Checked)
            {
                engine.SetIterations((int)nudIterations.Value);
            }

            if (cbxUseEncoding.Checked)
            {
                engine.SetEncoding(cmbEncoding.SelectedItem as Encoding);
            }

            if (cbxUseHashAlgorithm.Checked)
            {
                engine.SetHashAlgorithm((HashType)cmbHashAlgorithm.SelectedItem);
            }

            return engine;
        }

        protected override bool ValidateParameters()
        {
            var valid = false;

            if (cbxUseInitVector.Checked && txtInitVector.Text.Length != 16)
            {
                MessageBox.Show("Init Vector must be 16 characters", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbxUseKeySalt.Checked && string.IsNullOrEmpty(txtSalt.Text))
            {
                MessageBox.Show("Key Salt value must be specified if used", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbxUseRandomSalt.Checked && nudSaltMin.Value > nudSaltMax.Value)
            {
                MessageBox.Show("Minimum Salt value can not exceed Maximum Salt value", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbxUseHashAlgorithm.Checked && cmbHashAlgorithm.SelectedIndex == 0)
            {
                MessageBox.Show("Hash Algorithm required if selected", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        public override bool CanEncrypt { get { return true; } }

        protected override string EngineEncrypt(string clearText)
        {
            var engine = GenerateEngine();

            return engine.Encrypt(clearText);
        }

        public override bool CanDecrypt { get { return true; } }

        protected override string EngineDecrypt(string encryptedText)
        {
            var engine = GenerateEngine();

            return engine.Decrypt(encryptedText);
        }

        private void cbxUseKeySize_CheckedChanged(object sender, EventArgs e)
        {
            cmbKeySize.Enabled = cbxUseKeySize.Checked;
        }

        private void cbxUseInitVector_CheckedChanged(object sender, EventArgs e)
        {
            txtInitVector.Enabled = cbxUseInitVector.Checked;
        }

        private void cbxUseKeySalt_CheckedChanged(object sender, EventArgs e)
        {
            txtSalt.Enabled = cbxUseKeySalt.Checked;
        }

        private void cbxUseRandomSalt_CheckedChanged(object sender, EventArgs e)
        {
            nudSaltMin.Enabled = cbxUseRandomSalt.Checked;
            nudSaltMax.Enabled = cbxUseRandomSalt.Checked;
        }

        private void cbxUsePasswordIterations_CheckedChanged(object sender, EventArgs e)
        {
            nudIterations.Enabled = cbxUsePasswordIterations.Checked;
        }

        private void cbxUseEncoding_CheckedChanged(object sender, EventArgs e)
        {
            cmbEncoding.Enabled = cbxUseEncoding.Checked;
        }

        private void cbxUseHashAlgorithm_CheckedChanged(object sender, EventArgs e)
        {
            cmbHashAlgorithm.Enabled = cbxUseHashAlgorithm.Checked;
        }
    }
}