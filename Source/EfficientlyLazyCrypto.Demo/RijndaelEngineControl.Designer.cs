namespace EfficientlyLazyCrypto.Demo
{
    partial class RijndaelEngineControl
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
            this.cbxKeySize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudIterations = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudSaltMin = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudSaltMax = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaltMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaltMax)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(105, 46);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(313, 20);
            this.txtKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Key:";
            // 
            // txtInitVector
            // 
            this.txtInitVector.Location = new System.Drawing.Point(105, 72);
            this.txtInitVector.Name = "txtInitVector";
            this.txtInitVector.Size = new System.Drawing.Size(313, 20);
            this.txtInitVector.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Init Vector:";
            // 
            // txtSalt
            // 
            this.txtSalt.Location = new System.Drawing.Point(105, 98);
            this.txtSalt.Name = "txtSalt";
            this.txtSalt.Size = new System.Drawing.Size(313, 20);
            this.txtSalt.TabIndex = 3;
            // 
            // cbxKeySize
            // 
            this.cbxKeySize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKeySize.FormattingEnabled = true;
            this.cbxKeySize.Location = new System.Drawing.Point(105, 19);
            this.cbxKeySize.Name = "cbxKeySize";
            this.cbxKeySize.Size = new System.Drawing.Size(114, 21);
            this.cbxKeySize.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Key Salt:";
            // 
            // nudIterations
            // 
            this.nudIterations.Location = new System.Drawing.Point(337, 126);
            this.nudIterations.Name = "nudIterations";
            this.nudIterations.Size = new System.Drawing.Size(81, 20);
            this.nudIterations.TabIndex = 6;
            this.nudIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Salt Minimum:";
            // 
            // nudSaltMin
            // 
            this.nudSaltMin.Location = new System.Drawing.Point(106, 124);
            this.nudSaltMin.Name = "nudSaltMin";
            this.nudSaltMin.Size = new System.Drawing.Size(81, 20);
            this.nudSaltMin.TabIndex = 4;
            this.nudSaltMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Salt Maximum:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(39, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Key Size:";
            // 
            // nudSaltMax
            // 
            this.nudSaltMax.Location = new System.Drawing.Point(106, 150);
            this.nudSaltMax.Name = "nudSaltMax";
            this.nudSaltMax.Size = new System.Drawing.Size(81, 20);
            this.nudSaltMax.TabIndex = 5;
            this.nudSaltMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(209, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Password Iterations:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbxEncoding);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtKey);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nudSaltMax);
            this.groupBox1.Controls.Add(this.txtInitVector);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSalt);
            this.groupBox1.Controls.Add(this.nudSaltMin);
            this.groupBox1.Controls.Add(this.cbxKeySize);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudIterations);
            this.groupBox1.Location = new System.Drawing.Point(13, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 212);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rijndael Parameters";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(35, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Encoding:";
            // 
            // cbxEncoding
            // 
            this.cbxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEncoding.FormattingEnabled = true;
            this.cbxEncoding.Location = new System.Drawing.Point(106, 176);
            this.cbxEncoding.Name = "cbxEncoding";
            this.cbxEncoding.Size = new System.Drawing.Size(113, 21);
            this.cbxEncoding.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtxtEncrypted);
            this.groupBox2.Controls.Add(this.rtxtClear);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmdDecrypt);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmdEncrypt);
            this.groupBox2.Location = new System.Drawing.Point(13, 227);
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
            // RijndaelEngineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RijndaelEngineControl";
            this.Size = new System.Drawing.Size(462, 449);
            this.Load += new System.EventHandler(this.RijndaelEngineControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaltMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaltMax)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInitVector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSalt;
        private System.Windows.Forms.ComboBox cbxKeySize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudIterations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudSaltMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudSaltMax;
        private System.Windows.Forms.Label label6;
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
