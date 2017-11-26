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
using System.Windows.Shapes;
namespace Edebiyat.Pencereler
{
    /// <summary>
    /// Interaction logic for AnaPencere.xaml
    /// </summary>
    public partial class AnaPencere : Window
    {
        public AnaPencere()
        {
            InitializeComponent();
            Yardimci_Dosyalar.Pencere_Ayarlari.Main_Window = this;
            Yardimci_Dosyalar.Pencere_Ayarlari.Main_Window_Frame = SayfaYoneticisi;
            Yardimci_Dosyalar.Pencere_Ayarlari.Main_Window_Logo = Logo;
            Yardimci_Dosyalar.Pencere_Ayarlari.Main_Window_Title = W_Title;
            Yardimci_Dosyalar.Pencere_Ayarlari.Size_adjustment(this);
            Loaded += AnaPencere_Loaded;
            
        }

        private void AnaPencere_Loaded(object sender, RoutedEventArgs e)
        {
            Bildiri_Pencereleri.My_NotifyIcon my_NotifyIcon = new Bildiri_Pencereleri.My_NotifyIcon("My_NotifyIcon", 4, true);
        }

        private void DragMove_Event(object sender, MouseButtonEventArgs e) { if (e.LeftButton == MouseButtonState.Pressed) Yardimci_Dosyalar.Pencere_Ayarlari.Window_DragMove(this); }

        private void Window_Minimized(object sender, RoutedEventArgs e) => Yardimci_Dosyalar.Pencere_Ayarlari.Window_Minimized(this);

        private void Window_Maximized(object sender, RoutedEventArgs e) => Yardimci_Dosyalar.Pencere_Ayarlari.Window_Maximized(this);

        private void Window_Closed(object sender, RoutedEventArgs e) => Yardimci_Dosyalar.Pencere_Ayarlari.Window_Closed(this);
    }
}
