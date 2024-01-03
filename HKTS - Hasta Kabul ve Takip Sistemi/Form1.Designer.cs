namespace HKTS___Hasta_Kabul_ve_Takip_Sistemi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.kucult = new System.Windows.Forms.PictureBox();
            this.kapat = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sifregoster = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.sifre = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kullanici = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.kapat1 = new System.Windows.Forms.Timer(this.components);
            this.kapat2 = new System.Windows.Forms.Timer(this.components);
            this.kucult1 = new System.Windows.Forms.Timer(this.components);
            this.kucult2 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kucult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kapat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.AnimationInterval = 300;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.DragForm = false;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.kucult);
            this.panel1.Controls.Add(this.kapat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 30);
            this.panel1.TabIndex = 0;
            // 
            // kucult
            // 
            this.kucult.Dock = System.Windows.Forms.DockStyle.Right;
            this.kucult.Image = ((System.Drawing.Image)(resources.GetObject("kucult.Image")));
            this.kucult.Location = new System.Drawing.Point(1140, 0);
            this.kucult.Name = "kucult";
            this.kucult.Size = new System.Drawing.Size(30, 30);
            this.kucult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kucult.TabIndex = 3;
            this.kucult.TabStop = false;
            this.kucult.Click += new System.EventHandler(this.kucult_Click);
            this.kucult.MouseLeave += new System.EventHandler(this.kucult_MouseLeave);
            this.kucult.MouseHover += new System.EventHandler(this.kucult_MouseHover);
            // 
            // kapat
            // 
            this.kapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.kapat.Dock = System.Windows.Forms.DockStyle.Right;
            this.kapat.Image = ((System.Drawing.Image)(resources.GetObject("kapat.Image")));
            this.kapat.Location = new System.Drawing.Point(1170, 0);
            this.kapat.Margin = new System.Windows.Forms.Padding(10);
            this.kapat.Name = "kapat";
            this.kapat.Size = new System.Drawing.Size(30, 30);
            this.kapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kapat.TabIndex = 2;
            this.kapat.TabStop = false;
            this.kapat.Click += new System.EventHandler(this.kapat_Click);
            this.kapat.MouseLeave += new System.EventHandler(this.kapat_MouseLeave);
            this.kapat.MouseHover += new System.EventHandler(this.kapat_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "HASTA KABUL VE TAKİP SİSTEMİ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.sifregoster);
            this.panel2.Controls.Add(this.guna2Button1);
            this.panel2.Controls.Add(this.sifre);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.kullanici);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 620);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 7.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label5.Location = new System.Drawing.Point(61, 596);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "HKTS v1.0 © Coded by HarunBulbull";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(101, 503);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hesabın yok mu?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(170, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Yardım mı lazım?";
            // 
            // sifregoster
            // 
            this.sifregoster.AutoSize = true;
            this.sifregoster.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sifregoster.CheckedState.BorderRadius = 5;
            this.sifregoster.CheckedState.BorderThickness = 0;
            this.sifregoster.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.sifregoster.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifregoster.ForeColor = System.Drawing.Color.White;
            this.sifregoster.Location = new System.Drawing.Point(39, 401);
            this.sifregoster.Name = "sifregoster";
            this.sifregoster.Size = new System.Drawing.Size(94, 19);
            this.sifregoster.TabIndex = 5;
            this.sifregoster.Text = "Şifreyi göster";
            this.sifregoster.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.sifregoster.UncheckedState.BorderRadius = 5;
            this.sifregoster.UncheckedState.BorderThickness = 0;
            this.sifregoster.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.sifregoster.CheckedChanged += new System.EventHandler(this.sifregoster_CheckedChanged);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.guna2Button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(60, 443);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 45);
            this.guna2Button1.TabIndex = 4;
            this.guna2Button1.Text = "GİRİŞ YAP";
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // sifre
            // 
            this.sifre.Animated = true;
            this.sifre.BorderRadius = 10;
            this.sifre.BorderThickness = 0;
            this.sifre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.sifre.DefaultText = "";
            this.sifre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sifre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.sifre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.sifre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.sifre.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.sifre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sifre.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.sifre.ForeColor = System.Drawing.Color.White;
            this.sifre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sifre.IconLeft = ((System.Drawing.Image)(resources.GetObject("sifre.IconLeft")));
            this.sifre.Location = new System.Drawing.Point(35, 358);
            this.sifre.Name = "sifre";
            this.sifre.PasswordChar = '\0';
            this.sifre.PlaceholderText = "ŞİFRE";
            this.sifre.SelectedText = "";
            this.sifre.Size = new System.Drawing.Size(230, 36);
            this.sifre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(94, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "GİRİŞ YAP";
            // 
            // kullanici
            // 
            this.kullanici.Animated = true;
            this.kullanici.BorderRadius = 10;
            this.kullanici.BorderThickness = 0;
            this.kullanici.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kullanici.DefaultText = "";
            this.kullanici.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kullanici.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kullanici.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kullanici.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kullanici.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.kullanici.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kullanici.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.kullanici.ForeColor = System.Drawing.Color.White;
            this.kullanici.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kullanici.IconLeft = ((System.Drawing.Image)(resources.GetObject("kullanici.IconLeft")));
            this.kullanici.Location = new System.Drawing.Point(35, 316);
            this.kullanici.Name = "kullanici";
            this.kullanici.PasswordChar = '\0';
            this.kullanici.PlaceholderText = "KULLANICI ADI";
            this.kullanici.SelectedText = "";
            this.kullanici.Size = new System.Drawing.Size(230, 36);
            this.kullanici.TabIndex = 1;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(50, 39);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(200, 200);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // kapat1
            // 
            this.kapat1.Interval = 10;
            this.kapat1.Tick += new System.EventHandler(this.kapat1_Tick);
            // 
            // kapat2
            // 
            this.kapat2.Interval = 10;
            this.kapat2.Tick += new System.EventHandler(this.kapat2_Tick);
            // 
            // kucult1
            // 
            this.kucult1.Interval = 10;
            this.kucult1.Tick += new System.EventHandler(this.kucult1_Tick);
            // 
            // kucult2
            // 
            this.kucult2.Interval = 10;
            this.kucult2.Tick += new System.EventHandler(this.kucult2_Tick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(300, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(900, 620);
            this.panel3.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(416, 74);
            this.label7.MaximumSize = new System.Drawing.Size(850, 570);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 19);
            this.label7.TabIndex = 1;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(415, 13);
            this.label6.MaximumSize = new System.Drawing.Size(850, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 28);
            this.label6.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kucult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kapat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox kapat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox kucult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2CheckBox sifregoster;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox sifre;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox kullanici;
        private System.Windows.Forms.Timer kapat1;
        private System.Windows.Forms.Timer kapat2;
        private System.Windows.Forms.Timer kucult1;
        private System.Windows.Forms.Timer kucult2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

