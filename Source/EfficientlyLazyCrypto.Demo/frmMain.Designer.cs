namespace EfficientlyLazyCrypto.Demo
{
    partial class frmMain
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
            this.txtRijndaelKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRijndaelInitVector = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRijndaelKeySalt = new System.Windows.Forms.TextBox();
            this.nudRijndaelSaltMin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudRijndaelSaltMax = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudRijndaelPassIterations = new System.Windows.Forms.NumericUpDown();
            this.cbxRijndaelKeySize = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdRijndaelEncrypt = new System.Windows.Forms.Button();
            this.cmdRijndaelDecrypt = new System.Windows.Forms.Button();
            this.txtRijndaelClearText = new System.Windows.Forms.TextBox();
            this.txtRijndaelEncrypted = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpRijndael = new System.Windows.Forms.TabPage();
            this.tpDPAPI = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDPAPIEntropy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDPAPIKeyType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDPAPIClearText = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmdDPAPIDecrypt = new System.Windows.Forms.Button();
            this.txtDPAPIEncrypted = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cmdDPAPIEncrypt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudRijndaelSaltMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRijndaelSaltMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRijndaelPassIterations)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpRijndael.SuspendLayout();
            this.tpDPAPI.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRijndaelKey
            // 
            this.txtRijndaelKey.Location = new System.Drawing.Point(158, 23);
            this.txtRijndaelKey.Name = "txtRijndaelKey";
            this.txtRijndaelKey.Size = new System.Drawing.Size(370, 20);
            this.txtRijndaelKey.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Init Vector:";
            // 
            // txtRijndaelInitVector
            // 
            this.txtRijndaelInitVector.Location = new System.Drawing.Point(158, 49);
            this.txtRijndaelInitVector.Name = "txtRijndaelInitVector";
            this.txtRijndaelInitVector.Size = new System.Drawing.Size(370, 20);
            this.txtRijndaelInitVector.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(94, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Key Salt:";
            // 
            // txtRijndaelKeySalt
            // 
            this.txtRijndaelKeySalt.Location = new System.Drawing.Point(158, 75);
            this.txtRijndaelKeySalt.Name = "txtRijndaelKeySalt";
            this.txtRijndaelKeySalt.Size = new System.Drawing.Size(370, 20);
            this.txtRijndaelKeySalt.TabIndex = 2;
            // 
            // nudRijndaelSaltMin
            // 
            this.nudRijndaelSaltMin.Location = new System.Drawing.Point(159, 101);
            this.nudRijndaelSaltMin.Name = "nudRijndaelSaltMin";
            this.nudRijndaelSaltMin.Size = new System.Drawing.Size(97, 20);
            this.nudRijndaelSaltMin.TabIndex = 3;
            this.nudRijndaelSaltMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Random Salt Minimum:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(290, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Random Salt Maximum:";
            // 
            // nudRijndaelSaltMax
            // 
            this.nudRijndaelSaltMax.Location = new System.Drawing.Point(431, 101);
            this.nudRijndaelSaltMax.Name = "nudRijndaelSaltMax";
            this.nudRijndaelSaltMax.Size = new System.Drawing.Size(97, 20);
            this.nudRijndaelSaltMax.TabIndex = 4;
            this.nudRijndaelSaltMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(303, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Password Iterations:";
            // 
            // nudRijndaelPassIterations
            // 
            this.nudRijndaelPassIterations.Location = new System.Drawing.Point(431, 127);
            this.nudRijndaelPassIterations.Name = "nudRijndaelPassIterations";
            this.nudRijndaelPassIterations.Size = new System.Drawing.Size(97, 20);
            this.nudRijndaelPassIterations.TabIndex = 6;
            this.nudRijndaelPassIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxRijndaelKeySize
            // 
            this.cbxRijndaelKeySize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRijndaelKeySize.FormattingEnabled = true;
            this.cbxRijndaelKeySize.Location = new System.Drawing.Point(158, 126);
            this.cbxRijndaelKeySize.Name = "cbxRijndaelKeySize";
            this.cbxRijndaelKeySize.Size = new System.Drawing.Size(98, 21);
            this.cbxRijndaelKeySize.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(92, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Key Size:";
            // 
            // cmdRijndaelEncrypt
            // 
            this.cmdRijndaelEncrypt.Image = global::EfficientlyLazyCrypto.Demo.Properties.Resources.encrypted_16x16;
            this.cmdRijndaelEncrypt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRijndaelEncrypt.Location = new System.Drawing.Point(158, 94);
            this.cmdRijndaelEncrypt.Name = "cmdRijndaelEncrypt";
            this.cmdRijndaelEncrypt.Size = new System.Drawing.Size(154, 27);
            this.cmdRijndaelEncrypt.TabIndex = 1;
            this.cmdRijndaelEncrypt.Text = "Encrypt";
            this.cmdRijndaelEncrypt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdRijndaelEncrypt.UseVisualStyleBackColor = true;
            this.cmdRijndaelEncrypt.Click += new System.EventHandler(this.cmdRijndaelEncrypt_Click);
            // 
            // cmdRijndaelDecrypt
            // 
            this.cmdRijndaelDecrypt.Image = global::EfficientlyLazyCrypto.Demo.Properties.Resources.decrypted_16x16;
            this.cmdRijndaelDecrypt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRijndaelDecrypt.Location = new System.Drawing.Point(374, 94);
            this.cmdRijndaelDecrypt.Name = "cmdRijndaelDecrypt";
            this.cmdRijndaelDecrypt.Size = new System.Drawing.Size(154, 27);
            this.cmdRijndaelDecrypt.TabIndex = 2;
            this.cmdRijndaelDecrypt.Text = "Decrypt";
            this.cmdRijndaelDecrypt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdRijndaelDecrypt.UseVisualStyleBackColor = false;
            this.cmdRijndaelDecrypt.Click += new System.EventHandler(this.cmdRijndaelDecrypt_Click);
            // 
            // txtRijndaelClearText
            // 
            this.txtRijndaelClearText.Location = new System.Drawing.Point(158, 22);
            this.txtRijndaelClearText.Multiline = true;
            this.txtRijndaelClearText.Name = "txtRijndaelClearText";
            this.txtRijndaelClearText.Size = new System.Drawing.Size(370, 68);
            this.txtRijndaelClearText.TabIndex = 0;
            // 
            // txtRijndaelEncrypted
            // 
            this.txtRijndaelEncrypted.Location = new System.Drawing.Point(158, 125);
            this.txtRijndaelEncrypted.Multiline = true;
            this.txtRijndaelEncrypted.Name = "txtRijndaelEncrypted";
            this.txtRijndaelEncrypted.Size = new System.Drawing.Size(370, 68);
            this.txtRijndaelEncrypted.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(83, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Clear Text:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(55, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Encrypted Text:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRijndaelKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRijndaelInitVector);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRijndaelKeySalt);
            this.groupBox1.Controls.Add(this.cbxRijndaelKeySize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudRijndaelPassIterations);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudRijndaelSaltMin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nudRijndaelSaltMax);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encryption Parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRijndaelClearText);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmdRijndaelDecrypt);
            this.groupBox2.Controls.Add(this.txtRijndaelEncrypted);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmdRijndaelEncrypt);
            this.groupBox2.Location = new System.Drawing.Point(6, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 208);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpRijndael);
            this.tabControl1.Controls.Add(this.tpDPAPI);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(564, 416);
            this.tabControl1.TabIndex = 0;
            // 
            // tpRijndael
            // 
            this.tpRijndael.Controls.Add(this.groupBox1);
            this.tpRijndael.Controls.Add(this.groupBox2);
            this.tpRijndael.Location = new System.Drawing.Point(4, 22);
            this.tpRijndael.Name = "tpRijndael";
            this.tpRijndael.Padding = new System.Windows.Forms.Padding(3);
            this.tpRijndael.Size = new System.Drawing.Size(556, 390);
            this.tpRijndael.TabIndex = 0;
            this.tpRijndael.Text = "Rijndael Engine";
            this.tpRijndael.UseVisualStyleBackColor = true;
            // 
            // tpDPAPI
            // 
            this.tpDPAPI.Controls.Add(this.groupBox3);
            this.tpDPAPI.Controls.Add(this.groupBox4);
            this.tpDPAPI.Location = new System.Drawing.Point(4, 22);
            this.tpDPAPI.Name = "tpDPAPI";
            this.tpDPAPI.Padding = new System.Windows.Forms.Padding(3);
            this.tpDPAPI.Size = new System.Drawing.Size(556, 390);
            this.tpDPAPI.TabIndex = 1;
            this.tpDPAPI.Text = "DPAPI Engine";
            this.tpDPAPI.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDPAPIEntropy);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cmbDPAPIKeyType);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(544, 87);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encryption Parameters";
            // 
            // txtDPAPIEntropy
            // 
            this.txtDPAPIEntropy.Location = new System.Drawing.Point(159, 50);
            this.txtDPAPIEntropy.Name = "txtDPAPIEntropy";
            this.txtDPAPIEntropy.Size = new System.Drawing.Size(370, 20);
            this.txtDPAPIEntropy.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(88, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Key Type:";
            // 
            // cmbDPAPIKeyType
            // 
            this.cmbDPAPIKeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDPAPIKeyType.FormattingEnabled = true;
            this.cmbDPAPIKeyType.Location = new System.Drawing.Point(159, 23);
            this.cmbDPAPIKeyType.Name = "cmbDPAPIKeyType";
            this.cmbDPAPIKeyType.Size = new System.Drawing.Size(140, 21);
            this.cmbDPAPIKeyType.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(98, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Entropy:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDPAPIClearText);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.cmdDPAPIEncrypt);
            this.groupBox4.Controls.Add(this.cmdDPAPIDecrypt);
            this.groupBox4.Controls.Add(this.txtDPAPIEncrypted);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Location = new System.Drawing.Point(6, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(544, 208);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // txtDPAPIClearText
            // 
            this.txtDPAPIClearText.Location = new System.Drawing.Point(158, 22);
            this.txtDPAPIClearText.Multiline = true;
            this.txtDPAPIClearText.Name = "txtDPAPIClearText";
            this.txtDPAPIClearText.Size = new System.Drawing.Size(370, 68);
            this.txtDPAPIClearText.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(83, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Clear Text:";
            // 
            // cmdDPAPIDecrypt
            // 
            this.cmdDPAPIDecrypt.Image = global::EfficientlyLazyCrypto.Demo.Properties.Resources.decrypted_16x16;
            this.cmdDPAPIDecrypt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDPAPIDecrypt.Location = new System.Drawing.Point(374, 94);
            this.cmdDPAPIDecrypt.Name = "cmdDPAPIDecrypt";
            this.cmdDPAPIDecrypt.Size = new System.Drawing.Size(154, 27);
            this.cmdDPAPIDecrypt.TabIndex = 2;
            this.cmdDPAPIDecrypt.Text = "Decrypt";
            this.cmdDPAPIDecrypt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDPAPIDecrypt.UseVisualStyleBackColor = true;
            this.cmdDPAPIDecrypt.Click += new System.EventHandler(this.cmdDPAPIDecrypt_Click);
            // 
            // txtDPAPIEncrypted
            // 
            this.txtDPAPIEncrypted.Location = new System.Drawing.Point(158, 125);
            this.txtDPAPIEncrypted.Multiline = true;
            this.txtDPAPIEncrypted.Name = "txtDPAPIEncrypted";
            this.txtDPAPIEncrypted.Size = new System.Drawing.Size(370, 68);
            this.txtDPAPIEncrypted.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(55, 128);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Encrypted Text:";
            // 
            // cmdDPAPIEncrypt
            // 
            this.cmdDPAPIEncrypt.Image = global::EfficientlyLazyCrypto.Demo.Properties.Resources.encrypted_16x16;
            this.cmdDPAPIEncrypt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDPAPIEncrypt.Location = new System.Drawing.Point(158, 94);
            this.cmdDPAPIEncrypt.Name = "cmdDPAPIEncrypt";
            this.cmdDPAPIEncrypt.Size = new System.Drawing.Size(154, 27);
            this.cmdDPAPIEncrypt.TabIndex = 1;
            this.cmdDPAPIEncrypt.Text = "Encrypt";
            this.cmdDPAPIEncrypt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDPAPIEncrypt.UseVisualStyleBackColor = true;
            this.cmdDPAPIEncrypt.Click += new System.EventHandler(this.cmdDPAPIEncrypt_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 440);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EfficientlyLazyCrypto.Demo";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudRijndaelSaltMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRijndaelSaltMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRijndaelPassIterations)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpRijndael.ResumeLayout(false);
            this.tpDPAPI.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRijndaelKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRijndaelInitVector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRijndaelKeySalt;
        private System.Windows.Forms.NumericUpDown nudRijndaelSaltMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudRijndaelSaltMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudRijndaelPassIterations;
        private System.Windows.Forms.ComboBox cbxRijndaelKeySize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdRijndaelEncrypt;
        private System.Windows.Forms.Button cmdRijndaelDecrypt;
        private System.Windows.Forms.TextBox txtRijndaelClearText;
        private System.Windows.Forms.TextBox txtRijndaelEncrypted;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpRijndael;
        private System.Windows.Forms.TabPage tpDPAPI;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDPAPIEntropy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbDPAPIKeyType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtDPAPIClearText;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button cmdDPAPIDecrypt;
        private System.Windows.Forms.TextBox txtDPAPIEncrypted;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button cmdDPAPIEncrypt;
    }
}