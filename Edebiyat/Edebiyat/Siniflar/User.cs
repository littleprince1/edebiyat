using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Edebiyat.Siniflar
{  [Table("UserTable")]
  public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        public string eMail { get; set; }
        public byte[] ImageArray { get; set; }

        [NotMapped]
        public BitmapSource Image
        {
            get
            {
                BitmapSource resim = null;
                if (ImageArray != null && ImageArray.Length > 0)
                {
                    using (var stream = new MemoryStream(ImageArray))
                    {
                        var codeDecoder = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        resim = codeDecoder.Frames[0];
                    }
                }
                return resim;
            }
            set
            {
                byte[] byteArray;
                if (value == null)
                {
                    byteArray = new byte[0];
                }
                else
                {
                    using (var stream = new MemoryStream())
                    {
                        var coder = new PngBitmapEncoder();
                        coder.Frames.Add(BitmapFrame.Create(value));
                        coder.Save(stream);
                        byteArray = stream.ToArray();
                    }
                }
                ImageArray = byteArray;
            }
        }


    }
}
