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
    public partial class adminForm : Form
    {
        public adminForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;initial catalog=kutuphaneDB;Integrated Security=True;");
        private void pasifÜyeListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            P_uye pasifUye = new P_uye();
            pasifUye.MdiParent = this;

            pasifUye.WindowState = FormWindowState.Maximized;
            pasifUye.Show();
        }

        private void kitapSorgulaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kitapListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapListesi listeKitap = new kitapListesi();
            listeKitap.MdiParent = this;

            listeKitap.WindowState = FormWindowState.Maximized;
            listeKitap.Show();
        }

        private void aktifÜyeListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A_uye aktifUye = new A_uye();
            aktifUye.MdiParent = this;

            aktifUye.WindowState = FormWindowState.Maximized;
            aktifUye.Show();
        }

        private void üyeListesiTamamıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyeListesi uyeler = new uyeListesi();
            uyeler.MdiParent = this;

            uyeler.WindowState = FormWindowState.Maximized;
            uyeler.Show();
        }

        private void personelListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personeListe personel = new personeListe();
            personel.MdiParent = this;

            personel.WindowState = FormWindowState.Maximized;
            personel.Show();
        }

        private void adminForm_Load(object sender, EventArgs e)
        {
            string isimm = Form1.isim;
            this.Text = " - Kütüphane Otomasyonu - Yönetici Arayüzüne Hoşgeldiniz Sayın " + isimm;


            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select uyetc,DATEDIFF(day,vtarih,getdate()) as fark from odunc", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["fark"]) > 15)
                {
                    DialogResult tus = MessageBox.Show("Gününde Geri İade Edilmemiş Kitaplar Var. Ayrıntılı Bilgi İçin Evet Tuşuna Basınız..", "Uyarı ! ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (tus == DialogResult.Yes)
                    {
                        oduncEkle odunc = new oduncEkle();
                        odunc.MdiParent = this;

                        odunc.WindowState = FormWindowState.Maximized;
                        odunc.Show();
                    }
                    break;
                }
            }
            baglanti.Close();
            baglanti.Close();
        }

        private void yayıneviEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yayineviEkle yayineviEkle = new yayineviEkle();
            yayineviEkle.MdiParent = this;

            yayineviEkle.WindowState = FormWindowState.Maximized;
            yayineviEkle.Show();
        }

        private void personelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personelEkle perEkle = new personelEkle();
            perEkle.MdiParent = this;

            perEkle.WindowState = FormWindowState.Maximized;
            perEkle.Show();
        }

        private void yazarEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yazarEkle ekleYazar = new yazarEkle();
            ekleYazar.MdiParent = this;
            ekleYazar.WindowState = FormWindowState.Maximized;
            ekleYazar.Show();
        }

        private void kitapEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapEkle eklekitap = new kitapEkle();
            eklekitap.MdiParent = this;
            eklekitap.WindowState = FormWindowState.Maximized;
            eklekitap.Show();
        }

        private void yazarListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yazarListesi YazarListe = new yazarListesi();
            YazarListe.MdiParent = this;
            YazarListe.WindowState = FormWindowState.Maximized;
            YazarListe.Show();
        }

        private void üyeListesiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            uyeListesi uyeListe = new uyeListesi();
            uyeListe.MdiParent = this;
            uyeListe.WindowState = FormWindowState.Maximized;
            uyeListe.Show();
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

        private void kitapGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapIslemleri kitapIslemleri = new kitapIslemleri();
            kitapIslemleri.MdiParent = this;

            kitapIslemleri.WindowState = FormWindowState.Maximized;
            kitapIslemleri.Show();
        }

        private void ödünçİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void üyeDüzenlemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyeIslemleri uyeIslemleri = new uyeIslemleri();
            uyeIslemleri.MdiParent = this;

            uyeIslemleri.WindowState = FormWindowState.Maximized;
            uyeIslemleri.Show();
        }

        private void yazarİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yazarIslemleri yazarIslemleri = new yazarIslemleri();
            yazarIslemleri.MdiParent = this;

            yazarIslemleri.WindowState = FormWindowState.Maximized;
            yazarIslemleri.Show();
        }

        private void kategoriİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            katDuzenle katDuzenle = new katDuzenle();
            katDuzenle.MdiParent = this;

            katDuzenle.WindowState = FormWindowState.Maximized;
            katDuzenle.Show();

        }

        private void yayıneviToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yayıneviİslemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yayIslemleri yayIslemleri = new yayIslemleri();
            yayIslemleri.MdiParent = this;

            yayIslemleri.WindowState = FormWindowState.Maximized;
            yayIslemleri.Show();
        }

        private void personelGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            personelIslemleri personelIslemleri = new personelIslemleri();
            personelIslemleri.MdiParent = this;

            personelIslemleri.WindowState = FormWindowState.Maximized;
            personelIslemleri.Show();
        }

        private void ödünçTablosunuGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            odunc odunc = new odunc();
            odunc.MdiParent = this;

            odunc.WindowState = FormWindowState.Maximized;
            odunc.Show();
        }

        private void ödünçKitapVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oduncEkle oduncEkle = new oduncEkle();
            oduncEkle.MdiParent = this;

            oduncEkle.WindowState = FormWindowState.Maximized;
            oduncEkle.Show();
        }

        private void ödünçKitaplarıGüncelleVeyaSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oduncIslemleri oduncIslemleri = new oduncIslemleri();
            oduncIslemleri.MdiParent = this;

            oduncIslemleri.WindowState = FormWindowState.Maximized;
            oduncIslemleri.Show();

        }

        private void personelRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            perRapor perRpr = new perRapor();
            perRpr.MdiParent = this;

            perRpr.WindowState = FormWindowState.Maximized;
            perRpr.Show();
        }

        private void kitapRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapRpr kitRpr = new kitapRpr();
            kitRpr.MdiParent = this;

            kitRpr.WindowState = FormWindowState.Maximized;
            kitRpr.Show();
        }

        private void yayıneviRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yayinRpr yayinRpr = new yayinRpr();
            yayinRpr.MdiParent = this;

            yayinRpr.WindowState = FormWindowState.Maximized;
            yayinRpr.Show();
        }

        private void aktiÜyeRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            auyeRpr auyeRpr = new auyeRpr();
            auyeRpr.MdiParent = this;

            auyeRpr.WindowState = FormWindowState.Maximized;
            auyeRpr.Show();
        }

        private void pasifToolStripMenuItem_Click(object sender, EventArgs e)
        {
              puyeRpr puyeRpr = new puyeRpr();
            puyeRpr.MdiParent = this;

            puyeRpr.WindowState = FormWindowState.Maximized;
            puyeRpr.Show();
        }

        private void üyeListesiRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyeRpr uyeRpr = new uyeRpr();
            uyeRpr.MdiParent = this;

            uyeRpr.WindowState = FormWindowState.Maximized;
            uyeRpr.Show();
        }

        private void yazarRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yazarRpr yazarRpr = new yazarRpr();
            yazarRpr.MdiParent = this;

            yazarRpr.WindowState = FormWindowState.Maximized;
            yazarRpr.Show();
        }

        private void katagoriRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            katRpr katRpr = new katRpr();
            katRpr.MdiParent = this;

            katRpr.WindowState = FormWindowState.Maximized;
            katRpr.Show();
        }

        private void ödünçKitapİadeEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            odIade iade = new odIade();
            iade.MdiParent = this;
          iade.WindowState = FormWindowState.Maximized; 
            iade.Show();
        }

        private void iadeEdilmişKitaplarıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iadeEdilenKit iade = new iadeEdilenKit();
            iade.MdiParent = this;
            iade.WindowState = FormWindowState.Maximized;
            iade.Show();
        }
        }
    }
