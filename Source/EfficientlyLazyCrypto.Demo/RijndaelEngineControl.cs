// // Copyright 2008-2009 LaFlair.NET
// // 
// // Licensed under the Apache License, Version 2.0 (the "License");
// // you may not use this file except in compliance with the License.
// // You may obtain a copy of the License at
// // 
// //     http://www.apache.org/licenses/LICENSE-2.0
// // 
// // Unless required by applicable law or agreed to in writing, software
// // distributed under the License is distributed on an "AS IS" BASIS,
// // WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// // See the License for the specific language governing permissions and
// // limitations under the License.
// 
namespace EfficientlyLazyCrypto.Demo
{
    using System;
    using System.Text;
    using System.Windows.Forms;

    public partial class RijndaelEngineControl : UserControl
    {
        public RijndaelEngineControl()
        {
            InitializeComponent();

            cbxKeySize.DataSource = EnumerationConversions.GetEnumDescriptions(typeof (KeySize));
            cbxKeySize.SelectedItem = EnumerationConversions.GetEnumDescription(KeySize.Key256Bit);

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
            KeySize keySize = EnumerationConversions.GetEnumName<KeySize>(cbxKeySize.SelectedItem.ToString());

            return new RijndaelEngine(txtKey.Text)
                .SetKeySize(keySize)
                .SetInitVector(txtInitVector.Text)
                .SetSalt(txtSalt.Text)
                .SetRandomSaltLength((int)nudSaltMin.Value, (int)nudSaltMax.Value)
                .SetIterations((int)nudIterations.Value)
                .SetEncoding(cbxEncoding.SelectedItem as Encoding);
        }
    }
}