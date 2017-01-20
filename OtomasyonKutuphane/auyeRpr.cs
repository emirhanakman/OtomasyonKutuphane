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
    public partial class auyeRpr : Form
    {
        public auyeRpr()
        {
            InitializeComponent();
        }

        private void auyeRpr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kutuphaneDBDataSet.uyeler' table. You can move, or remove it, as needed.
            this.uyelerTableAdapter.Fill(this.kutuphaneDBDataSet.uyeler);

            this.reportViewer1.RefreshReport();
        }
    }
}
