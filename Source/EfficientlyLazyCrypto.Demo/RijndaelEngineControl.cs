using System;
using System.Text;
using System.Windows.Forms;

namespace EfficientlyLazyCrypto.Demo
{
    public partial class RijndaelEngineControl : UserControl
    {
        public RijndaelEngineControl()
        {
            InitializeComponent();

            cbxKeySize.DataSource = EnumerationConversions.GetEnumDescriptions(typeof(RijndaelKeySize));
            cbxKeySize.SelectedItem = EnumerationConversions.GetEnumDescription(RijndaelKeySize.Key256Bit);

            cbxEncoding.DisplayMember = "EncodingName";
            cbxEncoding.Items.Add(Encoding.ASCII);
            cbxEncoding.Items.Add(Encoding.Unicode);
            cbxEncoding.Items.Add(Encoding.UTF32);
            cbxEncoding.Items.Add(Encoding.UTF7);
            cbxEncoding.Items.Add(Encoding.UTF8);
            cbxEncoding.SelectedItem = Encoding.UTF32;

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

        private void RijndaelEngineControl_Load(object sender, EventArgs e)
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
            RijndaelKeySize keySize = EnumerationConversions.GetEnumName<RijndaelKeySize>(cbxKeySize.SelectedItem.ToString());

            return new RijndaelEngine(txtKey.Text)
                .SetKeySize(keySize)
                .SetInitVector(txtInitVector.Text)
                .SetSalt(txtSalt.Text)
                .SetRandomSaltLength((int) nudSaltMin.Value, (int) nudSaltMax.Value)
                .SetPasswordIterations((int) nudIterations.Value)
                .SetEncoding(cbxEncoding.SelectedItem as Encoding);
        }
    }
}
