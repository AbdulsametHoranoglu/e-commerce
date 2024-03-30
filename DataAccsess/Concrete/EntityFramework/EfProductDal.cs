using DataAccsess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete.EntityFramework;

public class EfProductDal : IProductDal
{
    public void Add(Product entity)
    {
        //biz bir clasıı new lediğimizde gorbeccollector belli bir zamanda gelir onu atar
        //ama using içinde yazdığımız nesneler  using bitince hemen gorbeccollector a geliyor ve atıyor 
        using (NorthwindContext context = new NorthwindContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(Product entity)
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
    // bir tane ürün getirecekti
    public Product Get(Expression<Func<Product, bool>> filter)
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            return context.Set<Product>().SingleOrDefault(filter);
        }
    }

    public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            return filter == null //filtre null mı 
                ? context.Set<Product>().ToList() //evet(yani filtre null) ise tümünü getir 
                : context.Set<Product>().Where(filter).ToList();//değilse filtrelediğimi getir
        }
    }

    public void Update(Product entity)
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            var updateddEntity = context.Entry(entity);
            updateddEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
