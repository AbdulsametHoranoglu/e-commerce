using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//url de add i çalıştırmaya çalışıyoruz ya niz diyoruz ki add de 

namespace Core.Utilities.Interceptors;

public abstract partial class MethodInterception : MethodInterceptionBaseAttribute
{
    //aspect = bu metot interceoption u aslında temel alan ve hangisi çalışsın istiyorsan onu içeren operasyonlardır
    //dolaısıyla biz aspect yazdığımız zamn o aspect nerede çalışsın isstiyorsak gidip onun ilgili alanlarnı eziyoruz
    protected virtual void OnBefore(IInvocation invocation) { } //virtual metohod ne demek = senin onu ezmeni(yani verride etmeni) bekleyen metotlar demek
    protected virtual void OnAfter(IInvocation invocation) { }// invocation(business metotlarıdır ) = şu an için add metodum ama update, delete, getall, get... metotların yerine geçer 
    protected virtual void OnException(IInvocation invocation, System.Exception e) { }
    protected virtual void OnSuccess(IInvocation invocation) { }
    public override void Intercept(IInvocation invocation)
    {
        var isSuccess = true;
        OnBefore(invocation);
        try
        {
            invocation.Proceed();
        }
        catch (Exception e)
        {
            isSuccess = false;
            OnException(invocation, e);
            throw;
        }
        finally
        {
            if (isSuccess)
            {
                OnSuccess(invocation);
            }
        }
        OnAfter(invocation);
    }
}
