using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//namespace-(İsimUzayı) = classları, interfaceleribelli bir isim uzayının içine bırakıyoruz ki onlara rahat ulaşabilelim
//namespace DataAccsess.Abstract;
namespace Core.DataAccsess;

//generic constraint = where T : class(İnerface) =mesela IcategoryDal la  IEntityRepository<Category> yi implemen edince sacede category yazılsın yanlışlıkla
//string int vb yazılmasın diye ve başka classlar yazılmasın diye de IEntity  koşulunu koyduk,new()diyince(Sadece newlenebilir şeyler) de IEntity interfacesini yazamıyoruz sadece (Product Customer Category)
public interface IEntityRepository<T> where T : class , IEntity, new()
{
    //Expression<Func<T,bool>> ürünleri neye göre filtreleyip getireceğimizi söyler (Mesela getAll da LİNQ kullanabilmek için)
    //filter = null da filtre yoksa hepsini getir demek
    List<T> GetAll(Expression<Func<T,bool>> filter = null);
    T Get(Expression<Func<T, bool>> filter);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    //ürünleri kategory ye göre filtrele
}
