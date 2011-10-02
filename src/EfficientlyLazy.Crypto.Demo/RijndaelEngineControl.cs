using System;
using System.Text;

namespace EfficientlyLazy.Crypto.Demo
{
    public partial class RijndaelEngineControl : CryptoUserControl
    {
        public RijndaelEngineControl()
        {
            InitializeComponent();

            cbxKeySize.DataSource = EnumerationConversions.GetEnumDescriptions(typeof (KeySize));
            cbxKeySize.SelectedItem = EnumerationConversions.GetEnumDescription(KeySize.Key256Bit);

            cbxEncoding.DisplayMember = "EncodingName";
            cbxEncoding.Items.Add(Encoding.ASCII);
            cbxEncoding.Items.Add(Encoding.Unicode);
            cbxEncoding.Items.Add(Encoding.Default);
            cbxEncoding.Items.Add(Encoding.UTF32);
            cbxEncoding.Items.Add(Encoding.UTF7);
            cbxEncoding.Items.Add(Encoding.UTF8);
            cbxEncoding.SelectedItem = Encoding.Default;

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

        public override string DisplayName
        {
            get
            {
                return "Rijndael Encryption/Decryption";
            }
        }

        private void RijndaelEngineControl_Load(object sender, EventArgs e)
        {
        }

        private ICryptoEngine GenerateEngine()
        {
            KeySize keySize = EnumerationConversions.GetEnumName<KeySize>(cbxKeySize.SelectedItem.ToString());

            return new RijndaelEngine(txtKey.Text)
                .SetKeySize(keySize)
                .SetInitVector(txtInitVector.Text)
                .SetSalt(txtSalt.Text)
                .SetRandomSaltLength((int)nudSaltMin.Value, (int)nudSaltMax.Value)
                .SetIterations((int)nudIterations.Value)
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