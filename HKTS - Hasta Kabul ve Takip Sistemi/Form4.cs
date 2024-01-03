using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKTS___Hasta_Kabul_ve_Takip_Sistemi
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public string baslik = string.Empty;


        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public string user, tc, ad, soyad;

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.No;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if((dk_doktor.SelectedIndex > -1) && (saat.Text.Length == 2) && (dakika.Text.Length == 2))
            {
                DateTime dt = DateTime.Parse(dk_tarih.Text).Date;
                TimeSpan ts = new TimeSpan(int.Parse(saat.Text), int.Parse(dakika.Text), 59);
                dt = dt + ts;
                if (dt >= DateTime.Now)
                {
                    if(baslik == "RANDEVU")
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT INTO Randevular(Adult,TC_NO,AD,SOYAD,DOKTOR,TARIH,TUR) VALUES(@Adult,@TC_NO,@AD,@SOYAD,@DOKTOR,@TARIH,@TUR)";
                        cmd.Parameters.AddWithValue("@Adult", user);
                        cmd.Parameters.AddWithValue("@TC_NO", tc);
                        cmd.Parameters.AddWithValue("@AD", ad);
                        cmd.Parameters.AddWithValue("@SOYAD", soyad);
                        cmd.Parameters.AddWithValue("@DOKTOR", dk_doktor.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@TARIH", dt);
                        cmd.Parameters.AddWithValue("@TUR", baslik);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        this.DialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        if(ameliyat.Text != "")
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "INSERT INTO Ameliyatlar(Adult,TC_NO,AD,SOYAD,DOKTOR,TARIH,TUR,AMELIYAT) VALUES(@Adult,@TC_NO,@AD,@SOYAD,@DOKTOR,@TARIH,@TUR,@AMELIYAT)";
                            cmd.Parameters.AddWithValue("@Adult", user);
                            cmd.Parameters.AddWithValue("@TC_NO", tc);
                            cmd.Parameters.AddWithValue("@AD", ad);
                            cmd.Parameters.AddWithValue("@SOYAD", soyad);
                            cmd.Parameters.AddWithValue("@DOKTOR", dk_doktor.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@TARIH", dt);
                            cmd.Parameters.AddWithValue("@TUR", baslik);
                            cmd.Parameters.AddWithValue("@AMELIYAT", ameliyat.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            this.DialogResult = DialogResult.Yes;
                        }
                        else
                        {
                            Form2 fr = new Form2();
                            fr.baslik = "HATA!";
                            fr.str = "Bir ameliyat açıklaması girin!";
                            fr.formmod = 1;
                            fr.ShowDialog();
                        }
                    }
                }
                else
                {
                    Form2 fr = new Form2();
                    fr.baslik = "HATA!";
                    fr.str = "Geçerli bir tarih girin!";
                    fr.formmod = 1;
                    fr.ShowDialog();
                }
            }
            else
            {
                Form2 fr = new Form2();
                fr.baslik = "HATA!";
                fr.str = "Lütfen bütün boşlukları doldurun!";
                fr.formmod = 1;
                fr.ShowDialog();
            }
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {
            dk_tarih.Value = DateTime.Now;
            Form1 fr = new Form1();
            con = new MySqlConnection("server=" + fr.host + ";user=" + fr.user + ";password=" + fr.pwd + ";database=hkts");
            dk_doktor.Items.Clear();
            con.Open();
            string komut = "select * from doktorlar where Adult='" + user + "'";
            cmd = new MySqlCommand(komut, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (!dk_doktor.Items.Contains(dr["ad"].ToString() + " " + dr["soyad"].ToString()))
                {
                    dk_doktor.Items.Add(dr["ad"].ToString() + " " + dr["soyad"].ToString() + (" (") + dr["alan"].ToString() + ")");
                }
            }
            con.Close();
            label1.Text = baslik + " OLUŞTUR";
            if(baslik == "RANDEVU")
            {
                this.Size = new Size(420,230);
                guna2Button2.Location = new Point(16, 188);
                guna2Button3.Location = new Point(221, 188);
                ameliyat.Visible= false;
            }
        }

        private void dakika_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
