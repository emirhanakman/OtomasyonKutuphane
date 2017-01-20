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
using System.Data.Sql;
namespace OtomasyonKutuphane
{
    public partial class odunc : Form
    {
        public odunc()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;");
        private void odunc_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "SELECT odunc.odID,kitaplar.kitapAdi,personel.perAdi+' '+personel.perSoyad,uyeler.uyeTC,odunc.vTarih,odunc.vSure,odunc.alkitadedi, DATEDIFF(day,vtarih,getdate()) as fark from odunc,personel,uyeler,kitapAdedi,kitaplar,iade where odunc.perNO=personel.perNO and uyeler.uyeTC=odunc.uyeTC and kitaplar.kitapID=odunc.kitapID and kitaplar.kitapID=kitapAdedi.kitapID and iade.verdimi='H' and iade.odID=odunc.odID";
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
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {                   
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand sorgu2 = new SqlCommand("SELECT odunc.odID,kitaplar.kitapAdi,personel.perAdi+' '+personel.perSoyad,uyeler.uyeTC,odunc.vTarih,odunc.vSure,odunc.alkitadedi, DATEDIFF(day,vtarih,getdate()) as fark from odunc,personel,uyeler,kitapAdedi,kitaplar,iade where odunc.perNO=personel.perNO and uyeler.uyeTC=odunc.uyeTC and kitaplar.kitapID=odunc.kitapID and kitaplar.kitapID=kitapAdedi.kitapID and iade.verdimi='H' and iade.odID=odunc.odID", baglanti);
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
        private void button1_Click_1(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
