using System;
using System.Text;
using System.Windows.Forms;

namespace EfficientlyLazyCrypto.Demo
{
    public partial class DPAPIEngineControl : UserControl
    {
        public DPAPIEngineControl()
        {
            InitializeComponent();

            cbxKeyType.DataSource = EnumerationConversions.GetEnumDescriptions(typeof(DPAPIKeyType));
            cbxKeyType.SelectedItem = EnumerationConversions.GetEnumDescription(DPAPIKeyType.UserKey);

            cbxEncoding.DisplayMember = "EncodingName";
            cbxEncoding.Items.Add(Encoding.ASCII);
            cbxEncoding.Items.Add(Encoding.Unicode);
            cbxEncoding.Items.Add(Encoding.UTF32);
            cbxEncoding.Items.Add(Encoding.UTF7);
            cbxEncoding.Items.Add(Encoding.UTF8);
            cbxEncoding.SelectedItem = Encoding.UTF32;
        }

        private void DPAPIEngineControl_Load(object sender, EventArgs e)
        {

        }

        private void cmdEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                ICryptoEngine engine = GenerateEngine();

                rtxtEncrypted.Text = engine.Encrypt(rtxtClear.Text);
            }
            catch (Exception ex)
            {
                rtxtEncrypted.Text = string.Empty;

                MessageBox.Show(ex.Message, "Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                ICryptoEngine engine = GenerateEngine();

                rtxtClear.Text = engine.Decrypt(rtxtEncrypted.Text);
            }
            catch (Exception ex)
            {
                rtxtClear.Text = string.Empty;

                MessageBox.Show(ex.Message, "Decryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ICryptoEngine GenerateEngine()
        {
            DPAPIKeyType keyType = EnumerationConversions.GetEnumName<DPAPIKeyType>(cbxKeyType.SelectedItem.ToString());

            return new DPAPIEngine(keyType)
                .SetEntropy(txtEntropy.Text)
                .SetEncoding(cbxEncoding.SelectedItem as Encoding);
        }
    }
}
