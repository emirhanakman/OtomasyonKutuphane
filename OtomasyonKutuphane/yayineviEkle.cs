using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace OtomasyonKutuphane
{
    public partial class yayineviEkle : Form
    {
        public yayineviEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;");
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                if ((textBox1.Text != null) && (textBox2.Text != null) && (textBox3.Text != null) && (textBox4.Text != null))
                {
                     SqlCommand sorgu2 = new SqlCommand();
                        sorgu2.Connection = baglanti;
                        sorgu2.CommandText = "insert into yayinevi(yayAdi,adres,tel,mail) values(@yayAdi,@adres,@tel,@mail)";
                        sorgu2.Parameters.AddWithValue("@yayAdi",textBox1.Text);
                        sorgu2.Parameters.AddWithValue("@adres",textBox4.Text);
                        sorgu2.Parameters.AddWithValue("@tel",textBox2.Text);
                        sorgu2.Parameters.AddWithValue("@mail",textBox3.Text);
                        sorgu2.ExecuteNonQuery();

                        MessageBox.Show(" Kayıt Başarıyla Eklendi ! ");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                      
                }
                baglanti.Close();
                   
            }
            catch (Exception Ex)
            {

                MessageBox.Show(" Bir Hata Oluştu ! ","Değerlerinizi Kontrol Ediniz !"+Ex.Message,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void yayineviEkle_Enter(object sender, EventArgs e)
        {
            //button1.Click+=button1_Click;
        }

        private void yayineviEkle_Load(object sender, EventArgs e)
        {
            
        }
    }
}
