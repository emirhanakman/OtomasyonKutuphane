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
using System.Runtime.InteropServices;
namespace OtomasyonKutuphane
{
    public partial class Form1 : Form
    {
        public static string isim;
        adminForm admin = new adminForm(); // admin arayüzü
        anaForm form = new anaForm(); // kullanıcı arayüzü
        public Form1()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
        int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture(); 
        SqlConnection baglanti = new SqlConnection("Data Source=ADMINISTRATOR;Initial Catalog=MTSK;User ID=sa;Password=1597531");   
          // ana bilgisayar ile bağlantı sağlandı.    
        private void Form1_Load(object sender, EventArgs e)
        {
           
            comboBox1.Items.Add("Yönetici");
            comboBox1.Items.Add("Kullanıcı");     
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit(); // uygulamayı kapat
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '*';
                checkBox1.Text = "Şifreyi Göster";
            }
                // Sifre gizleme kısmı
            else
            {
                textBox2.PasswordChar = '\0';
                checkBox1.Text = "Şifreyi Gizle";
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // none formu hareket ettirme kısmı
             {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            } 
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // formu minimize ayara alma
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            string kadi = textBox1.Text;
            string sifre = textBox2.Text;
            SqlCommand sorgu = new SqlCommand(); // giriş paneli sorgusu kullanıcı
            SqlCommand sorguYonetici = new SqlCommand(); // admin giriş sorgu                   
            try
            {
                if (comboBox1.Text == "Yönetici")
                {
                    sorgu.Connection = baglanti;  // sorgumuzu bağlantıyla eşitledik                            
                    sorgu.CommandText = "Select * from GIRIS where yetki='1' and kullanici='" + kadi + "' and sifre='" + sifre + "'";  // veritabanından kullanıcı adı ve şifreyi sorguluyoruz.
                    object sonuc = sorgu.ExecuteScalar(); // sorgudan yanıt geliyor mu ?      
                    SqlDataReader oku = sorgu.ExecuteReader();
                    if (sonuc == null)
                    {
                        MessageBox.Show("Kullanıcı Adınız veya Şifreniz Hatalı ! \n\n Yönetici Bölümünde Yetkiniz Yok ! ", "Hata ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Text = "";  // Eğer kullanıcı adı ve şifre doğru değilse, textboxları temizle.
                        textBox2.Text = "";
                    }
                    else
                    {
                        isim = kadi;
                        adminForm yoneticiArayuz = new adminForm();
                        this.Hide();
                        yoneticiArayuz.Show();
                        baglanti.Close();  // kullanıcı adı ve şifre doğruysa ve sayfaya yönlendirdiyse bağlantıyı kapat.*/
                    }
                }
                if (comboBox1.Text == "Kullanıcı")
                {
                   sorguYonetici.Connection = baglanti;  // sorgumuzu bağlantıyla eşitledik                            
                   sorguYonetici.CommandText = "Select * from personel where yetki='0' and perKadi='" + kadi + "' and perSifre='" + sifre + "'";  // veritabanından kullanıcı adı ve şifreyi sorguluyoruz.
                   object sonucYonetici = sorguYonetici.ExecuteScalar(); // admin yanıt geliyor mu ?
                   SqlDataReader okuYonetici = sorguYonetici.ExecuteReader();
                    if (sonucYonetici == null)
                    {
                        MessageBox.Show("Kullanıcı Adınız veya Şifreniz Hatalı ! \n\n Kullanıcı Yetkiniz Yok !", "Hata ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Text = "";  // Eğer kullanıcı adı ve şifre doğru değilse, textboxları temizle.
                        textBox2.Text = "";
                    }
                    else
                    {           
                        isim = kadi;
                        this.Hide(); // şifre ve kullanıcı adı doğruysa ana sayfaya yönlendir.     
                        form.Show();
                        baglanti.Close();  // kullanıcı adı ve şifre doğruysa ve sayfaya yönlendirdiyse bağlantıyı kapat.
                    }
                }
            }
            catch (Exception)
            {   
                throw;
            }       
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}