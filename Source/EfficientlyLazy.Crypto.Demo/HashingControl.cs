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
namespace EfficientlyLazy.Crypto.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class HashingControl : CryptoUserControl
    {
        public HashingControl()
        {
            InitializeComponent();

            List<string> algorithms = new List<string>
                                      {
                                          Algorithm.SHA1.ToString(),
                                          Algorithm.SHA256.ToString(),
                                          Algorithm.SHA384.ToString(),
                                          Algorithm.SHA512.ToString()
                                      };

            cbxAlgorithm.DataSource = algorithms;
            cbxAlgorithm.SelectedItem = Algorithm.SHA512.ToString();

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
                return "Data Hashing";
            }
        }

        private void HashingControl_Load(object sender, EventArgs e)
        {
        }

        private void cbxUseHMAC_CheckedChanged(object sender, EventArgs e)
        {
            lblEntropy.Enabled = cbxUseHMAC.Checked;
            txtEntropy.Enabled = cbxUseHMAC.Checked;
        }

        public override string Encrypt(string clearText)
        {
            Algorithm algorithm = (Algorithm)Enum.Parse(typeof (Algorithm), cbxAlgorithm.SelectedItem.ToString());
            Encoding encoding = (Encoding)cbxEncoding.SelectedItem;

            return cbxUseHMAC.Checked
                       ? DataHashing.ComputeHMAC(algorithm, clearText, txtEntropy.Text, encoding)
                       : DataHashing.Compute(algorithm, clearText, encoding);
        }

        public override string Decrypt(string encryptedText)
        {
            throw new NotSupportedException("Hashing cannot be reversed");
        }
    }
}