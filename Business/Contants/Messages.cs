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
    public static string ProductCountOfCategoryError = "Bir kategoryde en fazla 10 ürün olabilir";
    public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
    internal static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
}
