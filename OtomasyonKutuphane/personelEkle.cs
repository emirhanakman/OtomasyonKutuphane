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
    public partial class personelEkle : Form
    {
        public personelEkle()
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

            if ((textBox1.Text != null) && (textBox2.Text != null) && (textBox3.Text != null) && (textBox4.Text != null) && (textBox5.Text != null))
            {
                string perNO = textBox1.Text;

                SqlCommand sorgu = new SqlCommand();
                sorgu.CommandText = "select * from personel where perNO=@perNO";
                sorgu.Connection = baglanti;
                sorgu.Parameters.AddWithValue("@perNO", perNO);
                object sonuc = sorgu.ExecuteScalar();
                if (sonuc != null)
                {
                    MessageBox.Show(" Böyle Bir Personel Numarası Zaten Var!", "HATA !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    SqlCommand sorgu2 = new SqlCommand();
                    sorgu2.Connection = baglanti;
                    sorgu2.CommandText = "insert into personel(perNO,perAdi,perSoyad,Tel,perSifre,perKadi,yetki,cinsiyet) values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + comboBox2.SelectedItem + "','" + comboBox1.SelectedItem + "')";

                    sorgu2.ExecuteNonQuery();

                    MessageBox.Show(" Kayıt Başarıyla Eklendi ! ");
                    
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    int sayi = Convert.ToInt32(textBox1.Text) + 1;
                    textBox1.Text = Convert.ToString(sayi);


                }

            }
            baglanti.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void personelEkle_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("0");
            comboBox1.Items.Add("K");
            comboBox1.Items.Add("E");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
        }
    }

