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
    /// Interaction logic for CustomPasswordBox.xaml
    /// </summary>
    public partial class CustomPasswordBox : UserControl
    {
        public CustomPasswordBox()
        {
            InitializeComponent();
            pb.Password = Tip;
            pb.Foreground = Methods.Hex_to_Brush("#2f2c38");
        }


        private string toolTip;

        public string C_ToolTip
        {
            get { return toolTip; }
            set { toolTip = value; Methods.ToolTip(toolTip.ToString(),pb); }
        }

        private string tip;

        public string Tip
        {
            get { return tip; }
            set { tip = value; pb.Password = tip; }
        }

        private void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pb.Password.Length == 0)
            {
                pb.Password = Tip;
                pb.Foreground = Methods.Hex_to_Brush("#2f2c38");
            }
        }

        private void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (pb.Password == Tip)
            {
                pb.Clear();
                pb.Foreground = Methods.Hex_to_Brush("#e0f8f4");
            }
        }
    }
}
