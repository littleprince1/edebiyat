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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace Edebiyat.Bildiri_Pencereleri
{
    /// <summary>
    /// Interaction logic for My_NotifyIcon.xaml
    /// </summary>
    public partial class My_NotifyIcon : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
           //<DoubleAnimation Storyboard.TargetProperty="Height" From= "420" To= "30" RepeatBehavior= "1x" Duration= "0:0:0.5" />
           //< DoubleAnimation Storyboard.TargetProperty= "Opacity" From= "1" To= "0" RepeatBehavior= "1x" Duration= "0:0:0.5" />
        public My_NotifyIcon(string Text, int Time,bool Mode)
        {
            InitializeComponent();
            if (Time > 0  && !string.IsNullOrWhiteSpace(Text))
            {              
                if (Mode==true)
                    grn.Visibility = Visibility.Visible;
                tb.Text = Text;
                if (Siniflar.DataController.notifyIcon!=null)
                    Siniflar.DataController.notifyIcon.Close();
                Siniflar.DataController.notifyIcon = this;
                dispatcherTimer.Interval = TimeSpan.FromSeconds(Time);
                dispatcherTimer.Start();
                dispatcherTimer.Tick += DispatcherTimer_Tick;
                Rect ÇalışmaAlanı = SystemParameters.WorkArea;
                Top = ÇalışmaAlanı.Bottom - Height - 7;
                Left = ÇalışmaAlanı.Right - Width - 7;
                Topmost = true;
                Show();
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
