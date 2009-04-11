namespace EfficientlyLazyCrypto.Demo
{
    partial class HashingControl
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
            this.cbxAlgorithm = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxUseHMAC = new System.Windows.Forms.CheckBox();
            this.txtEntropy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxEncoding = new System.Windows.Forms.ComboBox();
            this.lblEntropy = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtxtEncrypted = new System.Windows.Forms.RichTextBox();
            this.rtxtClear = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdHash = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxAlgorithm
            // 
            this.cbxAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlgorithm.FormattingEnabled = true;
            this.cbxAlgorithm.Location = new System.Drawing.Point(105, 19);
            this.cbxAlgorithm.Name = "cbxAlgorithm";
            this.cbxAlgorithm.Size = new System.Drawing.Size(114, 21);
            this.cbxAlgorithm.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Algorithm:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxUseHMAC);
            this.groupBox1.Controls.Add(this.txtEntropy);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbxEncoding);
            this.groupBox1.Controls.Add(this.lblEntropy);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbxAlgorithm);
            this.groupBox1.Location = new System.Drawing.Point(13, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hashing Parameters";
            // 
            // cbxUseHMAC
            // 
            this.cbxUseHMAC.AutoSize = true;
            this.cbxUseHMAC.Location = new System.Drawing.Point(105, 46);
            this.cbxUseHMAC.Name = "cbxUseHMAC";
            this.cbxUseHMAC.Size = new System.Drawing.Size(79, 17);
            this.cbxUseHMAC.TabIndex = 2;
            this.cbxUseHMAC.Text = "Use HMAC";
            this.cbxUseHMAC.UseVisualStyleBackColor = true;
            this.cbxUseHMAC.CheckedChanged += new System.EventHandler(this.cbxUseHMAC_CheckedChanged);
            // 
            // txtEntropy
            // 
            this.txtEntropy.Enabled = false;
            this.txtEntropy.Location = new System.Drawing.Point(105, 69);
            this.txtEntropy.Name = "txtEntropy";
            this.txtEntropy.Size = new System.Drawing.Size(313, 20);
            this.txtEntropy.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(234, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Encoding:";
            // 
            // cbxEncoding
            // 
            this.cbxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEncoding.FormattingEnabled = true;
            this.cbxEncoding.Location = new System.Drawing.Point(305, 19);
            this.cbxEncoding.Name = "cbxEncoding";
            this.cbxEncoding.Size = new System.Drawing.Size(113, 21);
            this.cbxEncoding.TabIndex = 1;
            // 
            // lblEntropy
            // 
            this.lblEntropy.AutoSize = true;
            this.lblEntropy.Enabled = false;
            this.lblEntropy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntropy.Location = new System.Drawing.Point(45, 72);
            this.lblEntropy.Name = "lblEntropy";
            this.lblEntropy.Size = new System.Drawing.Size(54, 13);
            this.lblEntropy.TabIndex = 16;
            this.lblEntropy.Text = "Entropy:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtxtEncrypted);
            this.groupBox2.Controls.Add(this.rtxtClear);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmdHash);
            this.groupBox2.Controls.Add(this.label10);
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
            this.rtxtEncrypted.TabIndex = 2;
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
            // cmdHash
            // 
            this.cmdHash.Image = global::EfficientlyLazyCrypto.Demo.Properties.Resources.encrypted_16x16;
            this.cmdHash.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdHash.Location = new System.Drawing.Point(105, 94);
            this.cmdHash.Name = "cmdHash";
            this.cmdHash.Size = new System.Drawing.Size(313, 27);
            this.cmdHash.TabIndex = 1;
            this.cmdHash.Text = "Hash";
            this.cmdHash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdHash.UseVisualStyleBackColor = true;
            this.cmdHash.Click += new System.EventHandler(this.cmdHash_Click);
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
            // HashingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "HashingControl";
            this.Size = new System.Drawing.Size(462, 342);
            this.Load += new System.EventHandler(this.HashingControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxAlgorithm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxEncoding;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdHash;
        private System.Windows.Forms.RichTextBox rtxtEncrypted;
        private System.Windows.Forms.RichTextBox rtxtClear;
        private System.Windows.Forms.CheckBox cbxUseHMAC;
        private System.Windows.Forms.TextBox txtEntropy;
        private System.Windows.Forms.Label lblEntropy;
    }
}
