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
    public partial class iadeEdilenKit : Form
    {
        public iadeEdilenKit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Administrator;initial catalog=kutuphaneDB;Integrated Security=True;MultipleActiveResultSets=True;");
        private void iadeEdilenKit_Load(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "SELECT odunc.odID,kitaplar.kitapAdi,personel.perAdi+' '+personel.perSoyad,uyeler.uyeTC,odunc.vTarih,odunc.vSure,iade.iadeTarih,DATEDIFF(day,vtarih,getdate()) as fark from iade,odunc,personel,uyeler,kitapAdedi,kitaplar where odunc.perNO=personel.perNO and uyeler.uyeTC=odunc.uyeTC and kitaplar.kitapID=odunc.kitapID and kitaplar.kitapID=kitapAdedi.kitapID and iade.verdimi='E' and iade.odID=odunc.odID";
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
    }
}
