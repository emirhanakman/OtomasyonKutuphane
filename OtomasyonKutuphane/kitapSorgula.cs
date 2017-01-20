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
    public partial class kitapSorgula : Form
    {
        public kitapSorgula()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;");
        private void kitapSorgula_Load(object sender, EventArgs e)
        {
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;

            sorgu.CommandText = "select kitaplar.kitapID,kitaplar.kitapAdi,kitaplar.kitSayfasi,kitaplar.basimTarihi,kitapAdedi.kitAdedi from kitapAdedi,kitaplar where kitaplar.kitapID=kitapAdedi.kitapID";
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
