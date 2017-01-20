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
    public partial class yayIslemleri : Form
    {
        public yayIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;");
        private void yayIslemleri_Load(object sender, EventArgs e)
        {

            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;

            sorgu.CommandText = "select * from yayinevi";
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        string yayno;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             DialogResult tus = MessageBox.Show("Seçili Alandaki Yayınevi Bilgilerini Değiştirmek İstiyor Musunuz ? ", " - Güncelleme ve Silme İşlemi - ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (tus == DialogResult.Yes)
             {
                 yayno = dataGridView1.SelectedCells[0].Value.ToString();


                 if (baglanti.State == ConnectionState.Closed)
                 {

                     baglanti.Open();
                 }
                 SqlCommand sorgu = new SqlCommand();
                 sorgu.Connection = baglanti;
                 sorgu.CommandText = "select * from yayinevi where yayinID=@yayinID";

                 sorgu.Parameters.AddWithValue("@yayinID", yayno);
                 SqlDataReader dr = sorgu.ExecuteReader();
                 dr.Read();
                 textBox1.Text = dr["yayinID"].ToString();
                 textBox2.Text = dr["yayAdi"].ToString();
                 textBox3.Text = dr["adres"].ToString();
                 textBox4.Text = dr["tel"].ToString();
                 textBox5.Text = dr["mail"].ToString();
                 dr.Close();

             }
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
            sorgu.CommandText = "update yayinevi set yayAdi=@yayAdi,adres=@adres,tel=@tel,mail=@mail where yayinID=@yayinID";
            sorgu.Parameters.AddWithValue("@yayinID", textBox1.Text);
            sorgu.Parameters.AddWithValue("@yayAdi", textBox2.Text);
            sorgu.Parameters.AddWithValue("@adres", textBox3.Text);
            sorgu.Parameters.AddWithValue("@tel", textBox4.Text);
            sorgu.Parameters.AddWithValue("@mail", textBox5.Text);

            DialogResult tus = MessageBox.Show("Güncelleme İşlemini Onaylıyor Musunuz ? ", " Güncelleme İşlemi ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {

                sorgu.ExecuteNonQuery();

            }
            baglanti.Close();

            yayIslemleri_Load(null, null);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
