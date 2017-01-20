using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtomasyonKutuphane
{
    public partial class kitapRpr : Form
    {
        public kitapRpr()
        {
            InitializeComponent();
        }

        private void kitapRpr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kutuphaneDBDataSet.kitaplar' table. You can move, or remove it, as needed.
            this.kitaplarTableAdapter.Fill(this.kutuphaneDBDataSet.kitaplar);
            // TODO: This line of code loads data into the 'kutuphaneDBDataSet.personel' table. You can move, or remove it, as needed.
            this.personelTableAdapter.Fill(this.kutuphaneDBDataSet.personel);

            this.reportViewer1.RefreshReport();
        }
    }
}
