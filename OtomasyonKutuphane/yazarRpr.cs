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
    public partial class yazarRpr : Form
    {
        public yazarRpr()
        {
            InitializeComponent();
        }

        private void yazarRpr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kutuphaneDBDataSet.yazar' table. You can move, or remove it, as needed.
            this.yazarTableAdapter.Fill(this.kutuphaneDBDataSet.yazar);

            this.reportViewer1.RefreshReport();
        }
    }
}
