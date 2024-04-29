using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;
using DataAccsess.Concrete.InMemory;

ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

var result = productManager.GetProductDetails();

if (result.Success)
{
    foreach (var product in result.Data)
    {
        Console.WriteLine(product.ProductName + "/" + product.CategoryName);
    }
}
else
{
    Console.WriteLine(result.Message);
}




//IoC ile burayı da newlemeyecez

//CategoryManager();

static void CategoryManager()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

    foreach (var category in categoryManager.GetAll().Data)
    {
        Console.WriteLine(category.CategoryName);
    }

    foreach (var category1 in categoryManager.GetAll().Data)
    {
        Console.WriteLine(category1.CategoryName);
    }
}


//DTO ne demek = bir Eticaret sistemine girince bir ürün listesinde aslında ilişkesel dataları da görüyoruz(ürünün ismide yazıyor yanında kategory ismide yazıyor)