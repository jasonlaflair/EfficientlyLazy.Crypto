namespace EfficientlyLazy.Crypto.Demo.UserControls
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxAlgorithm
            // 
            this.cbxAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlgorithm.FormattingEnabled = true;
            this.cbxAlgorithm.Location = new System.Drawing.Point(103, 19);
            this.cbxAlgorithm.Name = "cbxAlgorithm";
            this.cbxAlgorithm.Size = new System.Drawing.Size(114, 21);
            this.cbxAlgorithm.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 22);
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
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 262);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hashing Parameters";
            // 
            // cbxUseHMAC
            // 
            this.cbxUseHMAC.AutoSize = true;
            this.cbxUseHMAC.Location = new System.Drawing.Point(103, 50);
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
            this.txtEntropy.Location = new System.Drawing.Point(103, 73);
            this.txtEntropy.Multiline = true;
            this.txtEntropy.Name = "txtEntropy";
            this.txtEntropy.Size = new System.Drawing.Size(313, 49);
            this.txtEntropy.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Encoding:";
            // 
            // cbxEncoding
            // 
            this.cbxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEncoding.FormattingEnabled = true;
            this.cbxEncoding.Location = new System.Drawing.Point(103, 128);
            this.cbxEncoding.Name = "cbxEncoding";
            this.cbxEncoding.Size = new System.Drawing.Size(221, 21);
            this.cbxEncoding.TabIndex = 1;
            // 
            // lblEntropy
            // 
            this.lblEntropy.AutoSize = true;
            this.lblEntropy.Enabled = false;
            this.lblEntropy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntropy.Location = new System.Drawing.Point(43, 76);
            this.lblEntropy.Name = "lblEntropy";
            this.lblEntropy.Size = new System.Drawing.Size(54, 13);
            this.lblEntropy.TabIndex = 16;
            this.lblEntropy.Text = "Entropy:";
            // 
            // HashingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "HashingControl";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.Size = new System.Drawing.Size(554, 282);
            this.Load += new System.EventHandler(this.HashingControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxAlgorithm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxEncoding;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbxUseHMAC;
        private System.Windows.Forms.TextBox txtEntropy;
        private System.Windows.Forms.Label lblEntropy;
    }
}
