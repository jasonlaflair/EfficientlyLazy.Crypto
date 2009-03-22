namespace EfficientlyLazyCrypto.Demo
{
    partial class DPAPIEngineControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtEntropy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxKeyType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxEncoding = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtxtEncrypted = new System.Windows.Forms.RichTextBox();
            this.rtxtClear = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdDecrypt = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdEncrypt = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEntropy
            // 
            this.txtEntropy.Location = new System.Drawing.Point(105, 46);
            this.txtEntropy.Name = "txtEntropy";
            this.txtEntropy.Size = new System.Drawing.Size(313, 20);
            this.txtEntropy.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Entropy:";
            // 
            // cbxKeyType
            // 
            this.cbxKeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKeyType.FormattingEnabled = true;
            this.cbxKeyType.Location = new System.Drawing.Point(105, 19);
            this.cbxKeyType.Name = "cbxKeyType";
            this.cbxKeyType.Size = new System.Drawing.Size(114, 21);
            this.cbxKeyType.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Key Type:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbxEncoding);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEntropy);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbxKeyType);
            this.groupBox1.Location = new System.Drawing.Point(13, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DPAPI Parameters";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Encoding:";
            // 
            // cbxEncoding
            // 
            this.cbxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEncoding.FormattingEnabled = true;
            this.cbxEncoding.Location = new System.Drawing.Point(105, 72);
            this.cbxEncoding.Name = "cbxEncoding";
            this.cbxEncoding.Size = new System.Drawing.Size(113, 21);
            this.cbxEncoding.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtxtEncrypted);
            this.groupBox2.Controls.Add(this.rtxtClear);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmdDecrypt);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmdEncrypt);
            this.groupBox2.Location = new System.Drawing.Point(13, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 208);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // rtxtEncrypted
            // 
            this.rtxtEncrypted.Location = new System.Drawing.Point(105, 127);
            this.rtxtEncrypted.Name = "rtxtEncrypted";
            this.rtxtEncrypted.Size = new System.Drawing.Size(313, 69);
            this.rtxtEncrypted.TabIndex = 3;
            this.rtxtEncrypted.Text = "";
            // 
            // rtxtClear
            // 
            this.rtxtClear.Location = new System.Drawing.Point(105, 19);
            this.rtxtClear.Name = "rtxtClear";
            this.rtxtClear.Size = new System.Drawing.Size(313, 69);
            this.rtxtClear.TabIndex = 0;
            this.rtxtClear.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(59, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Clear:";
            // 
            // cmdDecrypt
            // 
            this.cmdDecrypt.Image = global::EfficientlyLazyCrypto.Demo.Properties.Resources.decrypted_16x16;
            this.cmdDecrypt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDecrypt.Location = new System.Drawing.Point(281, 94);
            this.cmdDecrypt.Name = "cmdDecrypt";
            this.cmdDecrypt.Size = new System.Drawing.Size(137, 27);
            this.cmdDecrypt.TabIndex = 2;
            this.cmdDecrypt.Text = "Decrypt";
            this.cmdDecrypt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDecrypt.UseVisualStyleBackColor = false;
            this.cmdDecrypt.Click += new System.EventHandler(this.cmdDecrypt_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Encrypted:";
            // 
            // cmdEncrypt
            // 
            this.cmdEncrypt.Image = global::EfficientlyLazyCrypto.Demo.Properties.Resources.encrypted_16x16;
            this.cmdEncrypt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEncrypt.Location = new System.Drawing.Point(106, 94);
            this.cmdEncrypt.Name = "cmdEncrypt";
            this.cmdEncrypt.Size = new System.Drawing.Size(137, 27);
            this.cmdEncrypt.TabIndex = 1;
            this.cmdEncrypt.Text = "Encrypt";
            this.cmdEncrypt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEncrypt.UseVisualStyleBackColor = true;
            this.cmdEncrypt.Click += new System.EventHandler(this.cmdEncrypt_Click);
            // 
            // DPAPIEngineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DPAPIEngineControl";
            this.Size = new System.Drawing.Size(462, 342);
            this.Load += new System.EventHandler(this.DPAPIEngineControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtEntropy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxKeyType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxEncoding;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdDecrypt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdEncrypt;
        private System.Windows.Forms.RichTextBox rtxtEncrypted;
        private System.Windows.Forms.RichTextBox rtxtClear;
    }
}
