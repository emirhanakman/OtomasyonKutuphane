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
    public partial class personelIslemleri : Form
    {
        public personelIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;");
        private void personelIslemleri_Load(object sender, EventArgs e)
        {
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;

            sorgu.CommandText = "select * from personel";
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
            sorgu.CommandText = "update personel set perAdi=@perAdi,perSoyad=@perSoyad,Tel=@Tel,perKadi=@perKadi,perSifre=@perSifre,yetki=@yetki,cinsiyet=@cinsiyet where perNO=@perNO";
            sorgu.Parameters.AddWithValue("@perNO", textBox1.Text);
            sorgu.Parameters.AddWithValue("@perAdi", textBox2.Text);
            sorgu.Parameters.AddWithValue("@perSoyad", textBox3.Text);
            sorgu.Parameters.AddWithValue("@Tel", textBox4.Text);
            sorgu.Parameters.AddWithValue("@perKadi", textBox5.Text);
            sorgu.Parameters.AddWithValue("@perSifre", textBox6.Text);
            sorgu.Parameters.AddWithValue("@yetki", comboBox1.SelectedItem);
            sorgu.Parameters.AddWithValue("@cinsiyet", comboBox2.SelectedItem);

            DialogResult tus = MessageBox.Show("Güncelleme İşlemini Onaylıyor Musunuz ? ", " Güncelleme İşlemi ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {

                sorgu.ExecuteNonQuery();

            }
            baglanti.Close();

            personelIslemleri_Load(null, null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string perNO;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           DataTable dt2 = new DataTable();
            using (SqlDataAdapter da2 = new SqlDataAdapter(@"select distinct personel.yetki from personel", baglanti))
                da2.Fill(dt2);
            comboBox1.DataSource = new BindingSource(dt2, null);               
                comboBox1.DisplayMember = "yetki"; //kolon adi görüntülenecek
                comboBox1.ValueMember = "yetki"; //arkaplanda saklanacak veri
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(@"select distinct personel.cinsiyet from personel", baglanti))
                da.Fill(dt);
            comboBox2.DataSource = new BindingSource(dt, null);
            comboBox2.DisplayMember = "cinsiyet"; //kolon adi görüntülenecek
            comboBox2.ValueMember = "cinsiyet"; //arkaplanda saklanacak veri


            //---------------------------------------------------------------------------------------------------------------


            DialogResult tus = MessageBox.Show("Seçili Alandaki Personel Bilgilerini Değiştirmek İstiyor Musunuz ? ", " - Güncelleme ve Silme İşlemi - ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                perNO = dataGridView1.SelectedCells[0].Value.ToString();


                if (baglanti.State == ConnectionState.Closed)
                {

                    baglanti.Open();
                }
                SqlCommand sorgu = new SqlCommand();
                sorgu.Connection = baglanti;
                sorgu.CommandText = "select * from personel where perNO=@perNO";

                sorgu.Parameters.AddWithValue("@perNO", perNO);
                SqlDataReader dr = sorgu.ExecuteReader();
                dr.Read();
                textBox1.Text = dr["perNO"].ToString();
                textBox2.Text = dr["perAdi"].ToString();
                textBox3.Text = dr["perSoyad"].ToString();
                textBox4.Text = dr["Tel"].ToString();
                textBox5.Text = dr["perKadi"].ToString();
                textBox6.Text = dr["perSifre"].ToString();
                comboBox1.SelectedItem = dr["yetki"].ToString();
                comboBox2.SelectedItem = dr["cinsiyet"].ToString();
                dr.Close();

            }
            baglanti.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();

            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "delete from personel where perNO=@perNO";
            sorgu.Parameters.AddWithValue("@perNO", textBox1.Text);
            //---------
          
            DialogResult tus = MessageBox.Show("Silme İşlemini Onaylıyor Musunuz ? ", " Silme İşlemi ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {
                sorgu.ExecuteNonQuery();

                sorgu.ExecuteNonQuery();

            }
            baglanti.Close();

            personelIslemleri_Load(null, null);

        }
    }
}
