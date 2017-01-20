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
    public partial class uyeIslemleri : Form
    {
        public uyeIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;");
        private void uyeIslemleri_Load(object sender, EventArgs e)
        {

            DataTable dt2 = new DataTable();
            using (SqlDataAdapter da2 = new SqlDataAdapter(@"select uyeler.aktifmi from uyeler", baglanti))
                da2.Fill(dt2);
            comboBox1.DataSource = new BindingSource(dt2, null);
            comboBox1.DisplayMember = "aktifmi"; //kolon adi görüntülenecek
            comboBox1.ValueMember = "aktifmi"; //arkaplanda saklanacak veri

            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;

            sorgu.CommandText = "select * from uyeler";
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
            sorgu.CommandText = "update uyeler set uyeAdi=@uyeAdi,uyeSoyadi=@uyeSoyadi,Mail=@Mail,Tel=@Tel,kayitTarihi=@kayitTarihi,aktifmi=@aktifmi where uyeTC=@uyeTC";
            sorgu.Parameters.AddWithValue("@uyeTC", textBox1.Text);
            sorgu.Parameters.AddWithValue("@uyeAdi", textBox2.Text);
            sorgu.Parameters.AddWithValue("@uyeSoyadi", textBox3.Text);
            sorgu.Parameters.AddWithValue("@Mail", textBox4.Text);
            sorgu.Parameters.AddWithValue("@kayitTarihi",dateTimePicker1.Value);
            sorgu.Parameters.AddWithValue("@Tel",textBox5.Text);
          
            sorgu.Parameters.AddWithValue("@aktifmi", comboBox1.SelectedValue);
            DialogResult tus = MessageBox.Show("Güncelleme İşlemini Onaylıyor Musunuz ? ", " Güncelleme İşlemi ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {

                sorgu.ExecuteNonQuery();
            }
            baglanti.Close();

            uyeIslemleri_Load(null, null);
        }
        string uyeTCNO;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          

            //--------------------------------------------------
            DialogResult tus = MessageBox.Show("Seçili Alandaki Üye Bilgilerini Değiştirmek İstiyor Musunuz ? ", " - Güncelleme ve Silme İşlemi - ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                uyeTCNO = dataGridView1.SelectedCells[0].Value.ToString();


                if (baglanti.State == ConnectionState.Closed)
                {

                    baglanti.Open();
                }
                
                SqlCommand sorgu = new SqlCommand();
                sorgu.Connection = baglanti;
                sorgu.CommandText = "select * from uyeler where uyeTC=@uyeTC";

                sorgu.Parameters.AddWithValue("@uyeTC", uyeTCNO);
                SqlDataReader dr = sorgu.ExecuteReader();
                dr.Read();
                textBox1.Text = dr["uyeTC"].ToString();
                textBox2.Text = dr["uyeAdi"].ToString();
                textBox3.Text = dr["uyeSoyadi"].ToString();
                textBox4.Text = dr["Mail"].ToString();
                textBox5.Text = dr["Tel"].ToString();
                dateTimePicker1.Text = dr["kayitTarihi"].ToString();       
                comboBox1.SelectedItem = dr["aktifmi"].ToString();

                dr.Close();
                baglanti.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
            sorgu.CommandText = "delete from uyeler where uyeTC=@uyeTC";
            sorgu.Parameters.AddWithValue("@uyeTC", textBox1.Text);
            
            DialogResult tus = MessageBox.Show("Silme İşlemini Onaylıyor Musunuz ? ", " Silme İşlemi ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {

                sorgu.ExecuteNonQuery();
            }
            baglanti.Close();

            uyeIslemleri_Load(null, null);
        }
    }
}
