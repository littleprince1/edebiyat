using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Edebiyat.Sayfalar
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
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
            return TB_Control(tbxUsername) && TB_Control(tbxPassword);
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Kontrol())
            {
                
                Siniflar.User user = Siniflar.DataController.Db.Users.Where(x => x.userName == tbxUsername.tb.Text && x.Password == tbxPassword.pb.Password).FirstOrDefault();
                if (user != null)
                {
                    Siniflar.DataController.CurrentUser = user;
                    MySettings.Default.Is_there = true;
                    MySettings.Default.User_id = user.Id;
                    MySettings.Default.Save();
                    NavigationService.Navigate(new MainPage());
                }
                else
                {
                    Bildiri_Pencereleri.Mesaj_Kutusu mesaj_Kutusu = new Bildiri_Pencereleri.Mesaj_Kutusu("Böyle bir kullanıcı bulunmamaktadır. Lütfen tekrar deneyiniz.", "UYARI", "", "Tamam");
                }
            }
            else
            {
                Bildiri_Pencereleri.My_NotifyIcon my_NotifyIcon = new Bildiri_Pencereleri.My_NotifyIcon("Lütfen tüm alanları doldurunuz.", 6, false);
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }
    }
}
