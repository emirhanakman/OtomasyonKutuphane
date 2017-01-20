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
    public partial class anaForm : Form
    {
        public anaForm()
        {
            InitializeComponent();
        }

        private void kitapSorgulaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kitapSorgula kitaplar = new kitapSorgula();
            kitaplar.MdiParent = this;

            kitaplar.WindowState = FormWindowState.Maximized;
            kitaplar.Show();
        }

        private void kitapSorgulaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void üyeSorgulaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void anaForm_Load(object sender, EventArgs e)
        {
            string isimm = Form1.isim;
            this.Text = " - Kütüphane Otomasyonu - Kullanıcı Arayüzüne Hoşgeldiniz Sayın "+isimm;
            
        }

        private void üyeListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aktifÜyeListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A_uye aktifUye = new A_uye();
            aktifUye.MdiParent = this;

            aktifUye.WindowState = FormWindowState.Maximized;
            aktifUye.Show();
        }

        private void kitapListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapListesi listeKitap = new kitapListesi();
            listeKitap.MdiParent = this;

            listeKitap.WindowState = FormWindowState.Maximized;
            listeKitap.Show();
        }

        private void personelListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personeListe personel = new personeListe();
            personel.MdiParent = this;

            personel.WindowState = FormWindowState.Maximized;
            personel.Show();
        }

        private void üyeListesiTamamıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyeListesi uyeler = new uyeListesi();
            uyeler.MdiParent = this;

            uyeler.WindowState = FormWindowState.Maximized;
            uyeler.Show();
        }

        private void pasifÜyeListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            P_uye pasifUye = new P_uye();
            pasifUye.MdiParent = this;

            pasifUye.WindowState = FormWindowState.Maximized;
            pasifUye.Show();
        }

        private void üyeSorgulaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yayıneviEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            yayineviEkle yayineviEkle = new yayineviEkle();
            yayineviEkle.MdiParent = this;

            yayineviEkle.WindowState = FormWindowState.Maximized;
            yayineviEkle.Show();
        }

        private void yazarEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yazarEkle ekleYazar = new yazarEkle();
            ekleYazar.MdiParent = this;
            ekleYazar.WindowState = FormWindowState.Maximized;
            ekleYazar.Show();
        }

        private void yazarListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yazarListesi YazarListe = new yazarListesi();
            YazarListe.MdiParent = this;
            YazarListe.WindowState = FormWindowState.Maximized;
            YazarListe.Show();
        }

        private void yayıneviListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            yayineviListesi yayineviListe = new yayineviListesi();
            yayineviListe.MdiParent = this;
            yayineviListe.WindowState = FormWindowState.Maximized;
            yayineviListe.Show();
        }

        private void üyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyeEkle uyeEkle = new uyeEkle();
            uyeEkle.MdiParent = this;
            uyeEkle.WindowState = FormWindowState.Maximized;
            uyeEkle.Show();
        }

        private void kitapEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapEkle eklekitap = new kitapEkle();
            eklekitap.MdiParent = this;
            eklekitap.WindowState = FormWindowState.Maximized;
            eklekitap.Show();
        }

        private void kategoriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            kategoriListe kategoriListe = new kategoriListe();
            kategoriListe.MdiParent = this;

            kategoriListe.WindowState = FormWindowState.Maximized;
            kategoriListe.Show();
        }

        private void kategoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kategoriEkle kategoriEkle = new kategoriEkle();
            kategoriEkle.MdiParent = this;

            kategoriEkle.WindowState = FormWindowState.Maximized;
            kategoriEkle.Show();
        }

        private void üyeListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void personelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personelEkle perEkle = new personelEkle();
            perEkle.MdiParent = this;

            perEkle.WindowState = FormWindowState.Maximized;
            perEkle.Show();
        }

        private void yazarİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yazarIslemleri yazarIslemleri = new yazarIslemleri();
            yazarIslemleri.MdiParent = this;

            yazarIslemleri.WindowState = FormWindowState.Maximized;
            yazarIslemleri.Show();
        }

        private void yayıneviGüncelleVeSilmeİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yayIslemleri yayIslemleri = new yayIslemleri();
            yayIslemleri.MdiParent = this;

            yayIslemleri.WindowState = FormWindowState.Maximized;
            yayIslemleri.Show();
        }

        private void ödünçTablosunuGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oduncIslemleri oduncIslemleri = new oduncIslemleri();
            oduncIslemleri.MdiParent = this;

            oduncIslemleri.WindowState = FormWindowState.Maximized;
            oduncIslemleri.Show();
        }

        private void ödünçKitapVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oduncEkle oduncEkle = new oduncEkle();
            oduncEkle.MdiParent = this;

            oduncEkle.WindowState = FormWindowState.Maximized;
            oduncEkle.Show();
        }

        private void kategoriGüncelleVeSilmeİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            katDuzenle katDuzenle = new katDuzenle();
            katDuzenle.MdiParent = this;

            katDuzenle.WindowState = FormWindowState.Maximized;
            katDuzenle.Show();
        }

        private void kitapRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {

            kitapRpr kitRpr = new kitapRpr();
            kitRpr.MdiParent = this;

            kitRpr.WindowState = FormWindowState.Maximized;
            kitRpr.Show();
        }

        private void üyeRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyeRpr uyeRpr = new uyeRpr();
            uyeRpr.MdiParent = this;

            uyeRpr.WindowState = FormWindowState.Maximized;
            uyeRpr.Show();
        }

        private void personelRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            perRapor perRpr = new perRapor();
            perRpr.MdiParent = this;

            perRpr.WindowState = FormWindowState.Maximized;
            perRpr.Show();
        }

        private void yazarRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yazarRpr yazarRpr = new yazarRpr();
            yazarRpr.MdiParent = this;

            yazarRpr.WindowState = FormWindowState.Maximized;
            yazarRpr.Show();
        }

        private void yayıneviRAporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yayinRpr yayinRpr = new yayinRpr();
            yayinRpr.MdiParent = this;

            yayinRpr.WindowState = FormWindowState.Maximized;
            yayinRpr.Show();
        }

        private void kategoriRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            katRpr katRpr = new katRpr();
            katRpr.MdiParent = this;

            katRpr.WindowState = FormWindowState.Maximized;
            katRpr.Show();
        }

        private void iadeEdilmişKitaplarıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iadeEdilenKit iade = new iadeEdilenKit();
            iade.MdiParent = this;
            iade.WindowState = FormWindowState.Maximized;
            iade.Show();
        }

        private void ödünçKitapİadeEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            odIade iade = new odIade();
            iade.MdiParent = this;
            iade.WindowState = FormWindowState.Maximized;
            iade.Show();
        }

        private void ödünçKitaplarıGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oduncIslemleri oduncIslemleri = new oduncIslemleri();
            oduncIslemleri.MdiParent = this;

            oduncIslemleri.WindowState = FormWindowState.Maximized;
            oduncIslemleri.Show();
        }
    }
}
