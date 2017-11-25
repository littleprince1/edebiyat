using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Edebiyat.Yardimci_Dosyalar
{
   public static class Methods
    {
        #region Değişkenler
        static string Kodtutucu = "AB0CD1E9F6GHI2JKL7MNO3PRSUV4YZX5W8Q";
        static string Karakterler = "A0BC1DE2FGH8I3JK7LMNO4PRST5U9VY6Z";
        static string Sayılar = "0123456789";
        static string Güvenlik_Kodu = "";
        static Random rnd = new Random();
        static string Kod;
        static string Eposta;
        static MailMessage msj = new MailMessage();
        static SmtpClient client = new SmtpClient();
        #endregion


        public static bool EmailKontrol(string EpostaAdres)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            return (new Regex(strRegex)).IsMatch(EpostaAdres);
        }


        public static void ResimSeçim(Image Img)
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
                Img.Source = new BitmapImage(new Uri(a.FileName, UriKind.RelativeOrAbsolute));
            }
        }
        public static void ResimSeçim(Image Img, Label Lb)
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
                Img.Source = new BitmapImage(new Uri(a.FileName, UriKind.RelativeOrAbsolute));
                Lb.Visibility = Visibility.Collapsed;
            }
        }
        public static void SadeceYazıGirme(TextCompositionEventArgs e)
        {
            if (!Sayılar.Contains(e.Text))
            {
                e.Handled = true;
            }
        }

        public static void BoşlukKontrol(TextCompositionEventArgs e)
        {
            if (" ".Contains(e.Text))
            {
                e.Handled = true;
            }
        }
        public static void SadeceSayıGirme(TextCompositionEventArgs e)
        {
            if (Sayılar.Contains(e.Text))
            {
                e.Handled = true;
            }
        }
        public static void ToolTip(string içerik, Control Cntr)
        {
            ToolTip Toooool = new ToolTip { Content = içerik, Style = (Style)Application.Current.FindResource("ToolTipim") };
            Cntr.ToolTip = Toooool;
        }
        public static void SesÇal(string wav_Dosyasınınİsmi)
        {
           
            {
                if (File.Exists($"Sesler/{wav_Dosyasınınİsmi}"))
                {
                    SoundPlayer aa = new SoundPlayer($"Sesler/{wav_Dosyasınınİsmi}");
                    aa.Play();
                }
                // Örneyin  ===>  Metodlar.SesÇal("HeytBe.wav");
            }
        }
        public static void GirileniBüyüt(TextCompositionEventArgs e, TextBox Tb)
        {
            if (e.Text == e.Text.ToLower())
            {
                char a = char.Parse(e.Text.ToUpper());
                e.Handled = true;
                Tb.Text += a;
                int ındex = Tb.Text.Length + 1;
                Tb.CaretIndex = ındex;
            }
        }
        public static bool InternetKontrol()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.google.com/");
                request.Timeout = 20000;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK) return true;
                else
                {
                    //a = new BildiriPenceresi(false, 3, "Lütfen İnternet Bağlantınızı Kontrol Ediniz");
                    return false;
                }

            }
            catch
            {
                //a = new BildiriPenceresi(false, 3, "Lütfen İnternet Bağlantınızı Kontrol Ediniz");
                return false;
            }
        }
        static void Epostacı(string Eposta, string Gönderilecek)
        {
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            msj.Subject = "Güvenlik Doğrulaması";
            msj.Body = Kod;
            client.Credentials = new NetworkCredential(Eposta, "Profilo1989");
            msj.To.Add("");
            msj.From = new MailAddress(Eposta, "Bilgi Oyunu Doğrulama Servisi");
            client.Send(msj);
         
        }
        public static string MailGönder(string EpostaAdres)
        {
            Kod = "";
            int ındex;
            Random Rnd = new Random();
            for (int i = 1; i <= 5; i++)
            {
                ındex = Rnd.Next(0, Kodtutucu.Length);
                Kod += Kodtutucu[ındex];
            }
            try
            {
                Eposta = "profilo.bilgioyunu@gmail.com";
                Epostacı(Eposta, EpostaAdres);
                return Kod;
            }
            catch
            {
                try
                {
                    Eposta = "profilo.bilgioyunu1@gmail.com";
                    Epostacı(Eposta, EpostaAdres);
                    return Kod;
                }
                catch
                {
                    //a = new BildiriPenceresi(false, 5, "Mesajınız İletilemedi");
                    return "0";
                }
            }
        }

    }
}
