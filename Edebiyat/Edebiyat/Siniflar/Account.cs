using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edebiyat.Siniflar
{           [Table("AccountTable")]
   public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [ForeignKey(nameof(user))]
        public int userId { get; set; }
        public User user { get; set; }


    }
}
