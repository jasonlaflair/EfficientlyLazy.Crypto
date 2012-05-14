using System;
using System.Collections.Generic;
using System.Text;

namespace EfficientlyLazy.Crypto.Demo.UserControls
{
    public partial class HashingControl : CryptoUserControl
    {
        public HashingControl()
        {
            InitializeComponent();

            var algorithms = new List<string>
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

        protected override bool ValidateParameters()
        {
            return true;
        }

        public override bool CanEncrypt { get { return true; } }

        protected override string EngineEncrypt(string clearText)
        {
            var algorithm = (Algorithm)Enum.Parse(typeof (Algorithm), cbxAlgorithm.SelectedItem.ToString());
            var encoding = (Encoding)cbxEncoding.SelectedItem;

            return cbxUseHMAC.Checked
                       ? DataHashing.ComputeHMAC(algorithm, clearText, txtEntropy.Text, encoding)
                       : DataHashing.Compute(algorithm, clearText, encoding);
        }

        public override bool CanDecrypt { get { return false; } }

        protected override string EngineDecrypt(string encryptedText)
        {
            throw new NotSupportedException("Hashing cannot be reversed");
        }
    }
}