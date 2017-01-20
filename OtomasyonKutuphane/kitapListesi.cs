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
    public partial class kitapListesi : Form
    {
        public kitapListesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;");

        private void kitapListesi_Load(object sender, EventArgs e)
        {
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;

            sorgu.CommandText = "select kitaplar.kitapID,kitaplar.kitapAdi,yazar.yazarAdi+' '+yazar.yazarSoyadi,kitaplar.kitSayfasi,yayinevi.yayAdi,kitaplar.basimTarihi,kitapAdedi.kitAdedi,kategori.cesit from yazar,kitapAdedi,kitaplar,yayinevi,kategori where kitapAdedi.kitapID=kitaplar.kitapID and yazar.yazarID=kitaplar.yazarID and kitaplar.yayinID=yayinevi.yayinID and kategori.katID=kitaplar.katID";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
