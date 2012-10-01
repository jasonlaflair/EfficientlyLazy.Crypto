using System;
using System.Windows.Forms;
using EfficientlyLazy.Crypto.Demo.UserControls;

namespace EfficientlyLazy.Crypto.Demo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            var rijndaelEngineControl = new RijndaelEngineControl();
            var rijndaelEngineControlMenu = new ToolStripMenuItem(rijndaelEngineControl.DisplayName)
                                                {
                                                    Tag = rijndaelEngineControl
                                                };
            rijndaelEngineControlMenu.Click += MenuClick;
            configurationToolStripMenuItem.DropDownItems.Add(rijndaelEngineControlMenu);

#if !NET20
            var aesEngineControl = new AESEngineControl();
            var aesEngineControlMenu = new ToolStripMenuItem(aesEngineControl.DisplayName)
                {
                    Tag = aesEngineControl
                };
            aesEngineControlMenu.Click += MenuClick;
            configurationToolStripMenuItem.DropDownItems.Add(aesEngineControlMenu);
#endif
            var tripleDESEngineControl = new TripleDESEngineControl();
            var tripleDESEngineControlMenu = new ToolStripMenuItem(tripleDESEngineControl.DisplayName)
                                                 {
                                                     Tag = tripleDESEngineControl
                                                 };
            tripleDESEngineControlMenu.Click += MenuClick;
            configurationToolStripMenuItem.DropDownItems.Add(tripleDESEngineControlMenu);

            var desEngineControl = new DESEngineControl();
            var desEngineControlMenu = new ToolStripMenuItem(desEngineControl.DisplayName)
                                           {
                                               Tag = desEngineControl
                                           };
            desEngineControlMenu.Click += MenuClick;
            configurationToolStripMenuItem.DropDownItems.Add(desEngineControlMenu);

            var rc2EngineControl = new RC2EngineControl();
            var rc2EngineControlMenu = new ToolStripMenuItem(rc2EngineControl.DisplayName)
                                           {
                                               Tag = rc2EngineControl
                                           };
            rc2EngineControlMenu.Click += MenuClick;
            configurationToolStripMenuItem.DropDownItems.Add(rc2EngineControlMenu);


            var dpapiEngineControl = new DPAPIEngineControl();
            var dpapiEngineControlMenu = new ToolStripMenuItem(dpapiEngineControl.DisplayName)
                                                       {
                                                           Tag = dpapiEngineControl
                                                       };
            dpapiEngineControlMenu.Click += MenuClick;
            configurationToolStripMenuItem.DropDownItems.Add(dpapiEngineControlMenu);

            var hashingControl = new HashingControl();
            var hashingControlMenu = new ToolStripMenuItem(hashingControl.DisplayName)
                                                   {
                                                       Tag = hashingControl
                                                   };
            hashingControlMenu.Click += MenuClick;
            configurationToolStripMenuItem.DropDownItems.Add(hashingControlMenu);

            rijndaelEngineControlMenu.PerformClick();
        }

        private void MenuClick(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            foreach (ToolStripMenuItem dropDownItem in configurationToolStripMenuItem.DropDownItems)
            {
                dropDownItem.Checked = false;
            }

            var item = sender as ToolStripMenuItem;

            if (item == null)
            {
                lblConfiguration.Text = string.Empty;
                cmdEncrypt.Enabled = false;
                cmdDecrypt.Enabled = false;
                return;
            }

            item.Checked = true;

            var cryptoUserControl =  item.Tag as CryptoUserControl;

            if (cryptoUserControl == null)
            {
                lblConfiguration.Text = string.Empty;
                cmdEncrypt.Enabled = false;
                cmdDecrypt.Enabled = false;
                return;
            }

            lblConfiguration.Text = cryptoUserControl.DisplayName;
            cmdEncrypt.Enabled = cryptoUserControl.CanEncrypt;
            cmdDecrypt.Enabled = cryptoUserControl.CanDecrypt;

            cryptoUserControl.Dock = DockStyle.Fill;
            panel1.BorderStyle = BorderStyle.None;
            panel1.Controls.Add(cryptoUserControl);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void cmdEncrypt_Click(object sender, EventArgs e)
        {
            var cryptoUserControl = panel1.Controls[0] as CryptoUserControl;

            try
            {
                if (cryptoUserControl == null)
                {
                    throw new NullReferenceException("CryptoUserControl is null");
                }

                txtEncrypted.Text = cryptoUserControl.Encrypt(txtClearText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdDecrypt_Click(object sender, EventArgs e)
        {
            var cryptoUserControl = panel1.Controls[0] as CryptoUserControl;

            try
            {
                if (cryptoUserControl == null)
                {
                    throw new NullReferenceException("CryptoUserControl is null");
                }

                txtClearText.Text = cryptoUserControl.Decrypt(txtEncrypted.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generateConnectionStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var builder = new frmSQLConnectionStringBuilder())
            {
                if (builder.ShowDialog() == DialogResult.OK)
                {
                    txtClearText.Text = builder.SQLConnectionString;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}