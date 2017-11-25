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
            tbxEmail.tb.TextChanged += Tb_TextChanged;
     
        }

        private void Tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Methods.EmailKontrol(tbxEmail.TextBox.Text))
            {
                btnRegister.IsEnabled = true;
            } 
            else
            {
                btnRegister.IsEnabled = false;
            }

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog()
            {
                Title = "Resim  Seç",
                Multiselect = false,
                Filter = "Resim Dosyaları| *.jpg;*.png;*.pns;*.bmp;*.ico;*.jpeg;*.bmp;|Tüm Dosyalar|*.*;",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                RestoreDirectory = true,
            };
            if (a.ShowDialog() == true)
            {
                userImg.Source = new BitmapImage(new Uri(a.FileName, UriKind.RelativeOrAbsolute));
                imgTip.Visibility = Visibility.Hidden;
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = tbxUsername.Content.ToString();
            string password = tbxPassword.Content.ToString();
            string email = tbxEmail.Content.ToString();
            if (!string.IsNullOrWhiteSpace(username) || !string.IsNullOrWhiteSpace(password) || !string.IsNullOrWhiteSpace(email))
            {
                User yUser = new User();
                yUser.userName = username;
                yUser.Password = password;
                yUser.eMail = email;
                yUser.Image = userImg.Source as BitmapSource;     
                DataController.Db.Users.Add(yUser);
                DataController.Db.SaveChanges();
                NavigationService.Refresh();
               
              
            }

        }

     
    }
}
