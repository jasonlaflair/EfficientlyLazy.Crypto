namespace EfficientlyLazy.Crypto.Demo
{
    partial class frmSQLConnectionStringBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtApplicationName = new System.Windows.Forms.TextBox();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cbxUseIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.cbxEncrypt = new System.Windows.Forms.CheckBox();
            this.cbxTrustServerCertificate = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInitialCatalog = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtWorkstation = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.nudConnectionTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblConnectionTimeout = new System.Windows.Forms.Label();
            this.cbxEnableConnectionTimeout = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudConnectionTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // txtApplicationName
            // 
            this.txtApplicationName.Location = new System.Drawing.Point(138, 12);
            this.txtApplicationName.Name = "txtApplicationName";
            this.txtApplicationName.Size = new System.Drawing.Size(172, 20);
            this.txtApplicationName.TabIndex = 0;
            // 
            // txtDataSource
            // 
            this.txtDataSource.Location = new System.Drawing.Point(138, 38);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(172, 20);
            this.txtDataSource.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Initial Catalog:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Application Name:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Enabled = false;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(78, 116);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(54, 13);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "User ID:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Enabled = false;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(67, 142);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // cbxUseIntegratedSecurity
            // 
            this.cbxUseIntegratedSecurity.AutoSize = true;
            this.cbxUseIntegratedSecurity.Checked = true;
            this.cbxUseIntegratedSecurity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxUseIntegratedSecurity.Location = new System.Drawing.Point(138, 90);
            this.cbxUseIntegratedSecurity.Name = "cbxUseIntegratedSecurity";
            this.cbxUseIntegratedSecurity.Size = new System.Drawing.Size(137, 17);
            this.cbxUseIntegratedSecurity.TabIndex = 3;
            this.cbxUseIntegratedSecurity.Text = "Use Integrated Security";
            this.cbxUseIntegratedSecurity.UseVisualStyleBackColor = true;
            this.cbxUseIntegratedSecurity.CheckedChanged += new System.EventHandler(this.cbxUseIntegratedSecurity_CheckedChanged);
            // 
            // cbxEncrypt
            // 
            this.cbxEncrypt.AutoSize = true;
            this.cbxEncrypt.Checked = true;
            this.cbxEncrypt.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbxEncrypt.Location = new System.Drawing.Point(138, 165);
            this.cbxEncrypt.Name = "cbxEncrypt";
            this.cbxEncrypt.Size = new System.Drawing.Size(62, 17);
            this.cbxEncrypt.TabIndex = 6;
            this.cbxEncrypt.Text = "Encrypt";
            this.cbxEncrypt.ThreeState = true;
            this.cbxEncrypt.UseVisualStyleBackColor = true;
            // 
            // cbxTrustServerCertificate
            // 
            this.cbxTrustServerCertificate.AutoSize = true;
            this.cbxTrustServerCertificate.Checked = true;
            this.cbxTrustServerCertificate.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbxTrustServerCertificate.Location = new System.Drawing.Point(138, 188);
            this.cbxTrustServerCertificate.Name = "cbxTrustServerCertificate";
            this.cbxTrustServerCertificate.Size = new System.Drawing.Size(134, 17);
            this.cbxTrustServerCertificate.TabIndex = 7;
            this.cbxTrustServerCertificate.Text = "Trust Server Certificate";
            this.cbxTrustServerCertificate.ThreeState = true;
            this.cbxTrustServerCertificate.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Workstation ID:";
            // 
            // txtInitialCatalog
            // 
            this.txtInitialCatalog.Location = new System.Drawing.Point(138, 64);
            this.txtInitialCatalog.Name = "txtInitialCatalog";
            this.txtInitialCatalog.Size = new System.Drawing.Size(172, 20);
            this.txtInitialCatalog.TabIndex = 2;
            // 
            // txtUserID
            // 
            this.txtUserID.Enabled = false;
            this.txtUserID.Location = new System.Drawing.Point(138, 113);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(172, 20);
            this.txtUserID.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(138, 139);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(172, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtWorkstation
            // 
            this.txtWorkstation.Location = new System.Drawing.Point(138, 237);
            this.txtWorkstation.Name = "txtWorkstation";
            this.txtWorkstation.Size = new System.Drawing.Size(172, 20);
            this.txtWorkstation.TabIndex = 10;
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(235, 270);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 12;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(138, 270);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(75, 23);
            this.cmdGenerate.TabIndex = 11;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // nudConnectionTimeout
            // 
            this.nudConnectionTimeout.Enabled = false;
            this.nudConnectionTimeout.Location = new System.Drawing.Point(159, 211);
            this.nudConnectionTimeout.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudConnectionTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudConnectionTimeout.Name = "nudConnectionTimeout";
            this.nudConnectionTimeout.Size = new System.Drawing.Size(63, 20);
            this.nudConnectionTimeout.TabIndex = 9;
            this.nudConnectionTimeout.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lblConnectionTimeout
            // 
            this.lblConnectionTimeout.AutoSize = true;
            this.lblConnectionTimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionTimeout.Location = new System.Drawing.Point(8, 213);
            this.lblConnectionTimeout.Name = "lblConnectionTimeout";
            this.lblConnectionTimeout.Size = new System.Drawing.Size(124, 13);
            this.lblConnectionTimeout.TabIndex = 1;
            this.lblConnectionTimeout.Text = "Connection Timeout:";
            // 
            // cbxEnableConnectionTimeout
            // 
            this.cbxEnableConnectionTimeout.AutoSize = true;
            this.cbxEnableConnectionTimeout.Location = new System.Drawing.Point(138, 213);
            this.cbxEnableConnectionTimeout.Name = "cbxEnableConnectionTimeout";
            this.cbxEnableConnectionTimeout.Size = new System.Drawing.Size(15, 14);
            this.cbxEnableConnectionTimeout.TabIndex = 8;
            this.cbxEnableConnectionTimeout.UseVisualStyleBackColor = true;
            this.cbxEnableConnectionTimeout.CheckedChanged += new System.EventHandler(this.cbxEnableConnectionTimeout_CheckedChanged);
            // 
            // frmSQLConnectionStringBuilder
            // 
            this.AcceptButton = this.cmdGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(323, 305);
            this.ControlBox = false;
            this.Controls.Add(this.cbxEnableConnectionTimeout);
            this.Controls.Add(this.nudConnectionTimeout);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cbxTrustServerCertificate);
            this.Controls.Add(this.cbxEncrypt);
            this.Controls.Add(this.cbxUseIntegratedSecurity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblConnectionTimeout);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInitialCatalog);
            this.Controls.Add(this.txtWorkstation);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtDataSource);
            this.Controls.Add(this.txtApplicationName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSQLConnectionStringBuilder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQL Connection String Builder";
            this.Load += new System.EventHandler(this.frmSQLConnectionStringBuilder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudConnectionTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtApplicationName;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox cbxUseIntegratedSecurity;
        private System.Windows.Forms.CheckBox cbxEncrypt;
        private System.Windows.Forms.CheckBox cbxTrustServerCertificate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInitialCatalog;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtWorkstation;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.NumericUpDown nudConnectionTimeout;
        private System.Windows.Forms.Label lblConnectionTimeout;
        private System.Windows.Forms.CheckBox cbxEnableConnectionTimeout;
    }
}