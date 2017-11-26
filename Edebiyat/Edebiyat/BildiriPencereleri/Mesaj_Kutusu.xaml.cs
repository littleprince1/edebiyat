using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace Edebiyat.Bildiri_Pencereleri
{
    /// <summary>
    /// Interaction logic for Mesaj_Kutusu.xaml
    /// </summary>
    public partial class Mesaj_Kutusu : Window
    {

        public bool Sonuç = false;
        public Mesaj_Kutusu(string İçerik)
        {
            InitializeComponent();
            İçerikBölümü.Text = İçerik;
            SystemSounds.Asterisk.Play();
            ShowDialog();
        }
        public Mesaj_Kutusu(string İçerik, string Başlık)
        {
            InitializeComponent();
            İçerikBölümü.Text = İçerik;
            BaşlıkBölümü.Text = Başlık;
            SystemSounds.Asterisk.Play();
            ShowDialog();

        }
        public Mesaj_Kutusu(string İçerik, string Başlık, string SoldakiTus, string SağdakiTus)
        {
            InitializeComponent();
            İçerikBölümü.Text = İçerik;
            BaşlıkBölümü.Text = Başlık;
            Soldaki.Content = SoldakiTus;
            Sağdaki.Content = SağdakiTus;
            if (SoldakiTus.Length == 0)
                Soldaki.Visibility = Visibility.Collapsed;
            if (SağdakiTus.Length == 0)
                Sağdaki.Visibility = Visibility.Collapsed;
            if (!string.IsNullOrWhiteSpace(Soldaki.Content.ToString()) || !string.IsNullOrWhiteSpace(Sağdaki.Content.ToString()))
            {
                SystemSounds.Asterisk.Play();
                ShowDialog();
            }
        }

        private void Soldaki_Click(object sender, RoutedEventArgs e)
        {
            Sonuç = true;
            Close();
        }
        private void Sağdaki_Click(object sender, RoutedEventArgs e)
        {
            Sonuç = false;
            Close();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                Yardimci_Dosyalar.Pencere_Ayarlari.Window_DragMove(this);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Sonuç = true;
                Close();
            }
        }
    }
}
