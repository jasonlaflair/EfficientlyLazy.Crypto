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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpRijndael = new System.Windows.Forms.TabPage();
            this.rijndaelEngineControl1 = new EfficientlyLazyCrypto.Demo.RijndaelEngineControl();
            this.tpDPAPI = new System.Windows.Forms.TabPage();
            this.dpapiEngineControl1 = new EfficientlyLazyCrypto.Demo.DPAPIEngineControl();
            this.tpHashing = new System.Windows.Forms.TabPage();
            this.hashingControl1 = new EfficientlyLazyCrypto.Demo.HashingControl();
            this.tabControl1.SuspendLayout();
            this.tpRijndael.SuspendLayout();
            this.tpDPAPI.SuspendLayout();
            this.tpHashing.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpRijndael);
            this.tabControl1.Controls.Add(this.tpDPAPI);
            this.tabControl1.Controls.Add(this.tpHashing);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(482, 487);
            this.tabControl1.TabIndex = 0;
            // 
            // tpRijndael
            // 
            this.tpRijndael.Controls.Add(this.rijndaelEngineControl1);
            this.tpRijndael.Location = new System.Drawing.Point(4, 22);
            this.tpRijndael.Name = "tpRijndael";
            this.tpRijndael.Padding = new System.Windows.Forms.Padding(3);
            this.tpRijndael.Size = new System.Drawing.Size(474, 461);
            this.tpRijndael.TabIndex = 0;
            this.tpRijndael.Text = "Rijndael Engine";
            this.tpRijndael.UseVisualStyleBackColor = true;
            // 
            // rijndaelEngineControl1
            // 
            this.rijndaelEngineControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rijndaelEngineControl1.Location = new System.Drawing.Point(6, 6);
            this.rijndaelEngineControl1.Name = "rijndaelEngineControl1";
            this.rijndaelEngineControl1.Size = new System.Drawing.Size(462, 449);
            this.rijndaelEngineControl1.TabIndex = 0;
            // 
            // tpDPAPI
            // 
            this.tpDPAPI.Controls.Add(this.dpapiEngineControl1);
            this.tpDPAPI.Location = new System.Drawing.Point(4, 22);
            this.tpDPAPI.Name = "tpDPAPI";
            this.tpDPAPI.Padding = new System.Windows.Forms.Padding(3);
            this.tpDPAPI.Size = new System.Drawing.Size(474, 461);
            this.tpDPAPI.TabIndex = 1;
            this.tpDPAPI.Text = "DPAPI Engine";
            this.tpDPAPI.UseVisualStyleBackColor = true;
            // 
            // dpapiEngineControl1
            // 
            this.dpapiEngineControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dpapiEngineControl1.Location = new System.Drawing.Point(6, 6);
            this.dpapiEngineControl1.Name = "dpapiEngineControl1";
            this.dpapiEngineControl1.Size = new System.Drawing.Size(462, 342);
            this.dpapiEngineControl1.TabIndex = 0;
            // 
            // tpHashing
            // 
            this.tpHashing.Controls.Add(this.hashingControl1);
            this.tpHashing.Location = new System.Drawing.Point(4, 22);
            this.tpHashing.Name = "tpHashing";
            this.tpHashing.Padding = new System.Windows.Forms.Padding(3);
            this.tpHashing.Size = new System.Drawing.Size(474, 461);
            this.tpHashing.TabIndex = 2;
            this.tpHashing.Text = "Hashing";
            this.tpHashing.UseVisualStyleBackColor = true;
            // 
            // hashingControl1
            // 
            this.hashingControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hashingControl1.Location = new System.Drawing.Point(6, 6);
            this.hashingControl1.Name = "hashingControl1";
            this.hashingControl1.Size = new System.Drawing.Size(462, 342);
            this.hashingControl1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 509);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EfficientlyLazyCrypto.Demo";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpRijndael.ResumeLayout(false);
            this.tpDPAPI.ResumeLayout(false);
            this.tpHashing.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpRijndael;
        private System.Windows.Forms.TabPage tpDPAPI;
        private RijndaelEngineControl rijndaelEngineControl1;
        private DPAPIEngineControl dpapiEngineControl1;
        private System.Windows.Forms.TabPage tpHashing;
        private HashingControl hashingControl1;
    }
}