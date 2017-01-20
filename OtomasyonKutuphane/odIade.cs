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
    public partial class odIade : Form
    {
        public odIade()
        {
            InitializeComponent();
        }
        string iade = "E";
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;MultipleActiveResultSets=True;");
        private void odIade_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "SELECT odunc.odID,odunc.kitapID,kitaplar.kitapAdi,personel.perAdi+' '+personel.perSoyad,uyeler.uyeTC,odunc.vTarih,odunc.vSure,odunc.alkitadedi, DATEDIFF(day,vtarih,getdate()) as fark from odunc,personel,uyeler,kitapAdedi,kitaplar,iade where odunc.perNO=personel.perNO and uyeler.uyeTC=odunc.uyeTC and kitaplar.kitapID=odunc.kitapID and kitaplar.kitapID=kitapAdedi.kitapID and iade.verdimi='H' and odunc.odID=iade.odID";
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
            sorgu.CommandText = "update iade set verdimi=@verdimi where odID=@odID";
            sorgu.Parameters.AddWithValue("@odID", dataGridView1.SelectedCells[0].Value.ToString());
            sorgu.Parameters.AddWithValue("@verdimi", iade);         
            SqlCommand sorgu3 = new SqlCommand("Insert into iade(verdimi,iadeTarih) values(@verdimi,@iadeTarih)", baglanti);
            sorgu3.Parameters.AddWithValue("@verdimi", iade);
            sorgu3.Parameters.AddWithValue("@iadeTarih", DateTime.Now.Date);
            sorgu3.Parameters.AddWithValue("@odID", dataGridView1.SelectedCells[0].Value.ToString());
            sorgu3.ExecuteNonQuery();
            sorgu.ExecuteNonQuery();
            SqlCommand sorgu2 = new SqlCommand("Update kitapAdedi set kitAdedi+=1 where kitapID=@kitapID", baglanti);
            sorgu2.Parameters.AddWithValue("@kitapID",dataGridView1.SelectedCells[1].Value.ToString());
            sorgu2.ExecuteNonQuery();      
            baglanti.Close();
            odIade_Load(null, null);
            dataGridView1.Refresh();
            MessageBox.Show("Kitap Başarı İle İade Edildi ! ");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }
    }
}
