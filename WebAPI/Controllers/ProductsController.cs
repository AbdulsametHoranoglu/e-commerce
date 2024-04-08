using Business.Abstract;
using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //loosely coupled - gevşek bağımlılık

        //IoC Container - Inversion of control - değişimin kontrolu = bellekteki bir yer gibi düsün yani bir liste gibi, bu listenin içerisine ben bir tane
        //new productManager, new EfProductdal referanslar koyalım sonra kim ihtiyaç duyuyorsa kullansın diyoruz 
        //mesela diyoruz ki  ProductsController senin bir  IProductService e ihtiyacın var ben senin için bellekte bir tane new ledim sana onu veriyorum
        //dolayısıyla asp.net wepAPI bizim yerimize aa productservice mi dur bi gideyim IoC na bakayım ona karşılık gelen birşey var mı diye bakıyor ve kullanıyor
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Dependency chain - Bağımlılık zinciri
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);//200 ve (result.data) yazarsak datanın kendisini
            }
            return BadRequest(result); //400 ve result.message yazarsak mesajın kendisini
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //post işlemi gerçekleştirelim (yani bir data ekliyelim)
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
