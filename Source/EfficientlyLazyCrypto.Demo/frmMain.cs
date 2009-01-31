using System;
using System.Windows.Forms;

namespace EfficientlyLazyCrypto.Demo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            cbxRijndaelKeySize.DataSource = EnumerationConversions.GetEnumDescriptions(typeof(RijndaelKeySize));

            nudRijndaelSaltMin.Minimum = 0;
            nudRijndaelSaltMin.Maximum = RijndaelParameters.MINIMUM_SET_SALT_LENGTH;
            nudRijndaelSaltMin.Value = 0;

            nudRijndaelSaltMax.Minimum = 0;
            nudRijndaelSaltMax.Maximum = RijndaelParameters.MAXIMUM_SET_SALT_LENGTH;
            nudRijndaelSaltMax.Value = 0;

            nudRijndaelPassIterations.Minimum = 1;
            nudRijndaelPassIterations.Maximum = 10000;
            nudRijndaelPassIterations.Value = 1;

            cmbDPAPIKeyType.DataSource = EnumerationConversions.GetEnumDescriptions(typeof(DPAPIKeyType));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void cmdRijndaelEncrypt_Click(object sender, EventArgs e)
        {
            RijndaelKeySize keySize = EnumerationConversions.GetEnumName<RijndaelKeySize>(cbxRijndaelKeySize.SelectedItem.ToString());

            IRijndaelParameters parameters = new RijndaelParameters(txtRijndaelKey.Text, txtRijndaelInitVector.Text, (byte)nudRijndaelSaltMin.Value, (byte)nudRijndaelSaltMax.Value, txtRijndaelKeySalt.Text, keySize, (byte)nudRijndaelPassIterations.Value);
            ICryptoEngine engine;

            try
            {
                engine = new RijndaelEngine(parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n\r\n{1}", ex.Message, ex), "Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                txtRijndaelEncrypted.Text = engine.Encrypt(txtRijndaelClearText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n\r\n{1}", ex.Message, ex), "Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRijndaelEncrypted.Text = string.Empty;
            }
        }

        private void cmdRijndaelDecrypt_Click(object sender, EventArgs e)
        {
            RijndaelKeySize keySize = EnumerationConversions.GetEnumName<RijndaelKeySize>(cbxRijndaelKeySize.SelectedItem.ToString());

            IRijndaelParameters parameters = new RijndaelParameters(txtRijndaelKey.Text, txtRijndaelInitVector.Text, (byte)nudRijndaelSaltMin.Value, (byte)nudRijndaelSaltMax.Value, txtRijndaelKeySalt.Text, keySize, (byte)nudRijndaelPassIterations.Value);
            ICryptoEngine engine;

            try
            {
                engine = new RijndaelEngine(parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n\r\n{1}", ex.Message, ex), "Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                txtRijndaelClearText.Text = engine.Decrypt(txtRijndaelEncrypted.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n\r\n{1}", ex.Message, ex), "Decryption Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRijndaelClearText.Text = string.Empty;
            }
        }

        private void cmdDPAPIEncrypt_Click(object sender, EventArgs e)
        {
            DPAPIKeyType keyType = EnumerationConversions.GetEnumName<DPAPIKeyType>(cmbDPAPIKeyType.SelectedItem.ToString());

            IDPAPIParameters parameters = new DPAPIParameters(keyType, txtDPAPIEntropy.Text);
            ICryptoEngine engine;

            try
            {
                engine = new DPAPIEngine(parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n\r\n{1}", ex.Message, ex), "Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                txtDPAPIEncrypted.Text = engine.Encrypt(txtDPAPIClearText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n\r\n{1}", ex.Message, ex), "Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDPAPIEncrypted.Text = string.Empty;
            }
        }

        private void cmdDPAPIDecrypt_Click(object sender, EventArgs e)
        {
            DPAPIKeyType keyType = EnumerationConversions.GetEnumName<DPAPIKeyType>(cmbDPAPIKeyType.SelectedItem.ToString());

            IDPAPIParameters parameters = new DPAPIParameters(keyType, txtDPAPIEntropy.Text);
            ICryptoEngine engine;

            try
            {
                engine = new DPAPIEngine(parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n\r\n{1}", ex.Message, ex), "Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                txtDPAPIClearText.Text = engine.Decrypt(txtDPAPIEncrypted.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n\r\n{1}", ex.Message, ex), "Decryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDPAPIClearText.Text = string.Empty;
            }
        }
    }
}
