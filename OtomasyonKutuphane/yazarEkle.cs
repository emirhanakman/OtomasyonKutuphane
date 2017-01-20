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
    public partial class yazarEkle : Form
    {
        public yazarEkle()
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

            if ((textBox2.Text != null) && (textBox3.Text != null))
            {
               
                    SqlCommand sorgu2 = new SqlCommand();
                    sorgu2.Connection = baglanti;
                    sorgu2.CommandText = "insert into yazar(yazarAdi,yazarSoyadi,iletisim) values(@yazarAdi,@yazarSoyadi,@iletisim)";
                    sorgu2.Parameters.AddWithValue("@yazarAdi",textBox2.Text);
                    sorgu2.Parameters.AddWithValue("@yazarSoyadi",textBox3.Text);
                    sorgu2.Parameters.AddWithValue("@iletisim",textBox4.Text);
                    sorgu2.ExecuteNonQuery();

                    MessageBox.Show(" Kayıt Başarıyla Eklendi ! ");
                    
                    
            }
            baglanti.Close();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
                   

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
