namespace EfficientlyLazy.Crypto.Demo
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
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 210);
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
            // DPAPIEngineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DPAPIEngineControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(455, 230);
            this.Load += new System.EventHandler(this.DPAPIEngineControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}
