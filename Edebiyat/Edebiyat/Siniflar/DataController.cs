using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edebiyat.Siniflar
{
    public static class DataController
    {
        static DataController()
        {
            Db.Accounts.Load();
            Db.Users.Load();
        }
        public static void Kullanici_Kontrol()
        {
            if (MySettings.Default.Is_there)
                CurrentUser = Db.Users.Where(x=>x.Id==MySettings.Default.User_id).FirstOrDefault();
        }
        public static User CurrentUser { get; set; }
        public static DbModel Db = new DbModel();
        public static Bildiri_Pencereleri.My_NotifyIcon notifyIcon;
    }
}
