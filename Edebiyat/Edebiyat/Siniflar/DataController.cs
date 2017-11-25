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
        public static User CurrentUser { get; set; }
        public static DbModel Db = new DbModel();
    }
}
