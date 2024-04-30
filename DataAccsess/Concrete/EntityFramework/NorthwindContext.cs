using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete.EntityFramework;
// Context : Db tabloları ile proje classlarını bağlamak
public class NorthwindContext : DbContext
{

    //bu metot senin projen hangi veri tabanı ile ilişkiyi belirteceğimiz yer
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //burda hangi veri tabanına bağlanacağımızı söyledik
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=master;Trusted_Connection=true");
    }


    //sistemimizde ki hangi nesnem ver itabanında ki hangi tabloya karşılık gelecek 
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


    //Enson orderi ekledik ve hoca ara verdi bende uyumaya gittim yarın allahın izni ile dewam ederiz


}
