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
namespace OtomasyonKutuphane
{
    public partial class yazarIslemleri : Form
    {
        public yazarIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;");
        private void yazarIslemleri_Load(object sender, EventArgs e)
        {
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;

            sorgu.CommandText = "select * from yazar";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].DataPropertyName = dt.Columns[i].ToString();
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();


            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "update yazar set yazarAdi=@yazarAdi,yazarSoyadi=@yazarSoyadi,iletisim=@iletisim where yazarID=@yazarID";
            sorgu.Parameters.AddWithValue("@yazarID", textBox1.Text);
            sorgu.Parameters.AddWithValue("@yazarAdi", textBox2.Text);
            sorgu.Parameters.AddWithValue("@yazarSoyadi", textBox3.Text);
            sorgu.Parameters.AddWithValue("@iletisim", textBox4.Text);

            DialogResult tus = MessageBox.Show("Güncelleme İşlemini Onaylıyor Musunuz ? ", " Güncelleme İşlemi ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {

                sorgu.ExecuteNonQuery();

            }
            baglanti.Close();

            yazarIslemleri_Load(null, null);
        }
        string yazarno;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult tus = MessageBox.Show("Seçili Alandaki Yazar Bilgilerini Değiştirmek İstiyor Musunuz ? ", " - Güncelleme ve Silme İşlemi - ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                yazarno = dataGridView1.SelectedCells[0].Value.ToString();


                if (baglanti.State == ConnectionState.Closed)
                {

                    baglanti.Open();
                }
                SqlCommand sorgu = new SqlCommand();
                sorgu.Connection = baglanti;
                sorgu.CommandText = "select * from yazar where yazarID=@yazarID";

                sorgu.Parameters.AddWithValue("@yazarID", yazarno);
                SqlDataReader dr = sorgu.ExecuteReader();
                dr.Read();
                textBox1.Text = dr["yazarID"].ToString();
                textBox2.Text = dr["yazarAdi"].ToString();
                textBox3.Text = dr["yazarSoyadi"].ToString();
                textBox4.Text = dr["iletisim"].ToString();

                dr.Close();
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tus = MessageBox.Show("Seçili Alandaki Yazar Bilgilerini Silmek İstiyor Musunuz ? ", " -  Silme İşlemi - ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                yazarno = dataGridView1.SelectedCells[0].Value.ToString();


                if (baglanti.State == ConnectionState.Closed)
                {

                    baglanti.Open();
                }
                SqlCommand sorgu = new SqlCommand();
                sorgu.Connection = baglanti;
                sorgu.CommandText = "delete from yazar where yazarID=@yazarID";

                sorgu.Parameters.AddWithValue("@yazarID", yazarno);

                sorgu.ExecuteNonQuery();
                yazarIslemleri_Load(null,null);
                baglanti.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}