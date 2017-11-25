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

namespace Edebiyat.U_Kontroller
{
    /// <summary>
    /// Interaction logic for CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl
    {
        public CustomTextBox()
        {
            InitializeComponent();
            tb.Text = Tip;
            tb.Foreground = Brushes.Gray;
        }
        private string tip;

        public string Tip
        {
            get { return tip; }
            set { tip = value; tb.Text = tip; }
        }


        private void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb.Text==Tip)
            {
                tb.Clear();
                var bc = new BrushConverter();
                tb.Foreground = (Brush)bc.ConvertFrom("#e0f8f4"); ;
            }
        }

        private void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length==0)
            {
                tb.Text = Tip;
                tb.Foreground = Brushes.Gray;
            }
        }
    }
}
