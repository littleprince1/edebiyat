using Edebiyat.Yardimci_Dosyalar;
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
    /// CustomTextBox.xaml etkileşim mantığı
    /// </summary>
    public partial class CustomTextBox : UserControl
    {
        public CustomTextBox()
        {
            InitializeComponent();
            tb.Text = Tip;
            var bc = new BrushConverter();
            tb.Foreground = (Brush)bc.ConvertFrom("#2f2c38"); ;
        }

        private string toolTip;

        public string C_ToolTip
        {
            get { return toolTip; }
            set { toolTip = value; if (!string.IsNullOrWhiteSpace(toolTip)) Methods.ToolTip(toolTip, tb); }
        }

        private string tip;

        public string Tip
        {
            get { return tip; }
            set { tip = value; tb.Text = tip; }
        }

        public TextBox TextBox
        {
            get { return tb;}

        }


        private void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb.Text == Tip)
            {
                tb.Clear();
                var bc = new BrushConverter();
                tb.Foreground = (Brush)bc.ConvertFrom("#e0f8f4"); ;
            }
        }

        private void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0)
            {
                tb.Text = Tip;
                var bc = new BrushConverter();
                tb.Foreground = (Brush)bc.ConvertFrom("#2f2c38"); ;
            }
            else
            {
                tb.CaretIndex = 0;
            }
        }

        private void tb_LostFocus_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
