using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKTS___Hasta_Kabul_ve_Takip_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string ver = "1.0";
        public string host = "localhost";
        public string user = "root";
        public string pwd = "root";

        MySqlConnection con;
        MySqlDataReader dr;
        MySqlCommand cmd;

        string checkver, checkbaslik, checkgovde;
        private void Form1_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=" + host + ";user=" + user + ";password=" + pwd + ";database=HKTS");
            con.Open();
            string sorgu = "SELECT * FROM Ayarlar where id='" + 1 + "'";
            cmd = new MySqlCommand(sorgu, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                checkver = dr["ver"].ToString();
                checkbaslik = dr["baslik"].ToString();
                checkgovde = dr["govde"].ToString();
            }
            con.Close();
            label6.Text = checkbaslik;
            label7.Text = checkgovde;
            sifre.UseSystemPasswordChar = true;
            int x1 = panel3.Width / 2 - label6.Width / 2;
            int x2 = panel3.Width / 2 - label7.Width / 2;
            label6.Location= new Point(x1, 13);
            label7.Location= new Point(x2, 74);
            if(ver != checkver)
            {
                Form2 fr = new Form2();
                fr.formmod = 1;
                fr.baslik = "HATA!";
                fr.str = "Geçersiz ya da eski bir sürüm kullanıyorsunuz! Lütfen programı aşağıdaki link üzerinden güncelleyerek tekrar çalıştırmayı deneyin.\n\nhttps://www.harunbulbull.com/hkts/";
                fr.ShowDialog();
                Application.Exit();
            }
        }

        private void sifregoster_CheckedChanged(object sender, EventArgs e)
        {
            if(sifregoster.Checked == true)
            {
                sifre.UseSystemPasswordChar = false;
            }
            else
            {
                sifre.UseSystemPasswordChar = true;
            }
        }

        private void kapat_MouseHover(object sender, EventArgs e)
        {
            kapat2.Stop();
            kapat1.Start();
        }

        private void kapat_MouseLeave(object sender, EventArgs e)
        {
            kapat1.Stop();
            kapat2.Start();
        }

        private void kapat1_Tick(object sender, EventArgs e)
        {
            int x = int.Parse(kapat.BackColor.ToString().Split('=')[2].Split(',')[0]);
            if (x < 255)
            {
                x += 10;
                kapat.BackColor = Color.FromArgb(x, 25, 25);
            }
            else
            {
                kapat1.Stop();
            }
        }

        private void kapat2_Tick(object sender, EventArgs e)
        {
            int x = int.Parse(kapat.BackColor.ToString().Split('=')[2].Split(',')[0]);
            if (x > 25)
            {
                x -= 10;
                kapat.BackColor = Color.FromArgb(x, 25, 25);
            }
            else
            {
                kapat2.Stop();
            }
        }

        private void kapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kucult_MouseHover(object sender, EventArgs e)
        {
            kucult2.Stop();
            kucult1.Start();
        }

        private void kucult_MouseLeave(object sender, EventArgs e)
        {
            kucult1.Stop();
            kucult2.Start();
        }

        private void kucult1_Tick(object sender, EventArgs e)
        {
            int x = int.Parse(kucult.BackColor.ToString().Split('=')[4].Split(']')[0]);
            if (x < 255)
            {
                x += 10;
                kucult.BackColor = Color.FromArgb(25, 25, x);
            }
            else
            {
                kucult1.Stop();
            }
        }

        private void kucult2_Tick(object sender, EventArgs e)
        {
            int x = int.Parse(kucult.BackColor.ToString().Split('=')[4].Split(']')[0]);
            if (x > 25)
            {
                x -= 10;
                kucult.BackColor = Color.FromArgb(25, 25, x);
            }
            else
            {
                kucult2.Stop();
            }
        }

        private void kucult_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection= con;
            cmd.CommandText = "Select * from hesaplar where username='" + kullanici.Text + "'";
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select * from hesaplar where username='" + kullanici.Text + "' and password='" + sifre.Text + "'";
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    con.Close();
                    Form3 fr = new Form3();
                    fr.user = kullanici.Text;
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    Form2 fr = new Form2();
                    fr.baslik = "HATA!";
                    fr.formmod = 1;
                    fr.str = "Yanlış bir şifre girdiniz!";
                    fr.ShowDialog();
                }
            }
            else
            {
                Form2 fr= new Form2();
                fr.baslik = "HATA!";
                fr.formmod = 1;
                fr.str = "Geçersiz bir kullanıcı adı girdiniz!";
                fr.ShowDialog();
            }
            con.Close();
        }
    }
}
