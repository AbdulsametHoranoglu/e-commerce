using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using DataAccsess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    //dependency injection
    IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
        //.validation - Doğrulama mesela diyor ki kullanıcı adı 2 karakterden az olamaz şifre şöyle olamaz falan 
        //businnes(iş) kodları yazılır

        //Commentlediğim ifleri FluentValidationda kodladım burda artık ihtiyacım yok

        //if (product.UnitPrice <= 0 )
        //{
        //    return new ErrorResult(Messages.UnitPriceInvalid);
        //}

        //if (product.ProductName.Length < 2)
        //{
        //    //magic strings leri değiştirmek için businnes ta bie klasör açtık contanst(sabit) yani northwinde ki sabitleri buraya yazarız
        //    return new ErrorResult(Messages.ProductNameInvalid);//Businnes.contanst deki nesneyi kullandık
        //}


        //şimdi validationu çalıştıralım 
        // bu altaki kötü kod onu bir tool haline getirelim 

        //var context = new ValidationContext<Product>(product);
        //ProductValidator productValidator = new ProductValidator();

        //var result = productValidator.Validate(context);
        //if (!result.IsValid)
        //{
        //    throw new ValidationException(result.Errors);
        //}

        //ValidationTool.Validate(new ProductValidator(), product);// clasın üstüne [ValidationAspect(typeof(ProductValidator))] eklediğimiz için buna gerek yok 

        _productDal.Add(product);

        return new SuccsessResult(Messages.ProductAdded);//Businnes.contanst deki nesneyi kullandık
    }

    public IDataResult<List<Product>> GetAll()
    {
        if (DateTime.Now.Hour == 01)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<Product>>( _productDal.GetAll(), Messages.ProductListed);
    }

    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
        return new SuccessDataResult<List<Product>>( _productDal.GetAll(p=>p.CategoryId == id));
    }

    public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
    }

    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product> (_productDal.Get(p=>p.ProductId == productId));
    }

    public IDataResult<List<ProductDetailDto>>  GetProductDetails()
    {
        return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails());
    }

}
