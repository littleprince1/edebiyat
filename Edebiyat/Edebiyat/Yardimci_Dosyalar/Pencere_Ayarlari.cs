using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Edebiyat.Yardimci_Dosyalar
{
    public static class Pencere_Ayarlari
    {
        public static Window Main_Window;
        public static Frame Main_Window_Frame;
        public static Label Main_Window_Title;
        public static Image Main_Window_Logo;
        public static void Size_adjustment(Window window)
        {
            if (App.Screen_Height < 600 || App.Screen_Width < 800)
            {
                MessageBox.Show("Git Monitör Ekran kartı fln bişeyler al pis fakir");
                Application.Current.Shutdown();
            }
            else
            {
                window.Width = App.Screen_Width - 133;
                window.Height = App.Screen_Height - 100;
                CenterWindowOnScreen(window);
            }
        }
        public static void CenterWindowOnScreen(Window window)
        {
            window.Left = (App.Screen_Width / 2) - (window.Width / 2);
            window.Top = (App.Screen_Height / 2) - (window.Height / 2);
        }
        public static void Window_Maximized(Window window)
        {
            if (window.WindowState == WindowState.Maximized)
                Window_Normal(window);
            else
                window.WindowState = WindowState.Maximized;
        }
        public static void Window_Minimized(Window window) => window.WindowState = WindowState.Minimized;
        public static void Window_DragMove(Window window) => window.DragMove();
        public static void Window_Closed(Window window) => window.Close();
        public static void Window_Normal(Window window)
        {
            window.WindowState = WindowState.Normal;
            Size_adjustment(window);
        }
        public static void Frame_Page_adjustment(string Page_Name) => Main_Window_Frame.Source = new Uri($"/Edebiyat;component/Sayfalar/{Page_Name}.xaml", UriKind.RelativeOrAbsolute);
    }
}
