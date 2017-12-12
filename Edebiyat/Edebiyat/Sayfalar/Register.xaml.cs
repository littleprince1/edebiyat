using Edebiyat.Siniflar;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Edebiyat.Yardimci_Dosyalar;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Edebiyat.Sayfalar
{
    /// <summary>
    /// Register.xaml etkileşim mantığı
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();

        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog()
            {
                Title = "Resim  Seç",
                Multiselect = false,
                Filter = "Resim Dosyaları| *.jpg;*.png;*.pns;*.bmp;*.ico;*.jpeg;*.bmp;",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                RestoreDirectory = true,
            };
            if (a.ShowDialog() == true)
            {
                userImg.Source = new BitmapImage(new Uri(a.FileName, UriKind.RelativeOrAbsolute));
                imgTip.Visibility = Visibility.Hidden;
            }
        }
        public bool TB_Control(U_Kontroller.CustomTextBox customTextBox)
        {
            bool kontrol = false;
            if (customTextBox.tb.Text != customTextBox.Tip)
                if (!string.IsNullOrWhiteSpace(customTextBox.tb.Text))
                    kontrol = true;
            return kontrol;
        }
        public bool TB_Control(U_Kontroller.CustomPasswordBox customTextBox)
        {
            bool kontrol = false;
            if (customTextBox.pb.Password != customTextBox.Tip)
                if (!string.IsNullOrWhiteSpace(customTextBox.pb.Password))
                    kontrol = true;
            return kontrol;
        }
        public bool Kontrol()
        {
            bool kontrol = false;
            bool img = userImg.Source != null;
            bool email = TB_Control(tbxEmail);
            bool pass = TB_Control(tbxPassword);
            bool username = TB_Control(tbxUsername);
            if (img == true && email == true && pass == true && username == true)
                kontrol = true;
            return kontrol;
        }
        string hata_mesaj = "";
        int Hata_sayac = 0;
        public bool Kullanici_Varmi()
        {
            bool kontrol = false;
            bool B_user = true, B_email = true;
            User user_username = DataController.Db.Users.Where(x => x.userName == tbxUsername.tb.Text).FirstOrDefault();
            if (user_username != null)
            {
                B_user = false;
                hata_mesaj += "*Bu Kullanıcı adına sahip bir kullanıcı bulunmaktadır.\n";
                Hata_sayac++;
            }

            User user_email = DataController.Db.Users.Where(x => x.eMail == tbxEmail.tb.Text).FirstOrDefault();
            if (user_email != null)
            {
                B_email = false;
                hata_mesaj += "*Bu E-Mail'e sahip bir kullanıcı bulunmaktadır.\n";
                Hata_sayac++;
            }
            if (B_user && B_email)
                kontrol = true;
            return kontrol;
        }
        public bool Password_Kontrol()
        {
            bool B_paswoard = true;
            bool BüyükHarfOlma = false, SayıOlma = false;
            foreach (char gelen in tbxPassword.pb.Password)
            {
                if (!Methods.Sayılar.Contains(gelen))
                    if (gelen.ToString() == gelen.ToString().ToUpper())
                        BüyükHarfOlma = true;
                if (Methods.Sayılar.Contains(gelen))
                    SayıOlma = true;
            }
            if (tbxPassword.pb.Password.Length < 8)
            {
                B_paswoard = false;
                hata_mesaj += "*Şifreniz en az 8 karakterden oluşmalıdır\n";
                Hata_sayac++;
            }
            if (BüyükHarfOlma == false)
            {
                B_paswoard = false;
                hata_mesaj += "*Şifrenizde en az 1 Büyük karakter bulunması gerekmektedir.\n";
                Hata_sayac++;
            }
            if (SayıOlma == false)
            {
                B_paswoard = false;
                hata_mesaj += "*Şifrenizde en az 1 rakam bulunması gerekmektedir.\n";
                Hata_sayac++;
            }

            return B_paswoard;
        }
        public bool Email_Kontrol()
        {
            bool kontrol = false;
            kontrol = Methods.EmailKontrol(tbxEmail.tb.Text);
            if (!kontrol)
            {
                hata_mesaj += "*E-Mail adresiniz doğru formatta değil.\n";
                Hata_sayac++;
            }
            return kontrol;
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            hata_mesaj = "";
            Hata_sayac = 0;
            if (Kontrol())
            {
                bool B_Kullanici_Varmi = Kullanici_Varmi();
                bool B_Password_Kontrol = Password_Kontrol();
                bool B_Email_Kontrol = Email_Kontrol();
                if (B_Email_Kontrol && B_Kullanici_Varmi && B_Password_Kontrol)
                {

                    User yUser = new User();
                    yUser.userName = Yardimci_Dosyalar.Şifreleme.Şifrele.TextSifrele(tbxUsername.tb.Text);
                    yUser.Password = Yardimci_Dosyalar.Şifreleme.Şifrele.TextSifrele(tbxPassword.pb.Password);
                    yUser.eMail = Yardimci_Dosyalar.Şifreleme.Şifrele.TextSifrele(tbxEmail.tb.Text);
                    yUser.Image = userImg.Source as BitmapSource;
                    DataController.Db.Users.Add(yUser);
                    DataController.Db.SaveChanges();
                    NavigationService.Refresh();
                    Bildiri_Pencereleri.Mesaj_Kutusu mesaj_Kutusu = new Bildiri_Pencereleri.Mesaj_Kutusu("Kullanıcı Başarı ile Kayıt Edildi.","","","Tamam");
                }
                else
                {
                    Bildiri_Pencereleri.Mesaj_Kutusu mesaj_Kutusu = new Bildiri_Pencereleri.Mesaj_Kutusu(hata_mesaj, $"{Hata_sayac} adet hata vardır.", "", "Tamam");
                }
            }
            else
            {
                Bildiri_Pencereleri.Mesaj_Kutusu mesaj_Kutusu = new Bildiri_Pencereleri.Mesaj_Kutusu("Lütfen tüm bilgileri eksiksiz doldurunuz", "", "", "Tamam");
            }
        }
    }
}
