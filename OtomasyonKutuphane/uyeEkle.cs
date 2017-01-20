using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
namespace OtomasyonKutuphane
{
    public partial class uyeEkle : Form
    {
        public uyeEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            if ((textBox1.Text != null) && (textBox2.Text != null) && (textBox3.Text != null) && (textBox4.Text != null))
            {
                string uyeTC = textBox1.Text;
                DateTime dtarih = dateTimePicker1.Value;
                SqlCommand sorgu = new SqlCommand();
                sorgu.CommandText = "select * from uyeler where uyeTC=@uyeTC";
                sorgu.Connection = baglanti;
                sorgu.Parameters.AddWithValue("@uyeTC", uyeTC);
                object sonuc = sorgu.ExecuteScalar();
                if (sonuc != null)
                {
                    MessageBox.Show(" Böyle Bir Üye Numarası Zaten Var!", "HATA !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    SqlCommand sorgu2 = new SqlCommand();
                    sorgu2.Connection = baglanti;
                    sorgu2.CommandText = "insert into uyeler(uyeTC,uyeAdi,uyeSoyadi,Mail,Tel,kayitTarihi,aktifmi) values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dtarih.Date + "','" + comboBox1.SelectedItem +"')";

                    sorgu2.ExecuteNonQuery();

                    MessageBox.Show(" Kayıt Başarıyla Eklendi ! ");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                   
                    comboBox1.Text = "";
                   
                }

            }
            baglanti.Close();
        }

        private void uyeEkle_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("A");
            comboBox1.Items.Add("P");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            comboBox1.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
