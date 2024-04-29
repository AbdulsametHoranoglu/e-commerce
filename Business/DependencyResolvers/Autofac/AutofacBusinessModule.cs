using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Utilities.Interceptors.MethodInterception;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule :Module
{
    //burayı override yazıp loada tıkladık
    //peki bunu ne için yaptık derseniz : kısacası uygulama hayata geçtiği zamn örneğin bir yerde yayınladığınız zaman
    //yani uygulama ayağı kalktığında şurası çalışacak
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); //bu neye karşılık geliyor biliyormusun hani wepApi de sturtap içinde Addsingletona 
        //birisi senden IProductService isterse ProductManager ı register et yani ver
        builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

        builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance(); 
        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

    }
}
