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
    public partial class yayinRpr : Form
    {
        public yayinRpr()
        {
            InitializeComponent();
        }

        private void yayinRpr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kutuphaneDBDataSet.yayinevi' table. You can move, or remove it, as needed.
            this.yayineviTableAdapter.Fill(this.kutuphaneDBDataSet.yayinevi);

            this.reportViewer1.RefreshReport();
        }
    }
}
