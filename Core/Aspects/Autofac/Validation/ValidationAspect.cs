using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //burası bizim aspect(metodum başında ortasnında sonunda hata verdiğinde çalışacak yapı) imiz  
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) // IsAssignableFrom göndermek istediğin veidator type atanabiliyor mu

            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//instance(newleme) =  çalışma anında isntance oluştumak için Activator CreateInstance kullanırız ve bu satır productValidatoru newledi bizim için 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
