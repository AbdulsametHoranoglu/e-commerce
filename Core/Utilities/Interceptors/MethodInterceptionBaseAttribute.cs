using Castle.DynamicProxy;

//validation gibi loglama gibi cache gibi şeyleri  biz metotların  üzerine attirbute olarak yazıyoruz
// pek altaki kod ne diyor AttributeTargets.Class = classlara veya AttributeTargets.Method = metotlara ekleyebilirsin,
// AllowMultiple = true = birden fazla ekleyebilirsin ve Inherited = true = inherit edilen bir noktada da çalışsın  
namespace Core.Utilities.Interceptors;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class MethodInterceptionBaseAttribute : Attribute, Castle.DynamicProxy.IInterceptor
{
    public int Priority { get; set; }

    public virtual void Intercept(IInvocation invocation)
    {

    }
}
