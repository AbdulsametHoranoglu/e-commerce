using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Abstract;
//crud operasyonları(Sil ekle vb.)
public interface IProductDal: IEntityRepository<Product>
{


}