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
    public partial class oduncEkle : Form
    {
        public oduncEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;MultipleActiveResultSets=True;");
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void oduncEkle_Load(object sender, EventArgs e)
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
            DataTable dt3 = new DataTable();
            using (SqlDataAdapter da3 = new SqlDataAdapter(@"select personel.perNO,personel.perAdi from personel",baglanti))
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
            baglanti.Close();
        }
        int kayitsayisi;
        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            int kayitsayisi;
            if ((textBox2.Text != null) && (textBox3.Text != null))
            {

                SqlCommand sorgu2 = new SqlCommand();
                sorgu2.Connection = baglanti;
                sorgu2.CommandText = "insert into odunc(kitapID,perNo,uyeTC,vTarih,vSure,alKitAdedi) values(@kitapID,@perNO,@uyeTC,@vTarih,@vSure,@alKitAdedi)";
                sorgu2.Parameters.AddWithValue("@kitapID", comboBox1.SelectedValue);
                sorgu2.Parameters.AddWithValue("@perNO", comboBox2.SelectedValue);
                sorgu2.Parameters.AddWithValue("@uyeTC", comboBox3.SelectedValue);
                sorgu2.Parameters.AddWithValue("@vTarih", dateTimePicker1.Value);
                sorgu2.Parameters.AddWithValue("@vSure", textBox2.Text);
                sorgu2.Parameters.AddWithValue("@alKitAdedi", textBox3.Text);
                sorgu2.ExecuteNonQuery();
                dataGridView1.Refresh();

                oduncEkle_Load(null, null);
                kayitsayisi = dataGridView1.RowCount;
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorgu3 = new SqlCommand();
                sorgu3.Connection = baglanti;
                sorgu3.CommandText = "insert into iade (odID,verdimi) values (@odID,@verdimi)";
                sorgu3.Parameters.AddWithValue("@odID", kayitsayisi);
                string verdimi = "H";
                sorgu3.Parameters.AddWithValue("@verdimi", verdimi.ToString());
                sorgu3.ExecuteNonQuery();
                MessageBox.Show("Kitap " + comboBox3.SelectedValue + " No'lu Kullanıcıya Başarı İle Verildi. !");
                oduncEkle_Load(null, null);
            }
            baglanti.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {       
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand sorgu2 = new SqlCommand("SELECT odunc.odID,kitaplar.kitapAdi,personel.perAdi+' '+personel.perSoyad,uyeler.uyeTC,odunc.vTarih,odunc.vSure,kitapAdedi.kitAdedi, DATEDIFF(day,vtarih,getdate()) as fark from odunc,personel,uyeler,kitapAdedi,kitaplar,iade where odunc.perNO=personel.perNO and uyeler.uyeTC=odunc.uyeTC and kitaplar.kitapID=odunc.kitapID and kitaplar.kitapID=kitapAdedi.kitapID and iade.verdimi='H' and iade.odID=odunc.odID", baglanti);
            SqlDataAdapter adp2 = new SqlDataAdapter(sorgu2);
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt2.Rows[i]["fark"]) >= 0 && Convert.ToInt32(dt2.Rows[i]["fark"]) <= 14)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                }
                if (Convert.ToInt32(dt2.Rows[i]["fark"]) >= 15 && Convert.ToInt32(dt2.Rows[i]["fark"]) <= 30)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (Convert.ToInt32(dt2.Rows[i]["fark"]) >= 31 && Convert.ToInt32(dt2.Rows[i]["fark"]) <= 60)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                }
                if (Convert.ToInt32(dt2.Rows[i]["fark"]) >= 61 && Convert.ToInt32(dt2.Rows[i]["fark"]) <= 250)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
            baglanti.Close();      
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }
       private void label1_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter("select kitapAdi,kitapID from kitaplar where kitapadi lIKE '%" + textBox1.Text + "%'",baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "kitapAdi";
            comboBox1.ValueMember = "kitapID";
            baglanti.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {  
        }
        private void label7_Click(object sender, EventArgs e)
        {
        }
        private void groupBox1_Enter_1(object sender, EventArgs e)
        {
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }
      }
   }
