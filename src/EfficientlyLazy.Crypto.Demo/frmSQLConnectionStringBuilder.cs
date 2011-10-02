using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EfficientlyLazy.Crypto.Demo
{
    public partial class frmSQLConnectionStringBuilder : Form
    {
        public string SQLConnectionString { get; private set; }

        public frmSQLConnectionStringBuilder()
        {
            InitializeComponent();

            SQLConnectionString = string.Empty;
        }

        private void frmSQLConnectionStringBuilder_Load(object sender, EventArgs e)
        {
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                if (!string.IsNullOrEmpty(txtApplicationName.Text))
                {
                    builder.ApplicationName = txtApplicationName.Text;
                }

                builder.DataSource = txtDataSource.Text;
                builder.InitialCatalog = txtInitialCatalog.Text;

                if (cbxUseIntegratedSecurity.Checked)
                {
                    builder.IntegratedSecurity = true;
                }
                else
                {
                    builder.IntegratedSecurity = false;
                    builder.Password = txtPassword.Text;
                    builder.UserID = txtUserID.Text;
                }

                if (cbxEncrypt.CheckState != CheckState.Indeterminate)
                {
                    builder.Encrypt = cbxEncrypt.Checked;
                }

                if (cbxTrustServerCertificate.CheckState != CheckState.Indeterminate)
                {
                    builder.TrustServerCertificate = cbxTrustServerCertificate.Checked;
                }

                if (!string.IsNullOrEmpty(txtWorkstation.Text))
                {
                    builder.WorkstationID = txtWorkstation.Text;
                }

                if (cbxEnableConnectionTimeout.Checked)
                {
                    builder.ConnectTimeout = (int)nudConnectionTimeout.Value;
                }

                SQLConnectionString = builder.ToString();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbxUseIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            lblUserID.Enabled = !cbxUseIntegratedSecurity.Checked;
            txtUserID.Enabled = !cbxUseIntegratedSecurity.Checked;
            lblPassword.Enabled = !cbxUseIntegratedSecurity.Checked;
            txtPassword.Enabled = !cbxUseIntegratedSecurity.Checked;

            if (txtUserID.Enabled)
            {
                return;
            }

            txtUserID.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void cbxEnableConnectionTimeout_CheckedChanged(object sender, EventArgs e)
        {
            nudConnectionTimeout.Enabled = cbxEnableConnectionTimeout.Checked;

            if (nudConnectionTimeout.Enabled)
            {
                return;
            }

            nudConnectionTimeout.Value = 15;
        }
    }
}
