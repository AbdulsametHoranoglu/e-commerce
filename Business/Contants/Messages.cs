using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants;

//temel mesajlarımızı buraya yazıyoruz
//static dedik çünkü burayı sürekli newlemeyelim diye onun yerine messages. deriz
public static class Messages
{
    public static string ProductAdded = "ürün eklendi";
    public static string ProductNameInvalid = " Ürün ismi geçersiz";
    public static string MaintenanceTime = "Sistem bakımda";
    public static string ProductListed = "Ürünler listelendi";
}
