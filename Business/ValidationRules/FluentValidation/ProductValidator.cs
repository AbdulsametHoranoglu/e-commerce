using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    //hangi nesme için validator yazılacaksa cunstructor içine yazılır
    public ProductValidator()
    {
        //kim için kural,veriğimiz nesne için kural
        RuleFor(p => p.ProductName).MinimumLength(2);//Product name 2 karakterden büyük olmalıdır
        RuleFor(p => p.ProductName).NotEmpty();//product name boş olamaz
        RuleFor(p => p.UnitPrice).NotEmpty();//unit price boş olamaz
        RuleFor(p => p.UnitPrice).GreaterThan(0);// unit price 0 dan büyük olmalı
        RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1)/*.WithMessage("")*/; //bu kategorideki ürünlerin fiyatı 10 dan büyük olmak zorunda
        //fluent te olmayan bir kural ekleyelim mesela ürün isimlerm a ile başlamalı
        //RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı"); //StartWithA bu benim metodum aşağıda kodladım

    }

    private bool StartWithA(string arg)//arg product nameye karşılık gelir
    {
        return arg.StartsWith("A");
    }
}
