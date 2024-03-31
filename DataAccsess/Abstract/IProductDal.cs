using Core.DataAccsess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Abstract;
//crud operasyonları(Sil ekle vb.)
public interface IProductDal: IEntityRepository<Product>
{
    List<ProductDetailDto> GetProductDetails();

}