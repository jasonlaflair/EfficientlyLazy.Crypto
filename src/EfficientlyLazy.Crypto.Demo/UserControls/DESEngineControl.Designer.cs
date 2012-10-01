namespace EfficientlyLazy.Crypto.Demo.UserControls
{
    partial class DESEngineControl
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
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInitVector = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSalt = new System.Windows.Forms.TextBox();
            this.cmbKeySize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudIterations = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudSaltMin = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudSaltMax = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxUseEncoding = new System.Windows.Forms.CheckBox();
            this.cbxUsePasswordIterations = new System.Windows.Forms.CheckBox();
            this.cbxUseRandomSalt = new System.Windows.Forms.CheckBox();
            this.cbxUseKeySalt = new System.Windows.Forms.CheckBox();
            this.cbxUseInitVector = new System.Windows.Forms.CheckBox();
            this.cbxUseKeySize = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHashAlgorithm = new System.Windows.Forms.TextBox();
            this.cbxUseHashAlgorithm = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaltMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaltMax)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(206, 19);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(313, 20);
            this.txtKey.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Key:";
            // 
            // txtInitVector
            // 
            this.txtInitVector.Enabled = false;
            this.txtInitVector.Location = new System.Drawing.Point(205, 72);
            this.txtInitVector.Name = "txtInitVector";
            this.txtInitVector.Size = new System.Drawing.Size(313, 20);
            this.txtInitVector.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Init Vector:";
            // 
            // txtSalt
            // 
            this.txtSalt.Enabled = false;
            this.txtSalt.Location = new System.Drawing.Point(205, 98);
            this.txtSalt.Name = "txtSalt";
            this.txtSalt.Size = new System.Drawing.Size(313, 20);
            this.txtSalt.TabIndex = 6;
            // 
            // cmbKeySize
            // 
            this.cmbKeySize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeySize.Enabled = false;
            this.cmbKeySize.FormattingEnabled = true;
            this.cmbKeySize.Location = new System.Drawing.Point(206, 45);
            this.cmbKeySize.Name = "cmbKeySize";
            this.cmbKeySize.Size = new System.Drawing.Size(114, 21);
            this.cmbKeySize.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Key Salt:";
            // 
            // nudIterations
            // 
            this.nudIterations.Enabled = false;
            this.nudIterations.Location = new System.Drawing.Point(206, 176);
            this.nudIterations.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIterations.Name = "nudIterations";
            this.nudIterations.Size = new System.Drawing.Size(82, 20);
            this.nudIterations.TabIndex = 11;
            this.nudIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudIterations.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Salt Minimum:";
            // 
            // nudSaltMin
            // 
            this.nudSaltMin.Enabled = false;
            this.nudSaltMin.Location = new System.Drawing.Point(206, 124);
            this.nudSaltMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSaltMin.Name = "nudSaltMin";
            this.nudSaltMin.Size = new System.Drawing.Size(82, 20);
            this.nudSaltMin.TabIndex = 8;
            this.nudSaltMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Salt Maximum:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(72, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Key Size:";
            // 
            // nudSaltMax
            // 
            this.nudSaltMax.Enabled = false;
            this.nudSaltMax.Location = new System.Drawing.Point(206, 150);
            this.nudSaltMax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSaltMax.Name = "nudSaltMax";
            this.nudSaltMax.Size = new System.Drawing.Size(82, 20);
            this.nudSaltMax.TabIndex = 9;
            this.nudSaltMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Password Iterations:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxUseEncoding);
            this.groupBox1.Controls.Add(this.cbxUsePasswordIterations);
            this.groupBox1.Controls.Add(this.cbxUseRandomSalt);
            this.groupBox1.Controls.Add(this.cbxUseHashAlgorithm);
            this.groupBox1.Controls.Add(this.cbxUseKeySalt);
            this.groupBox1.Controls.Add(this.cbxUseInitVector);
            this.groupBox1.Controls.Add(this.cbxUseKeySize);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbEncoding);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtKey);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nudSaltMax);
            this.groupBox1.Controls.Add(this.txtInitVector);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtHashAlgorithm);
            this.groupBox1.Controls.Add(this.txtSalt);
            this.groupBox1.Controls.Add(this.nudSaltMin);
            this.groupBox1.Controls.Add(this.cmbKeySize);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudIterations);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 262);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DES Parameters";
            // 
            // cbxUseEncoding
            // 
            this.cbxUseEncoding.AutoSize = true;
            this.cbxUseEncoding.Location = new System.Drawing.Point(184, 205);
            this.cbxUseEncoding.Name = "cbxUseEncoding";
            this.cbxUseEncoding.Size = new System.Drawing.Size(15, 14);
            this.cbxUseEncoding.TabIndex = 12;
            this.cbxUseEncoding.UseVisualStyleBackColor = true;
            this.cbxUseEncoding.CheckedChanged += new System.EventHandler(this.cbxUseEncoding_CheckedChanged);
            // 
            // cbxUsePasswordIterations
            // 
            this.cbxUsePasswordIterations.AutoSize = true;
            this.cbxUsePasswordIterations.Location = new System.Drawing.Point(184, 178);
            this.cbxUsePasswordIterations.Name = "cbxUsePasswordIterations";
            this.cbxUsePasswordIterations.Size = new System.Drawing.Size(15, 14);
            this.cbxUsePasswordIterations.TabIndex = 10;
            this.cbxUsePasswordIterations.UseVisualStyleBackColor = true;
            this.cbxUsePasswordIterations.CheckedChanged += new System.EventHandler(this.cbxUsePasswordIterations_CheckedChanged);
            // 
            // cbxUseRandomSalt
            // 
            this.cbxUseRandomSalt.AutoSize = true;
            this.cbxUseRandomSalt.Location = new System.Drawing.Point(184, 126);
            this.cbxUseRandomSalt.Name = "cbxUseRandomSalt";
            this.cbxUseRandomSalt.Size = new System.Drawing.Size(15, 14);
            this.cbxUseRandomSalt.TabIndex = 7;
            this.cbxUseRandomSalt.UseVisualStyleBackColor = true;
            this.cbxUseRandomSalt.CheckedChanged += new System.EventHandler(this.cbxUseRandomSalt_CheckedChanged);
            // 
            // cbxUseKeySalt
            // 
            this.cbxUseKeySalt.AutoSize = true;
            this.cbxUseKeySalt.Location = new System.Drawing.Point(184, 101);
            this.cbxUseKeySalt.Name = "cbxUseKeySalt";
            this.cbxUseKeySalt.Size = new System.Drawing.Size(15, 14);
            this.cbxUseKeySalt.TabIndex = 5;
            this.cbxUseKeySalt.UseVisualStyleBackColor = true;
            this.cbxUseKeySalt.CheckedChanged += new System.EventHandler(this.cbxUseKeySalt_CheckedChanged);
            // 
            // cbxUseInitVector
            // 
            this.cbxUseInitVector.AutoSize = true;
            this.cbxUseInitVector.Location = new System.Drawing.Point(184, 75);
            this.cbxUseInitVector.Name = "cbxUseInitVector";
            this.cbxUseInitVector.Size = new System.Drawing.Size(15, 14);
            this.cbxUseInitVector.TabIndex = 3;
            this.cbxUseInitVector.UseVisualStyleBackColor = true;
            this.cbxUseInitVector.CheckedChanged += new System.EventHandler(this.cbxUseInitVector_CheckedChanged);
            // 
            // cbxUseKeySize
            // 
            this.cbxUseKeySize.AutoSize = true;
            this.cbxUseKeySize.Location = new System.Drawing.Point(184, 48);
            this.cbxUseKeySize.Name = "cbxUseKeySize";
            this.cbxUseKeySize.Size = new System.Drawing.Size(15, 14);
            this.cbxUseKeySize.TabIndex = 1;
            this.cbxUseKeySize.UseVisualStyleBackColor = true;
            this.cbxUseKeySize.CheckedChanged += new System.EventHandler(this.cbxUseKeySize_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(67, 205);
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
            this.cmbEncoding.Location = new System.Drawing.Point(206, 202);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(221, 21);
            this.cmbEncoding.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(35, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Hash Algorithm:";
            // 
            // txtHashAlgorithm
            // 
            this.txtHashAlgorithm.Enabled = false;
            this.txtHashAlgorithm.Location = new System.Drawing.Point(205, 229);
            this.txtHashAlgorithm.Name = "txtHashAlgorithm";
            this.txtHashAlgorithm.Size = new System.Drawing.Size(313, 20);
            this.txtHashAlgorithm.TabIndex = 15;
            // 
            // cbxUseHashAlgorithm
            // 
            this.cbxUseHashAlgorithm.AutoSize = true;
            this.cbxUseHashAlgorithm.Location = new System.Drawing.Point(184, 232);
            this.cbxUseHashAlgorithm.Name = "cbxUseHashAlgorithm";
            this.cbxUseHashAlgorithm.Size = new System.Drawing.Size(15, 14);
            this.cbxUseHashAlgorithm.TabIndex = 14;
            this.cbxUseHashAlgorithm.UseVisualStyleBackColor = true;
            this.cbxUseHashAlgorithm.CheckedChanged += new System.EventHandler(this.cbxUseHashAlgorithm_CheckedChanged);
            // 
            // DESEngineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DESEngineControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(554, 282);
            this.Load += new System.EventHandler(this.DESEngineControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaltMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaltMax)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInitVector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSalt;
        private System.Windows.Forms.ComboBox cmbKeySize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudIterations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudSaltMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudSaltMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbEncoding;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbxUseEncoding;
        private System.Windows.Forms.CheckBox cbxUsePasswordIterations;
        private System.Windows.Forms.CheckBox cbxUseRandomSalt;
        private System.Windows.Forms.CheckBox cbxUseKeySalt;
        private System.Windows.Forms.CheckBox cbxUseInitVector;
        private System.Windows.Forms.CheckBox cbxUseKeySize;
        private System.Windows.Forms.CheckBox cbxUseHashAlgorithm;
        private System.Windows.Forms.TextBox txtHashAlgorithm;
        private System.Windows.Forms.Label label9;
    }
}
