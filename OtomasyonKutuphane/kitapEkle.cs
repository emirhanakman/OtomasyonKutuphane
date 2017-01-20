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
    public partial class kitapEkle : Form
    {
        public kitapEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;");
        private void kitapEkle_Load(object sender, EventArgs e)
        {
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select kitaplar.kitapID,kitaplar.kitapAdi,kitaplar.yazarID,kitaplar.kitSayfasi,kitaplar.yayinID,kitaplar.basimTarihi,kitapAdedi.kitAdedi from kitapAdedi,kitaplar where kitapAdedi.kitapID=kitaplar.kitapID";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dtp = new DataTable();
            adp.Fill(dtp);
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].DataPropertyName = dtp.Columns[i].ToString();
            }
            dataGridView1.DataSource = dtp;
            dataGridView1.Refresh();
            SqlCommand yukle = new SqlCommand("select kitaplar.kitapID from kitaplar", baglanti);
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT yazarID, yazarAdi FROM yazar", baglanti))
                da.Fill(dt);
            comboBox1.DataSource = new BindingSource(dt, null);
            comboBox1.DisplayMember = "yazarAdi"; //kolon adi görüntülenecek
            comboBox1.ValueMember = "yazarID"; //arkaplanda saklanacak veri
            DataTable dtb = new DataTable();
            using (SqlDataAdapter ad = new SqlDataAdapter(@"SELECT yayinID, yayAdi FROM yayinevi", baglanti))
                ad.Fill(dtb);
            comboBox2.DataSource = new BindingSource(dtb, null);
            comboBox2.DisplayMember = "yayAdi"; //kolon adi görüntülenecek
            comboBox2.ValueMember = "yayinID"; //arkaplanda saklanacak veri
            DataTable dtbl = new DataTable();
            using (SqlDataAdapter ad = new SqlDataAdapter(@"SELECT katID, cesit FROM kategori", baglanti))
                ad.Fill(dtbl);
            comboBox3.DataSource = new BindingSource(dtbl, null);
            comboBox3.DisplayMember = "cesit"; //kolon adi görüntülenecek
            comboBox3.ValueMember = "katID"; //arkaplanda saklanacak veri                                      
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {     
                baglanti.Open();
            }
            int kayitsayisi;
            if ((textBox2.Text != null) && (adet.Text !=null))
            {
                dataGridView1.Refresh();
                DateTime dtarih = dateTimePicker1.Value;
                    SqlCommand sorgu2 = new SqlCommand();
                    sorgu2.Connection = baglanti;
                    sorgu2.CommandText = "insert into kitaplar(kitapAdi,yazarID,kitSayfasi,basimTarihi,yayinID,katID) values(@kitapAdi,@yazarID,@kitSayfasi,@basimTarihi,@yayinID,@katID)";
                    sorgu2.Parameters.AddWithValue("@kitapAdi",textBox2.Text);
                    sorgu2.Parameters.AddWithValue("@yazarID",comboBox1.SelectedValue);
                    sorgu2.Parameters.AddWithValue("@kitSayfasi",textBox4.Text);
                    sorgu2.Parameters.AddWithValue("@basimTarihi",dateTimePicker1.Value);
                    sorgu2.Parameters.AddWithValue("@yayinID",comboBox2.SelectedValue);
                    sorgu2.Parameters.AddWithValue("@katID",comboBox3.SelectedValue);
                    sorgu2.ExecuteNonQuery();  // kitap ekleme işlemi tamamlandı.             
                //------------------ KİTAP ADEDİ EKLEME KISMI              
                    kitapEkle_Load(null, null);
                    dataGridView1.Refresh();
                    kayitsayisi = dataGridView1.RowCount;
                 //   MessageBox.Show(kayitsayisi.ToString()); en son eklenen kayıtın id değeri
                    SqlCommand sorgu3 = new SqlCommand();
                    sorgu3.Connection = baglanti;
                    sorgu3.CommandText = "insert into kitapAdedi(kitapID,kitAdedi) values(@kitID,@kitAdedi)";
                    sorgu3.Parameters.AddWithValue("@kitID", kayitsayisi);
                    sorgu3.Parameters.AddWithValue("@kitAdedi", adet.Text);
                    sorgu3.ExecuteNonQuery();  // kitap ekleme işlemi tamamlandı.      
                    MessageBox.Show(" Kayıt Başarıyla Eklendi ! ");
                    textBox2.Text = "";
                    adet.Text = "";
                    textBox4.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    baglanti.Close();
                    kitapEkle_Load(null,null);
                    dataGridView1.Refresh();                   
            }       
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";     
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {     
        }
        private void button3_Click(object sender, EventArgs e)
        {         
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
