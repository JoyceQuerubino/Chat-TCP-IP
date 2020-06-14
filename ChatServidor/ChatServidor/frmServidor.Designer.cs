namespace ChatServidor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnAtender = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtporta = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Location = new System.Drawing.Point(21, 118);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(310, 229);
            this.txtLog.TabIndex = 0;
            // 
            // txtIP
            // 
            this.txtIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(184)))), ((int)(((byte)(144)))));
            this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtIP.ForeColor = System.Drawing.Color.White;
            this.txtIP.Location = new System.Drawing.Point(86, 44);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(110, 14);
            this.txtIP.TabIndex = 24;
            this.txtIP.Text = "IP";
            this.txtIP.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            // 
            // btnAtender
            // 
            this.btnAtender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(95)))), ((int)(((byte)(61)))));
            this.btnAtender.FlatAppearance.BorderSize = 0;
            this.btnAtender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtender.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnAtender.ForeColor = System.Drawing.Color.White;
            this.btnAtender.Location = new System.Drawing.Point(247, 51);
            this.btnAtender.Margin = new System.Windows.Forms.Padding(0);
            this.btnAtender.Name = "btnAtender";
            this.btnAtender.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAtender.Size = new System.Drawing.Size(83, 31);
            this.btnAtender.TabIndex = 20;
            this.btnAtender.TabStop = false;
            this.btnAtender.Text = "Visualizar";
            this.btnAtender.UseVisualStyleBackColor = false;
            this.btnAtender.Click += new System.EventHandler(this.btnAtender_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(26, 33);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(46, 31);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 24;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(76, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(79, -47);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(607, 473);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // txtporta
            // 
            this.txtporta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(184)))), ((int)(((byte)(144)))));
            this.txtporta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtporta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtporta.ForeColor = System.Drawing.Color.White;
            this.txtporta.Location = new System.Drawing.Point(85, 80);
            this.txtporta.Name = "txtporta";
            this.txtporta.Size = new System.Drawing.Size(110, 14);
            this.txtporta.TabIndex = 28;
            this.txtporta.Text = "Porta";
            this.txtporta.TextChanged += new System.EventHandler(this.txtporta_TextChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(76, 73);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(133, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(27, 73);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(46, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 30;
            this.pictureBox4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(184)))), ((int)(((byte)(144)))));
            this.ClientSize = new System.Drawing.Size(683, 379);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txtporta);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.btnAtender);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Servidor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnAtender;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtporta;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}

