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
    public partial class oduncIslemleri : Form
    {
        public oduncIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;");
        private void button2_Click(object sender, EventArgs e)
        {      
        }
        string odID;
        private void oduncIslemleri_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "SELECT odunc.odID,kitaplar.kitapAdi,personel.perAdi+' '+personel.perSoyad,uyeler.uyeTC,odunc.vTarih,odunc.vSure,odunc.alkitadedi, DATEDIFF(day,vtarih,getdate()) as fark from odunc,personel,uyeler,kitapAdedi,kitaplar,iade where odunc.perNO=personel.perNO and uyeler.uyeTC=odunc.uyeTC and kitaplar.kitapID=odunc.kitapID and kitaplar.kitapID=kitapAdedi.kitapID and iade.verdimi='H' and odunc.odID=iade.odID";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].DataPropertyName = dt.Columns[i].ToString();
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            //------------------- KİTAP ID VE BİLGİLERİ COMBOBOX1'E ÇEKİLİYOR..
            DataTable dt2 = new DataTable();
            using (SqlDataAdapter da2 = new SqlDataAdapter(@"select kitaplar.kitapID,kitaplar.kitapAdi from kitaplar", baglanti))
                da2.Fill(dt2);
            comboBox1.DataSource = new BindingSource(dt2, null);
            comboBox1.DisplayMember = "kitapAdi"; //kolon adi görüntülenecek
            comboBox1.ValueMember = "kitapID"; //arkaplanda saklanacak veri
            //-------------- Personel ID ve Ad Soyad Bilgileri Combobox2'ye Çekildi.
            DataTable dt3 = new DataTable();
            using (SqlDataAdapter da3 = new SqlDataAdapter(@"select personel.perNO,personel.perAdi from personel", baglanti))
                da3.Fill(dt3);
            comboBox2.DataSource = new BindingSource(dt3, null);
            comboBox2.DisplayMember = "perAdi";
            comboBox2.ValueMember = "perNO";
            //--------------- Üye TC no ve bilgileri çekildi
            DataTable dt4 = new DataTable();
            using (SqlDataAdapter da4 = new SqlDataAdapter(@"select uyeler.uyeTC,uyeler.uyeAdi from uyeler", baglanti))
                da4.Fill(dt4);
            comboBox3.DataSource = new BindingSource(dt4, null);
            comboBox3.DisplayMember = "uyeAdi";
            comboBox3.ValueMember = "uyeTC";
        }

        private void button1_Click(object sender, EventArgs e)
        {       
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult tus = MessageBox.Show("Seçili Alandaki Ödünç Bilgilerini Düzenlemek İstiyor Musunuz ? ", " - Güncelleme ve Silme İşlemi - ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                odID = dataGridView1.SelectedCells[0].Value.ToString();
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                SqlCommand sorgu = new SqlCommand();
                sorgu.Connection = baglanti;
                sorgu.CommandText = "select * from odunc where odID=@odID";
                sorgu.Parameters.AddWithValue("@odID", odID);
                SqlDataReader dr = sorgu.ExecuteReader();
                dr.Read();
                comboBox1.SelectedItem = dr["kitapID"].ToString();
                comboBox2.SelectedItem = dr["perNO"].ToString();
                comboBox3.SelectedItem = dr["uyeTC"].ToString();
                textBox2.Text = dr["vSure"].ToString();
                textBox3.Text = dr["alKitAdedi"].ToString();           
                dateTimePicker1.Text = dr["vTarih"].ToString();
                dr.Close();
                baglanti.Close();
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "update odunc set kitapID=@kitapID,perNO=@perNO,uyeTC=@uyeTC,vTarih=@vTarih,vSure=@vSure,alKitAdedi=@alKitAdedi where odID=@odID";
            sorgu.Parameters.AddWithValue("@odID", odID);
            sorgu.Parameters.AddWithValue("@kitapID", comboBox1.SelectedValue);
            sorgu.Parameters.AddWithValue("@perNO", comboBox2.SelectedValue);
            sorgu.Parameters.AddWithValue("@uyeTC", comboBox3.SelectedValue);
            sorgu.Parameters.AddWithValue("@vTarih", dateTimePicker1.Value);
            sorgu.Parameters.AddWithValue("@vSure", textBox2.Text);
            sorgu.Parameters.AddWithValue("@alKitAdedi", textBox3.Text);
            DialogResult tus = MessageBox.Show("Güncelleme İşlemini Onaylıyor Musunuz ? ", " Güncelleme İşlemi ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {
                sorgu.ExecuteNonQuery();
            }
            baglanti.Close();
            oduncIslemleri_Load(null, null);
        }
    }
}
        
    

