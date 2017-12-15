using Edebiyat.Sayfalar;
using Edebiyat.Siniflar;
using System.Windows;
using System.Windows.Input;
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
            DataController.Kullanici_Kontrol();
            if (DataController.CurrentUser==null)
                SayfaYoneticisi.Navigate(new Login());
            else
                SayfaYoneticisi.Navigate(new MainPage());
        }

        private void DragMove_Event(object sender, MouseButtonEventArgs e) { if (e.LeftButton == MouseButtonState.Pressed) Yardimci_Dosyalar.Pencere_Ayarlari.Window_DragMove(this); }

        private void Window_Minimized(object sender, RoutedEventArgs e) => Yardimci_Dosyalar.Pencere_Ayarlari.Window_Minimized(this);

        private void Window_Maximized(object sender, RoutedEventArgs e) => Yardimci_Dosyalar.Pencere_Ayarlari.Window_Maximized(this);

        private void Window_Closed(object sender, RoutedEventArgs e)
        {
            Bildiri_Pencereleri.Mesaj_Kutusu mesaj_Kutusu = new Bildiri_Pencereleri.Mesaj_Kutusu("Uygulamadan Çıkmak istediğinize emin misiniz?","Bildiri","Evet","Hayır");
            if (mesaj_Kutusu.Sonuç==true)
                Application.Current.Shutdown();
        }
    }
}
