﻿using System;
using System.Windows.Forms;

namespace EfficientlyLazy.Crypto.Demo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            RijndaelEngineControl rijndaelEngineControl = new RijndaelEngineControl();
            ToolStripMenuItem rijndaelEngineControlMenu = new ToolStripMenuItem(rijndaelEngineControl.DisplayName)
                                                          {
                                                              Tag = rijndaelEngineControl
                                                          };
            rijndaelEngineControlMenu.Click += MenuClick;
            configurationToolStripMenuItem.DropDownItems.Add(rijndaelEngineControlMenu);

            DPAPIEngineControl dpapiEngineControl = new DPAPIEngineControl();
            ToolStripMenuItem dpapiEngineControlMenu = new ToolStripMenuItem(dpapiEngineControl.DisplayName)
                                                       {
                                                           Tag = dpapiEngineControl
                                                       };
            dpapiEngineControlMenu.Click += MenuClick;
            configurationToolStripMenuItem.DropDownItems.Add(dpapiEngineControlMenu);

            HashingControl hashingControl = new HashingControl();
            ToolStripMenuItem hashingControlMenu = new ToolStripMenuItem(hashingControl.DisplayName)
                                                   {
                                                       Tag = hashingControl
                                                   };
            hashingControlMenu.Click += MenuClick;
            configurationToolStripMenuItem.DropDownItems.Add(hashingControlMenu);

            rijndaelEngineControlMenu.PerformClick();
        }

        void MenuClick(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            foreach (ToolStripMenuItem dropDownItem in configurationToolStripMenuItem.DropDownItems)
            {
                dropDownItem.Checked = false;
            }

            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item == null)
            {
                lblConfiguration.Text = string.Empty;
                cmdEncrypt.Enabled = false;
                cmdDecrypt.Enabled = false;
                return;
            }

            item.Checked = true;

            CryptoUserControl cryptoUserControl =  item.Tag as CryptoUserControl;

            if (cryptoUserControl == null)
            {
                lblConfiguration.Text = string.Empty;
                cmdEncrypt.Enabled = false;
                cmdDecrypt.Enabled = false;
                return;
            }

            lblConfiguration.Text = cryptoUserControl.DisplayName;

            cryptoUserControl.Dock = DockStyle.Fill;
            panel1.BorderStyle = BorderStyle.None;
            panel1.Controls.Add(cryptoUserControl);

            cmdEncrypt.Enabled = true;
            cmdDecrypt.Enabled = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void cmdEncrypt_Click(object sender, EventArgs e)
        {
            CryptoUserControl cryptoUserControl = panel1.Controls[0] as CryptoUserControl;

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
            CryptoUserControl cryptoUserControl = panel1.Controls[0] as CryptoUserControl;

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
            using (frmSQLConnectionStringBuilder builder = new frmSQLConnectionStringBuilder())
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