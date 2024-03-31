using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccsess.EntityFramework;

public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    public void Add(TEntity entity)
    {
        //biz bir clasıı new lediğimizde gorbeccollector belli bir zamanda gelir onu atar
        //ama using içinde yazdığımız nesneler  using bitince hemen gorbeccollector a geliyor ve atıyor 
        using (TContext context = new TContext())
        {
            var addedEntity = context.Entry(entity);//git veri kaynağından benim gönderdiğim producta bir tane nesneyi eşleştir(ama bu ekleme olacağı için herhangi birşeyle eşleştirmeyecek onun yerine direk ekliyecek)
            addedEntity.State = EntityState.Added;//önceki kod eşleştirdim demek ama bunu ne yapayım diyor ekle diyoruz added ekle demek
            context.SaveChanges();//yakaladığın referansı ekle dedik
        }
    }

    public void Delete(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
    // bir tane ürün getirecekti
    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using (TContext context = new TContext())
        {
            return context.Set<TEntity>().SingleOrDefault(filter);
        }
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
    {
        using (TContext context = new TContext())
        {
            return filter == null //filtre null mı 
                ? context.Set<TEntity>().ToList() //evet(yani filtre null) ise tümünü getir 
                : context.Set<TEntity>().Where(filter).ToList();//değilse filtrelediğimi getir
        }
    }

    public void Update(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var updateddEntity = context.Entry(entity);
            updateddEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
