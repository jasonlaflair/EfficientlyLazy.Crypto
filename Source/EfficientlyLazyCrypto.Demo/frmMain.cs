using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace EfficientlyLazyCrypto.Demo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            cbxKeySize.DataSource = Conv.GetEnumDescriptions(typeof(RijndaelKeySize));

            nudSaltMin.Minimum = 0;
            nudSaltMin.Maximum = RijndaelParameters.MINIMUM_SET_SALT_LENGTH;
            nudSaltMin.Value = 0;

            nudSaltMax.Minimum = 0;
            nudSaltMax.Maximum = RijndaelParameters.MAXIMUM_SET_SALT_LENGTH;
            nudSaltMax.Value = 0;

            nudPassIterations.Minimum = 1;
            nudPassIterations.Maximum = 10000;
            nudPassIterations.Value = 1;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void cmdEncrypt_Click(object sender, EventArgs e)
        {
            RijndaelKeySize keySize = Conv.GetEnumName<RijndaelKeySize>(cbxKeySize.SelectedItem.ToString());

            IRijndaelParameters parameters = new RijndaelParameters(txtKey.Text, txtInitVector.Text, (byte)nudSaltMin.Value, (byte)nudSaltMax.Value, txtKeySalt.Text, keySize, (byte)nudPassIterations.Value);

            ICryptoEngine engine = null;

            try
            {
                engine = new RijndaelEngine(parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n\r\n{1}", ex.Message, ex), "Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                engine = null;
            }

            if (engine != null)
            {
                try
                {
                    txtEncrypted.Text = engine.Encrypt(txtClearText.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("{0}\r\n\r\n{1}", ex.Message, ex), "Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEncrypted.Text = string.Empty;
                }
            }
        }

        private void cmdDecrypt_Click(object sender, EventArgs e)
        {
            RijndaelKeySize keySize = Conv.GetEnumName<RijndaelKeySize>(cbxKeySize.SelectedItem.ToString());

            IRijndaelParameters parameters = new RijndaelParameters(txtKey.Text, txtInitVector.Text, (byte)nudSaltMin.Value, (byte)nudSaltMax.Value, txtKeySalt.Text, keySize, (byte)nudPassIterations.Value);

            ICryptoEngine engine = null;

            try
            {
                engine = new RijndaelEngine(parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n\r\n{1}", ex.Message, ex), "Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                engine = null;
            }

            if (engine != null)
            {
                try
                {
                    txtClearText.Text = engine.Decrypt(txtEncrypted.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("{0}\r\n\r\n{1}", ex.Message, ex), "Decryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClearText.Text = string.Empty;
                }
            }
        }
    }

    public static class Conv
    {
        public static List<string> GetEnumDescriptions(Type value)
        {
            List<string> descriptions = new List<string>();

            FieldInfo[] fis = value.GetFields();
            foreach (FieldInfo fi in fis)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    descriptions.Add(attributes[0].Description);
                }
            }

            return descriptions;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static T GetEnumName<T>(string description)
        {
            FieldInfo[] fis = typeof(T).GetFields();
            foreach (FieldInfo fi in fis)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0 && attributes[0].Description == description)
                {
                    return
                   (T)fi.GetValue(typeof(T));

                    // return fi.Name;
                }
            }

            return default(T); // description;
        }
    }
}
