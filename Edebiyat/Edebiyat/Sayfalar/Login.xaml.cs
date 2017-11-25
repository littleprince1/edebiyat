using Edebiyat.Siniflar;
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

namespace Edebiyat.Sayfalar
{
    /// <summary>
    /// Login.xaml etkileşim mantığı
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            User bulunanKullanıcı = DataController.Db.Users.Local.Where(i=>i.userName==tbxUsername.tb.Text && i.Password==tbxPassword.tb.Text).FirstOrDefault();
            if (bulunanKullanıcı!=null)
            {

            }
        }
    }
}
