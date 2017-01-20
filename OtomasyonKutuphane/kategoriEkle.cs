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
    public partial class kategoriEkle : Form
    {
        public kategoriEkle()
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
                    sorgu2.CommandText = "insert into kategori(cesit,icerik) values(@cesit,@icerik)";
                    sorgu2.Parameters.AddWithValue("@cesit",textBox2.Text);
                    sorgu2.Parameters.AddWithValue("@icerik",textBox3.Text);
                    sorgu2.ExecuteNonQuery();

                    MessageBox.Show(" Kayıt Başarıyla Eklendi ! ");

                    textBox2.Text = "";
                    textBox3.Text = "";

           
            }
            baglanti.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void kategoriEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
