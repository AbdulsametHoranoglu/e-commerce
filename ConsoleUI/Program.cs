using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;
using DataAccsess.Concrete.InMemory;

ProductManager productManager = new ProductManager(new EfProductDal());

foreach (var product in productManager.GetProductDetails())
{
    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
}


//IoC ile burayı da newlemeyecez
/*
CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

foreach (var category in categoryManager.GetAll())
{
    Console.WriteLine(category.CategoryName);
}
*/

//DTO ne demek = bir Eticaret sistemine girince bir ürün listesinde aslında ilişkesel dataları da görüyoruz(ürünün ismide yazıyor yanında kategory ismide yazıyor)