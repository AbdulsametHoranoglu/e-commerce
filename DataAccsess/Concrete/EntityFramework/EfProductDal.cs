using Core.DataAccsess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
//burda neden IProductDal ı kullandık dersek çünkü product için başka metotlar da yazabiliriz mesela dto 
{
    public List<ProductDetailDto> GetProductDetails()
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            var result = from p in context.Products
                         join c in context.Categories
                         on p.CategoryId equals c.CategoryId
                         select new ProductDetailDto
                         {
                             ProductId = p.ProductId,
                             ProductName = p.ProductName,
                             CategoryName = c.CategoryName,
                             UnitsInStock = p.UnitsInStock
                         };

            return result.ToList();
        }
    }
}
