using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;
using DataAccsess.Concrete.InMemory;

ProductManager productManager = new ProductManager(new EfProductDal());

foreach (var product in productManager.GetAllByUnitPrice(50, 100))
{
    Console.WriteLine(product.ProductName);
}