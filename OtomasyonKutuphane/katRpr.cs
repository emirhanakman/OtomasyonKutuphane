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
    public partial class katRpr : Form
    {
        public katRpr()
        {
            InitializeComponent();
        }

        private void katRpr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kutuphaneDBDataSet.kategori' table. You can move, or remove it, as needed.
            this.kategoriTableAdapter.Fill(this.kutuphaneDBDataSet.kategori);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
