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

    
    }
}
