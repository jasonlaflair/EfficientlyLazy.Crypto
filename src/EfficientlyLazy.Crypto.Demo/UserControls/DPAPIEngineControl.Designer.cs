namespace EfficientlyLazy.Crypto.Demo.UserControls
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
            this.cmbKeyType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxUseEncoding = new System.Windows.Forms.CheckBox();
            this.cbxUseEntropy = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEntropy
            // 
            this.txtEntropy.Enabled = false;
            this.txtEntropy.Location = new System.Drawing.Point(127, 46);
            this.txtEntropy.Name = "txtEntropy";
            this.txtEntropy.Size = new System.Drawing.Size(391, 20);
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
            // cmbKeyType
            // 
            this.cmbKeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyType.FormattingEnabled = true;
            this.cmbKeyType.Location = new System.Drawing.Point(127, 19);
            this.cmbKeyType.Name = "cmbKeyType";
            this.cmbKeyType.Size = new System.Drawing.Size(114, 21);
            this.cmbKeyType.TabIndex = 0;
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
            this.groupBox1.Controls.Add(this.cbxUseEncoding);
            this.groupBox1.Controls.Add(this.cbxUseEntropy);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbEncoding);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEntropy);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbKeyType);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 262);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DPAPI Parameters";
            // 
            // cbxUseEncoding
            // 
            this.cbxUseEncoding.AutoSize = true;
            this.cbxUseEncoding.Location = new System.Drawing.Point(106, 75);
            this.cbxUseEncoding.Name = "cbxUseEncoding";
            this.cbxUseEncoding.Size = new System.Drawing.Size(15, 14);
            this.cbxUseEncoding.TabIndex = 23;
            this.cbxUseEncoding.UseVisualStyleBackColor = true;
            this.cbxUseEncoding.CheckedChanged += new System.EventHandler(this.cbxUseEncoding_CheckedChanged);
            // 
            // cbxUseEntropy
            // 
            this.cbxUseEntropy.AutoSize = true;
            this.cbxUseEntropy.Location = new System.Drawing.Point(106, 49);
            this.cbxUseEntropy.Name = "cbxUseEntropy";
            this.cbxUseEntropy.Size = new System.Drawing.Size(15, 14);
            this.cbxUseEntropy.TabIndex = 23;
            this.cbxUseEntropy.UseVisualStyleBackColor = true;
            this.cbxUseEntropy.CheckedChanged += new System.EventHandler(this.cbxUseEntropy_CheckedChanged);
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
            // cmbEncoding
            // 
            this.cmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoding.Enabled = false;
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Location = new System.Drawing.Point(127, 72);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(221, 21);
            this.cmbEncoding.TabIndex = 2;
            // 
            // DPAPIEngineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DPAPIEngineControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(554, 282);
            this.Load += new System.EventHandler(this.DPAPIEngineControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtEntropy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKeyType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbEncoding;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbxUseEncoding;
        private System.Windows.Forms.CheckBox cbxUseEntropy;
    }
}
