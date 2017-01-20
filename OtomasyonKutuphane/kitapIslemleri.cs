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
    public partial class kitapIslemleri : Form
    {
        public kitapIslemleri()
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
           
                SqlCommand sorgu = new SqlCommand();
                sorgu.Connection = baglanti;
                sorgu.CommandText = "update kitaplar set kitapAdi=@adi,yazarID=@yazar,kitSayfasi=@sayfaSayisi,basimTarihi=@dtarih,yayinID=@yayinID,katID=@katID where kitapID=@kitapID";
                sorgu.Parameters.AddWithValue("@kitapID", textBox1.Text);
                sorgu.Parameters.AddWithValue("@adi", textBox2.Text);
                sorgu.Parameters.AddWithValue("@yazar", comboBox2.SelectedValue);
                sorgu.Parameters.AddWithValue("@sayfaSayisi", textBox4.Text);
                sorgu.Parameters.AddWithValue("@yayinID", comboBox3.SelectedValue);
                sorgu.Parameters.AddWithValue("@katID", comboBox4.SelectedValue);
                sorgu.Parameters.AddWithValue("@dtarih", dateTimePicker1.Value);
                DialogResult tus = MessageBox.Show("Güncelleme İşlemini Onaylıyor Musunuz ? ", " Güncelleme İşlemi ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {
               sorgu.ExecuteNonQuery();
            }                 
            baglanti.Close();
            kitapIslemleri_Load(null, null);
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void kitapIslemleri_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;

            sorgu.CommandText = "select kitaplar.kitapID,kitaplar.kitapAdi,yazar.yazarAdi+' '+yazar.yazarSoyadi,kitaplar.kitSayfasi,yayinevi.yayAdi,kitaplar.basimTarihi,kitapAdedi.kitAdedi from yazar,kitapAdedi,kitaplar,yayinevi where kitapAdedi.kitapID=kitaplar.kitapID and yazar.yazarID=kitaplar.yazarID and kitaplar.yayinID=yayinevi.yayinID";
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
        string kitapno;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
                
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "delete from kitaplar where kitapID=@kitapID";
            sorgu.Parameters.AddWithValue("@kitapID", textBox1.Text);
            //---------
            SqlCommand kadedisil = new SqlCommand();
            kadedisil.Connection = baglanti;
            kadedisil.CommandText = "delete from kitapAdedi where kitapID=@kitapID";
            kadedisil.Parameters.AddWithValue("@kitapID", textBox1.Text);

            DialogResult tus = MessageBox.Show("Silme İşlemini Onaylıyor Musunuz ? ", " Silme İşlemi ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {
                kadedisil.ExecuteNonQuery();

                sorgu.ExecuteNonQuery();

            }
            baglanti.Close();

            kitapIslemleri_Load(null, null);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Show();
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

            //-------------------------------------------------------------------------------------------------------------
            DataTable dt2 = new DataTable();
            using (SqlDataAdapter da2 = new SqlDataAdapter(@"select yazar.yazarID,yazar.yazarAdi from yazar", baglanti))
                da2.Fill(dt2);
            comboBox2.DataSource = new BindingSource(dt2, null);
            comboBox2.DisplayMember = "yazarAdi"; //kolon adi görüntülenecek
            comboBox2.ValueMember = "yazarID"; //arkaplanda saklanacak veri

            //---------------------------------------------------------------------------------------------------------------
            DataTable dt3 = new DataTable();
            using (SqlDataAdapter da3 = new SqlDataAdapter(@"SELECT yayinID, yayAdi FROM yayinevi", baglanti))
                da3.Fill(dt3);
            comboBox3.DataSource = new BindingSource(dt3, null);
            comboBox3.DisplayMember = "yayAdi"; //kolon adi görüntülenecek
            comboBox3.ValueMember = "yayinID"; //arkaplanda saklanacak veri

            //-------------------------------------
            DataTable dt4 = new DataTable();
            using (SqlDataAdapter da4 = new SqlDataAdapter(@"select kategori.katID,kategori.cesit from kategori", baglanti))
                da4.Fill(dt4);
            comboBox4.DataSource = new BindingSource(dt4, null);
            comboBox4.DisplayMember = "cesit"; //kolon adi görüntülenecek
            comboBox4.ValueMember = "katID"; //arkaplanda saklanacak veri

            //--------------------------------------------------
            DialogResult tus = MessageBox.Show("Seçili Alandaki Kitap Bilgilerini Değiştirmek İstiyor Musunuz ? ", " - Güncelleme ve Silme İşlemi - ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                kitapno = dataGridView1.SelectedCells[0].Value.ToString();


                if (baglanti.State == ConnectionState.Closed)
                {

                    baglanti.Open();
                }
                SqlCommand sorgu = new SqlCommand();
                sorgu.Connection = baglanti;
                sorgu.CommandText = "select * from kitaplar where kitapID=@kitapID";

                sorgu.Parameters.AddWithValue("@kitapID", kitapno);
                SqlDataReader dr = sorgu.ExecuteReader();
                dr.Read();
                textBox1.Text = dr["kitapID"].ToString();
                textBox2.Text = dr["kitapAdi"].ToString();
                comboBox2.SelectedItem = dr["yazarID"].ToString();
                textBox4.Text = dr["kitSayfasi"].ToString();
                dateTimePicker1.Text = dr["basimTarihi"].ToString();
                comboBox3.SelectedItem = dr["yayinID"].ToString();
                comboBox4.SelectedItem = dr["katID"].ToString();

                dr.Close();
                baglanti.Close();
            }
        }
    }
}

