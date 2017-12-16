using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Edebiyat.Sayfalar
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        bool durum=true;
        private void Btn_Oyna_Click(object sender, RoutedEventArgs e)
        {
            if (durum==true)
            {
                col.Width = new GridLength(0);
                durum = false;
            }
            else
            {
                col.Width = new GridLength(30,GridUnitType.Star);
                durum = true;
            }
        }
    }
}
