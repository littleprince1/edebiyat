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

namespace Edebiyat.Bildiri_Pencereleri
{
    /// <summary>
    /// Interaction logic for My_NotifyIcon.xaml
    /// </summary>
    public partial class My_NotifyIcon : Window
    {
        public My_NotifyIcon()
        {
            InitializeComponent();
            Rect ÇalışmaAlanı = SystemParameters.WorkArea;
            Top = ÇalışmaAlanı.Bottom - Height;
            Left = ÇalışmaAlanı.Right - Width;
            Topmost = true;
           
        }

       
    }
}
