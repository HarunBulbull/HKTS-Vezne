using Google.Protobuf.WellKnownTypes;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HKTS___Hasta_Kabul_ve_Takip_Sistemi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public string user = string.Empty;

        MySqlConnection con, contest;
        MySqlCommand cmd;
        MySqlDataReader dr;

        DateTime outdate;

        private void Form3_Load(object sender, EventArgs e)
        {
            timer2.Start();
            timer1.Start();
            kadi.Text = user;
            Form1 fr = new Form1();
            con = new MySqlConnection("server=" + fr.host + ";user=" + fr.user + ";password=" + fr.pwd + ";database=hkts");
            contest = new MySqlConnection("server=" + fr.host + ";user=" + fr.user + ";password=" + fr.pwd + ";database=hkts");
            con.Open();
            cmd = new MySqlCommand("Select * from hesaplar where username='" + user + "'", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                outdate = DateTime.Parse(dr["outdate"].ToString());
            }
            con.Close();
            string a = (outdate - DateTime.Now.AddDays(-1)).ToString().Split('.')[0];
            if(a.Substring(0,1) != "-")
            {
                if(a.Length != 8)
                {
                    if (int.Parse(a) <= 7)

                    {
                        bitis.ForeColor = Color.Red;
                    }
                    bitis.Text = outdate.ToString().Split(' ')[0] + " (" + a + " gün kaldı)";
                }
                else
                {
                    bitis.ForeColor = Color.Red;
                    bitis.Text = outdate.ToString().Split(' ')[0] + " (0 gün kaldı)";
                }
            }
            else
            {
                Form2 fr1 = new Form2();
                fr1.baslik = "ÜYELİK";
                fr1.str = "Üyeliğiniz sona ermiştir. Ödeme yaptığınız zaman verilerinize tekrar erişebilirsiniz. Eğer 1 yıl içinde ödeme yapmazsanız bütün verileriniz silinecektir!";
                fr1.formmod = 1;
                fr1.ShowDialog();
                Application.Exit();
            }
        }
        string anasayfa;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            hk_1.Visible = true;
            hk_2.Visible = true;
            rnd_1.Visible = false;
            rnd_2.Visible = false;
            aml_1.Visible = false;
            aml_2.Visible = false;
            hasta();
            hk_tc.Text = "";
            hk_ad.Text = "";
            hk_soyad.Text = "";
            hk_tel.Text = "";
            hk_kadın.Checked = false;
            hk_erkek.Checked = false;
            hk_tarih.Value = DateTime.Now;
            dk_1.Visible = false;
            dk_2.Visible = false;
            anasayfa = "hasta";
        }

        int hs1, hs2;

        private void hasta()
        {
            hk_filtre.Text = "";
            hkf_ad.Checked = false;
            hkf_soyad.Checked = false;
            hkf_tc.Checked = false;
            hkf_tel.Checked = false;
            con.Open();
            string komut = "select * from hastalar where Adult='" + user + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(komut, con);
            dt1 = new DataTable();
            da.Fill(dt1);
            dt1.Columns.RemoveAt(0);
            dt1.Columns.RemoveAt(0);
            dt1.Columns.RemoveAt(6);
            guna2DataGridView1.DataSource = dt1;
            guna2DataGridView1.Columns[0].HeaderText = "TC";
            guna2DataGridView1.Columns[5].HeaderText = "DOĞUM";
            con.Close();
            hs1 = guna2DataGridView1.Rows.Count;
        }

        private void hk_kaydet_Click(object sender, EventArgs e)
        {
            if ((hk_tc.ForeColor == Color.Lime) && (hk_ad.Text != "") && (hk_tel.Text != "") && (hk_soyad.Text != "") && ((hk_kadın.Checked == true) || (hk_erkek.Checked == true)))
            {
                con.Open();
                cmd = new MySqlCommand("Select * from hastalar where TC_NO='" + hk_tc.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    con.Close();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Hastalar(Adult,TC_NO,AD,SOYAD,TELEFON,CINSIYET,DOGUM_TARIHI,KAYIT_TARIHI) VALUES(@Adult,@TC_NO,@AD,@SOYAD,@TELEFON,@CINSIYET,@DOGUM_TARIHI,@KAYIT_TARIHI)";
                    cmd.Parameters.AddWithValue("@Adult", user);
                    cmd.Parameters.AddWithValue("@TC_NO", hk_tc.Text);
                    cmd.Parameters.AddWithValue("@AD", hk_ad.Text);
                    cmd.Parameters.AddWithValue("@SOYAD", hk_soyad.Text);
                    cmd.Parameters.AddWithValue("@TELEFON", hk_tel.Text);
                    if (hk_kadın.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@CINSIYET", "Kadın");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CINSIYET", "Erkek");
                    }
                    cmd.Parameters.AddWithValue("@DOGUM_TARIHI", DateTime.Parse(hk_tarih.Text).Date);
                    cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now.Date);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    hasta();
                    hk_tc.Text = "";
                    hk_ad.Text = "";
                    hk_soyad.Text = "";
                    hk_tel.Text = "";
                    hk_kadın.Checked= false;
                    hk_erkek.Checked= false;
                    hk_tarih.Value = DateTime.Now;
                }
                else
                {
                    Form2 fr = new Form2();
                    fr.baslik = "HATA!";
                    fr.str = "Bu kimlik numarasıyla kayıtlı bir hasta zaten mevcut!";
                    fr.formmod = 1;
                    fr.ShowDialog();
                }
                con.Close();
            }
            else
            {
                Form2 fr = new Form2();
                fr.baslik = "HATA!";
                fr.str = "Lütfen bütün alanları eksiksiz olarak doldurduğunuzdan emin olun!";
                fr.formmod = 1;
                fr.ShowDialog();
            }
        }

        private void kullanici_TextChanged(object sender, EventArgs e)
        {
            if(hk_tc.TextLength == 11)
            {
                int a = 0;
                int b = 0;
                foreach (char x in hk_tc.Text)
                {
                    if (b < 10)
                    {
                        b++;
                        a = a + x;
                    }
                    else
                    {
                        string str = a.ToString();
                        char last = str[str.Length - 1];
                        if (x == last)
                        {
                            hk_tc.ForeColor = Color.Lime;
                        }
                        else
                        {
                            hk_tc.ForeColor = Color.Red;
                        }
                    }
                }
            }
            else
            {
                hk_tc.ForeColor = Color.White;
            }
        }

        string tc, ad, soyad, tel, cinsiyet, yazi, cc;
        DataTable dt1 = new DataTable();

        private void hk_tc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void hk_randevu_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
            {
                tc = row.Cells[0].Value.ToString();
                ad = row.Cells[1].Value.ToString();
                soyad = row.Cells[2].Value.ToString();
            }
            Form4 fr = new Form4();
            fr.user = user;
            fr.tc = tc;
            fr.ad = ad;
            fr.soyad = soyad;
            fr.baslik = "RANDEVU";
            if(fr.ShowDialog() == DialogResult.Yes)
            {
                Form2 fr2 = new Form2();
                fr2.formmod = 1;
                fr2.baslik = "BAŞARILI!";
                fr2.str = "Randevu başarıyla eklendi!";
                fr2.ShowDialog();
            }
        }

        private void hk_ameliyat_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
            {
                tc = row.Cells[0].Value.ToString();
                ad = row.Cells[1].Value.ToString();
                soyad = row.Cells[2].Value.ToString();
            }
            Form4 fr = new Form4();
            fr.user = user;
            fr.tc = tc;
            fr.ad = ad;
            fr.soyad = soyad;
            fr.baslik = "AMELİYAT";
            if (fr.ShowDialog() == DialogResult.Yes)
            {
                Form2 fr2 = new Form2();
                fr2.formmod = 1;
                fr2.baslik = "BAŞARILI!";
                fr2.str = "Ameliyat başarıyla eklendi!";
                fr2.ShowDialog();
            }
        }

        private void doktor_Click(object sender, EventArgs e)
        {
            hk_1.Visible = true;
            hk_2.Visible = true;
            dk_1.Visible = true;
            dk_2.Visible = true;
            rnd_1.Visible = false;
            rnd_2.Visible = false;
            aml_1.Visible = false;
            aml_2.Visible = false;
            dk_tc.Text = "";
            dk_ad.Text = "";
            dk_soyad.Text = "";
            dk_tel.Text = "";
            dk_alan.Text = "";
            dk_kadın.Checked = false;
            dk_erkek.Checked = false;
            dk_tarih.Value = DateTime.Now;
            doktorlist();
            dk_doktor.SelectedIndex = -1;
            anasayfa = "doktor";
        }

        private void doktorlist()
        {
            dk_doktor.Items.Clear();
            dk_filtre.Text = "";
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
            hs1 = dk_doktor.Items.Count;
        }

        private void dk_kaydet_Click(object sender, EventArgs e)
        {
            if ((dk_tc.ForeColor == Color.Lime) && (dk_ad.Text != "") && (dk_tel.Text != "") && (dk_soyad.Text != "") && (dk_alan.Text != "") && ((dk_kadın.Checked == true) || (dk_erkek.Checked == true)))
            {
                if(DateTime.Parse(dk_tarih.Text).Date <= DateTime.Now.Date.AddYears(-20))
                {
                    con.Open();
                    cmd = new MySqlCommand("Select * from Doktorlar where TC_NO='" + dk_tc.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (!dr.Read())
                    {
                        con.Close();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT INTO Doktorlar(Adult,TC_NO,AD,SOYAD,TELEFON,ALAN,CINSIYET,DOGUM_TARIHI,KAYIT_TARIHI) VALUES(@Adult,@TC_NO,@AD,@SOYAD,@TELEFON,@ALAN,@CINSIYET,@DOGUM_TARIHI,@KAYIT_TARIHI)";
                        cmd.Parameters.AddWithValue("@Adult", user);
                        cmd.Parameters.AddWithValue("@TC_NO", dk_tc.Text);
                        cmd.Parameters.AddWithValue("@AD", dk_ad.Text);
                        cmd.Parameters.AddWithValue("@SOYAD", dk_soyad.Text);
                        cmd.Parameters.AddWithValue("@TELEFON", dk_tel.Text);
                        cmd.Parameters.AddWithValue("@ALAN", dk_alan.Text);
                        if (dk_kadın.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@CINSIYET", "Kadın");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@CINSIYET", "Erkek");
                        }
                        cmd.Parameters.AddWithValue("@DOGUM_TARIHI", DateTime.Parse(dk_tarih.Text).Date);
                        cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now.Date);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        doktorlist();
                        dk_tc.Text = "";
                        dk_ad.Text = "";
                        dk_soyad.Text = "";
                        dk_tel.Text = "";
                        dk_alan.Text = "";
                        dk_kadın.Checked = false;
                        dk_erkek.Checked = false;
                        dk_tarih.Value = DateTime.Now;
                    }
                    else
                    {
                        Form2 fr = new Form2();
                        fr.baslik = "HATA!";
                        fr.str = "Bu kimlik numarasıyla kayıtlı bir doktor zaten mevcut!";
                        fr.formmod = 1;
                        fr.ShowDialog();
                    }
                    con.Close();
                }
                else
                {
                    Form2 fr = new Form2();
                    fr.baslik = "HATA!";
                    fr.str = "Doktor 20 yaşından küçük olamaz!";
                    fr.formmod = 1;
                    fr.ShowDialog();
                }
            }
            else
            {
                Form2 fr = new Form2();
                fr.baslik = "HATA!";
                fr.str = "Lütfen bütün alanları eksiksiz olarak doldurduğunuzdan emin olun!";
                fr.formmod = 1;
                fr.ShowDialog();
            }
        }

        private void dk_tc_TextChanged(object sender, EventArgs e)
        {
            if (dk_tc.TextLength == 11)
            {
                int a = 0;
                int b = 0;
                foreach (char x in dk_tc.Text)
                {
                    if (b < 10)
                    {
                        b++;
                        a = a + x;
                    }
                    else
                    {
                        string str = a.ToString();
                        char last = str[str.Length - 1];
                        if (x == last)
                        {
                            dk_tc.ForeColor = Color.Lime;
                        }
                        else
                        {
                            dk_tc.ForeColor = Color.Red;
                        }
                    }
                }
            }
            else
            {
                dk_tc.ForeColor = Color.White;
            }
        }

        private void dk_sil_Click(object sender, EventArgs e)
        {
            if (dk_doktor.SelectedIndex > -1)
            {
                string ad = dk_doktor.SelectedItem.ToString().Split(' ')[0];
                string soyad = dk_doktor.SelectedItem.ToString().Split(' ')[1];
                string bolum = dk_doktor.SelectedItem.ToString().Split(' ')[2].Remove(0,1).Remove(dk_doktor.SelectedItem.ToString().Split(' ')[2].Remove(0, 1).Length-1, 1);
                Form2 fr = new Form2();
                fr.baslik = "DİKKAT!";
                fr.str = "Aşağıda bilgileri verilen doktoru silmek istediğinize emin misiniz? Doktor silindikten sonra doktora ait bütün randevular ve ameliyatlar da silinecektir ve bu işlemin geri dönüşü yoktur.\n\nAd: " + ad + "\nSoyad: " + soyad + "\nAlan: " + bolum;
                fr.formmod = 2;
                if(fr.ShowDialog() == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new MySqlCommand("Delete from doktorlar where Adult='" + user + "' AND AD='" + ad + "' AND SOYAD='" + soyad + "' AND ALAN='" + bolum + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    cmd = new MySqlCommand("Delete from randevular where Adult='" + user + "' AND DOKTOR='" + dk_doktor.SelectedItem.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    cmd = new MySqlCommand("Delete from ameliyatlar where Adult='" + user + "' AND DOKTOR='" + dk_doktor.SelectedItem.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    doktorlist();
                }
            }
            else
            {
                Form2 fr = new Form2();
                fr.baslik = "HATA!";
                fr.str = "Lütfen bir doktor seçin!";
                fr.formmod = 1;
                fr.ShowDialog();
            }
        }

        private void filter1()
        {
            if(dk_doktor.SelectedIndex >-1)
            {
                if (dkf_ad.Checked == true)
                {
                    dt1.DefaultView.RowFilter = string.Format("AD like '%" + dk_filtre.Text + "%'");
                }
                if (dkf_soyad.Checked == true)
                {
                    dt1.DefaultView.RowFilter = string.Format("SOYAD like '%" + dk_filtre.Text + "%'");
                }
                if (dkf_tc.Checked == true)
                {
                    dt1.DefaultView.RowFilter = string.Format("TC_NO like '%" + dk_filtre.Text + "%'");
                }
            }
        }
        private void dosya()
        {
            guna2DataGridView2.DataSource = "";
            if(dk_doktor.SelectedIndex>-1)
            {
                con.Open();
                string komut = "select * from ameliyatlar where Adult='" + user + "' AND DOKTOR='" + dk_doktor.SelectedItem.ToString() + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(komut, con);
                dt1 = new DataTable();
                da.Fill(dt1);
                con.Close();
                con.Open();
                komut = "select * from randevular where Adult='" + user + "' AND DOKTOR='" + dk_doktor.SelectedItem.ToString() + "'";
                da = new MySqlDataAdapter(komut, con);
                da.Fill(dt1);
                con.Close();
                dt1.Columns.RemoveAt(0);
                dt1.Columns.RemoveAt(0);
                dt1.Columns.RemoveAt(3);
                guna2DataGridView2.DataSource = dt1;
                guna2DataGridView2.Columns[0].HeaderText = "TC";
                guna2DataGridView2.Sort(this.guna2DataGridView2.Columns["TARIH"], ListSortDirection.Descending);
            }
        }

        private void dk_doktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            dosya();
        }

        private void dk_filtre_TextChanged(object sender, EventArgs e)
        {
            filter1();
        }

        private void dkf_ad_CheckedChanged(object sender, EventArgs e)
        {
            filter1();
        }

        private void rnd()
        {
            rnd_filtre.Text = "";
            rndf_ad.Checked = false;
            rndf_soyad.Checked = false;
            rndf_tc.Checked = false;
            rndf_doktor.Checked = false;
            con.Open();
            string komut = "select * from randevular where Adult='" + user + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(komut, con);
            dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            dt1.Columns.RemoveAt(1);
            dt1.Columns.RemoveAt(6);
            guna2DataGridView3.DataSource = dt1;
            guna2DataGridView3.Columns[1].HeaderText = "TC";
            guna2DataGridView3.Sort(this.guna2DataGridView3.Columns["TARIH"], ListSortDirection.Descending);
            guna2DataGridView3.Columns[0].Visible = false;
            hs1 = guna2DataGridView3.Rows.Count;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            hk_1.Visible = true;
            hk_2.Visible = true;
            dk_1.Visible = true;
            dk_2.Visible = true;
            rnd_1.Visible = true;
            rnd_2.Visible = true;
            aml_1.Visible = false;
            aml_2.Visible = false;
            rnd();
            anasayfa = "randevu";
        }

        private void rnd_filtre_TextChanged(object sender, EventArgs e)
        {
            filter2();
        }

        private void filter2()
        {
            if (rndf_ad.Checked == true)
            {
                dt1.DefaultView.RowFilter = string.Format("AD like '%" + rnd_filtre.Text + "%'");
            }
            if (rndf_soyad.Checked == true)
            {
                dt1.DefaultView.RowFilter = string.Format("SOYAD like '%" + rnd_filtre.Text + "%'");
            }
            if (rndf_doktor.Checked == true)
            {
                dt1.DefaultView.RowFilter = string.Format("DOKTOR like '%" + rnd_filtre.Text + "%'");
            }
            if (rndf_tc.Checked == true)
            {
                dt1.DefaultView.RowFilter = string.Format("TC_NO like '%" + rnd_filtre.Text + "%'");
            }
        }

        string id;

        private void rnd_sil_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.baslik = "DİKKAT!";
            fr.str = "Seçilen veriyi silmek istediğinize emin misiniz?";
            fr.formmod = 2;
            if (fr.ShowDialog() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in guna2DataGridView3.SelectedRows)
                {
                    id = row.Cells[0].Value.ToString();
                }
                con.Open();
                cmd = new MySqlCommand("Delete from randevular where Adult='" + user + "' AND id='" + id + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                rnd();
            }
        }

        private void aml()
        {
            aml_filtre.Text = "";
            amlf_ad.Checked = false;
            amlf_soyad.Checked = false;
            amlf_tc.Checked = false;
            amlf_doktor.Checked = false;
            con.Open();
            string komut = "select * from ameliyatlar where Adult='" + user + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(komut, con);
            dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            dt1.Columns.RemoveAt(1);
            dt1.Columns.RemoveAt(6);
            guna2DataGridView4.DataSource = dt1;
            guna2DataGridView4.Columns[1].HeaderText = "TC";
            guna2DataGridView4.Sort(this.guna2DataGridView4.Columns["TARIH"], ListSortDirection.Descending);
            guna2DataGridView4.Columns[0].Visible = false;
            hs1 = guna2DataGridView4.Rows.Count;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            hk_1.Visible = true;
            hk_2.Visible = true;
            dk_1.Visible = true;
            dk_2.Visible = true;
            rnd_1.Visible = true;
            rnd_2.Visible = true;
            aml_1.Visible = true;
            aml_2.Visible = true;
            anasayfa = "ameliyat";
            aml();
        }

        private void filter3()
        {
            if (amlf_ad.Checked == true)
            {
                dt1.DefaultView.RowFilter = string.Format("AD like '%" + aml_filtre.Text + "%'");
            }
            if (amlf_soyad.Checked == true)
            {
                dt1.DefaultView.RowFilter = string.Format("SOYAD like '%" + aml_filtre.Text + "%'");
            }
            if (amlf_doktor.Checked == true)
            {
                dt1.DefaultView.RowFilter = string.Format("DOKTOR like '%" + aml_filtre.Text + "%'");
            }
            if (amlf_tc.Checked == true)
            {
                dt1.DefaultView.RowFilter = string.Format("TC_NO like '%" + aml_filtre.Text + "%'");
            }
        }

        private void aml_filtre_TextChanged(object sender, EventArgs e)
        {
            filter3();
        }

        private void aml_sil_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.baslik = "DİKKAT!";
            fr.str = "Seçilen veriyi silmek istediğinize emin misiniz?";
            fr.formmod = 2;
            if(fr.ShowDialog() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in guna2DataGridView4.SelectedRows)
                {
                    id = row.Cells[0].Value.ToString();
                }
                con.Open();
                cmd = new MySqlCommand("Delete from ameliyatlar where Adult='" + user + "' AND id='" + id + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                aml();
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
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(anasayfa == "hasta")
            {
                con.Open();
                string komut = "select * from hastalar where Adult='" + user + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(komut, con);
                DataTable dtt1 = new DataTable();
                da.Fill(dtt1);
                hs2 = dtt1.Rows.Count;
                con.Close();
                if (hs2 > hs1)
                {
                    hasta();
                }
            }
            if (anasayfa == "doktor")
            {
                string aa = "";
                con.Open();
                string komut = "select * from doktorlar where Adult='" + user + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(komut, con);
                DataTable dtt1 = new DataTable();
                da.Fill(dtt1);
                hs2 = dtt1.Rows.Count;
                con.Close();
                if(dk_doktor.SelectedIndex > -1)
                {
                    aa = dk_doktor.SelectedItem.ToString();
                }
                if (hs2 > hs1)
                {
                    doktorlist();
                }
                if(aa != "")
                {
                    dk_doktor.SelectedIndex = dk_doktor.FindStringExact(aa);
                }
            }
            if (anasayfa == "randevu")
            {
                con.Open();
                string komut = "select * from randevular where Adult='" + user + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(komut, con);
                DataTable dtt1 = new DataTable();
                da.Fill(dtt1);
                hs2 = dtt1.Rows.Count;
                con.Close();
                if (hs2 > hs1)
                {
                    rnd();
                }
            }
            if (anasayfa == "ameliyat")
            {
                con.Open();
                string komut = "select * from ameliyatlar where Adult='" + user + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(komut, con);
                DataTable dtt1 = new DataTable();
                da.Fill(dtt1);
                hs2 = dtt1.Rows.Count;
                con.Close();
                if (hs2 > hs1)
                {
                    aml();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contest.Open();
            cmd = new MySqlCommand("Select * from hesaplar where username='" + user + "'", contest);
            cmd.ExecuteNonQuery();
            DataTable data = new DataTable();
            MySqlDataAdapter dadp = new MySqlDataAdapter(cmd);
            dadp.Fill(data);
            foreach (DataRow dr in data.Rows)
            {
                outdate = DateTime.Parse(dr["outdate"].ToString());
            }
            contest.Close();
            string a = (outdate - DateTime.Now.AddDays(-1)).ToString().Split('.')[0];
            if (a.Substring(0, 1) == "-")
            {
                Form2 fr1 = new Form2();
                fr1.baslik = "ÜYELİK";
                fr1.str = "Üyeliğiniz sona ermiştir. Ödeme yaptığınız zaman verilerinize tekrar erişebilirsiniz. Eğer 1 yıl içinde ödeme yapmazsanız bütün verileriniz silinecektir!";
                fr1.formmod = 1;
                fr1.ShowDialog();
                Application.Exit();
            }
        }

        private void filter()
        {
            if (hkf_ad.Checked == true)
            {
                dt1.DefaultView.RowFilter = string.Format("AD like '%" + hk_filtre.Text + "%'");
            }
            if (hkf_soyad.Checked == true)
            {
                dt1.DefaultView.RowFilter = string.Format("SOYAD like '%" + hk_filtre.Text + "%'");
            }
            if (hkf_tel.Checked == true)
            {
                dt1.DefaultView.RowFilter = string.Format("TELEFON like '%" + hk_filtre.Text + "%'");
            }
            if (hkf_tc.Checked == true)
            {
                dt1.DefaultView.RowFilter = string.Format("TC_NO like '%" + hk_filtre.Text + "%'");
            }
        }

        private void hk_filtre_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void hk_sil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
            {
                tc = row.Cells[0].Value.ToString();
                ad = row.Cells[1].Value.ToString();
                soyad = row.Cells[2].Value.ToString();
            }
            Form2 fr = new Form2();
            fr.baslik = "DİKKAT!";
            fr.str = ad + " " + soyad + " isimli ve " + tc + " T.C. kimlik numaralı hastaya ait bütün bilgileri silmek üzeresiniz! Eğer hastayı silerseniz hastaya ait bütün randevu ve ameliyatlar da silinecektir. Silmek istediğinize emin misiniz?";
            fr.formmod = 2;
            if (fr.ShowDialog() == DialogResult.Yes)
            {
                con.Open();
                cmd = new MySqlCommand("Delete from hastalar where Adult='" + user + "' AND TC_NO='" + tc + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd = new MySqlCommand("Delete from randevular where Adult='" + user + "' AND TC_NO='" + tc + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                cmd = new MySqlCommand("Delete from ameliyatlar where Adult='" + user + "' AND TC_NO='" + tc + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                hasta();
            }
        }

        DateTime tarih;
        int x;
        private void hk_guncelle_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
            {
                tc = row.Cells[0].Value.ToString();
                ad = row.Cells[1].Value.ToString();
                soyad = row.Cells[2].Value.ToString();
                tel = row.Cells[3].Value.ToString();
                cinsiyet = row.Cells[4].Value.ToString();
                tarih = DateTime.Parse(row.Cells[5].Value.ToString()).Date;
            }
            yazi = string.Empty;
            cc = string.Empty;
            x = 0;
            if(hk_tc.ForeColor == Color.Lime && hk_tc.Text != tc)
            {
                x++;
                yazi += "\nT.C. Kimlik NO: " + tc + " » " + hk_tc.Text;
            }
            if(hk_ad.Text != "" && hk_ad.Text != ad)
            {
                x++;
                yazi += "\nAd: " + ad + " » " + hk_ad.Text;
            }
            if (hk_soyad.Text != "" && hk_soyad.Text != soyad)
            {
                x++;
                yazi += "\nSoyad: " + soyad + " » " + hk_soyad.Text;
            }
            if (hk_tel.Text != "" && hk_tel.Text != tel)
            {
                x++;
                yazi += "\nTelefon: " + tel + " » " + hk_tel.Text;
            }
            if (hk_kadın.Checked != false && cinsiyet != "Kadın")
            {
                x++;
                yazi += "\nCinsiyet: " + cinsiyet + " » " + "Kadın";
            }
            if (hk_erkek.Checked != false && cinsiyet != "Erkek")
            {
                x++;
                yazi += "\nCinsiyet: " + cinsiyet + " » " + "Erkek";
            }
            if (DateTime.Parse(hk_tarih.Text).Date != DateTime.Now.Date && DateTime.Parse(hk_tarih.Text).Date != tarih)
            {
                x++;
                yazi += "\nDoğum Tarihi: " + tarih.ToString().Split(' ')[0] + " » " + DateTime.Parse(hk_tarih.Text).Date.ToString().Split(' ')[0];
            }
            if(x> 0)
            {
                Form2 fr = new Form2();
                fr.baslik = "DİKKAT!";
                fr.str = "Verileriniz aşağıdaki gibi güncellenecektir. Güncellemek istediğinize emin misiniz?\n" + yazi;
                fr.formmod = 2;
                if(fr.ShowDialog() == DialogResult.Yes)
                {
                    if (hk_ad.Text != "" && hk_ad.Text != ad)
                    {
                        con.Open();
                        string query = "UPDATE hastalar SET AD=@A WHERE Adult='" + user + "' AND TC_NO='" + tc + "'";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@A", hk_ad.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if (hk_soyad.Text != "" && hk_soyad.Text != soyad)
                    {
                        con.Open();
                        string query = "UPDATE hastalar SET SOYAD=@A WHERE Adult='" + user + "' AND TC_NO='" + tc + "'";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@A", hk_soyad.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if (hk_tel.Text != "" && hk_tel.Text != tel)
                    {
                        con.Open();
                        string query = "UPDATE hastalar SET TELEFON=@A WHERE Adult='" + user + "' AND TC_NO='" + tc + "'";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@A", hk_tel.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if (hk_kadın.Checked != false && cinsiyet != "Kadın")
                    {
                        con.Open();
                        string query = "UPDATE hastalar SET CINSIYET=@A WHERE Adult='" + user + "' AND TC_NO='" + tc + "'";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@A", "Kadın");
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if (hk_erkek.Checked != false && cinsiyet != "Erkek")
                    {
                        con.Open();
                        string query = "UPDATE hastalar SET CINSIYET=@A WHERE Adult='" + user + "' AND TC_NO='" + tc + "'";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@A", "Erkek");
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if (DateTime.Parse(hk_tarih.Text).Date != DateTime.Now.Date && DateTime.Parse(hk_tarih.Text).Date != tarih)
                    {
                        con.Open();
                        string query = "UPDATE hastalar SET DOGUM_TARIHI=@A WHERE Adult='" + user + "' AND TC_NO='" + tc + "'";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@A", DateTime.Parse(hk_tarih.Text).Date);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if (hk_tc.ForeColor == Color.Lime && hk_tc.Text != tc)
                    {
                        con.Open();
                        string query = "UPDATE hastalar SET TC_NO=@A WHERE Adult='" + user +"' AND TC_NO='" + tc + "'";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@A", hk_tc.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    hasta();
                    hk_tc.Text = "";
                    hk_ad.Text = "";
                    hk_soyad.Text = "";
                    hk_tel.Text = "";
                    hk_kadın.Checked = false;
                    hk_erkek.Checked = false;
                    hk_tarih.Value = DateTime.Now;
                }
            }
            else
            {
                Form2 fr = new Form2();
                fr.baslik = "HATA!";
                fr.str = "Lütfen girdiğiniz verilerin doğru ve şu ankinden farklı olduğundan emin olun.";
                fr.formmod = 1;
                fr.ShowDialog();
            }
        }
    }
}
