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
    public partial class katDuzenle : Form
    {
        public katDuzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;MultipleActiveResultSets=True;");
        private void katDuzenle_Load(object sender, EventArgs e)
        {
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;

            sorgu.CommandText = "select * from kategori";
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
        string katno;
        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            DialogResult tus = MessageBox.Show("Güncelleme İşlemini Onaylıyor Musunuz ? ", " Güncelleme İşlemi ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {
                SqlCommand sorgu = new SqlCommand();
                sorgu.Connection = baglanti;
                sorgu.CommandText = "update kategori set cesit=@cesit,icerik=@icerik where katID=@katID";
                sorgu.Parameters.AddWithValue("@katID", katno);
                sorgu.Parameters.AddWithValue("@cesit", textBox2.Text);
                sorgu.Parameters.AddWithValue("@icerik", textBox3.Text);


                sorgu.ExecuteNonQuery();
            }
            baglanti.Close();
            katDuzenle_Load(null,null);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult tus = MessageBox.Show("Seçili Alandaki Kategori Bilgilerini Değiştirmek İstiyor Musunuz ? ", " - Güncelleme ve Silme İşlemi - ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                katno = dataGridView1.SelectedCells[0].Value.ToString();


                if (baglanti.State == ConnectionState.Closed)
                {

                    baglanti.Open();
                }
                SqlCommand sorgu = new SqlCommand();
                sorgu.Connection = baglanti;
                sorgu.CommandText = "select * from kategori where katID=@katID";

                sorgu.Parameters.AddWithValue("@katID", katno);
                SqlDataReader dr = sorgu.ExecuteReader();
                dr.Read();
                textBox1.Text = dr["katID"].ToString();
                textBox2.Text = dr["cesit"].ToString();
                textBox3.Text = dr["icerik"].ToString();
                katDuzenle_Load(null,null);
                dr.Close();
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();

            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "delete from kategori where katID=@katID";
            sorgu.Parameters.AddWithValue("@katID",textBox1.Text);
            //---------
           
            DialogResult tus = MessageBox.Show("Silme İşlemini Onaylıyor Musunuz ? ", " Silme İşlemi ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {
             
                sorgu.ExecuteNonQuery();

            }
            baglanti.Close();

            katDuzenle_Load(null, null);
        }
    }
}
