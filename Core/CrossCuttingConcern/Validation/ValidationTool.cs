using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcern.Validation;

// Cross Cutting Concern = uygulamayı dikine kesen ilgi alanları örn : loglama, cache, transaction(performans yönetimi), authorization(yetkilendirme)...


public static class ValidationTool
{
    public static void Validate(IValidator validator, object entity)//IValidator validator = bana bir tane  validotor ver örn:ProductValidator
    {                                                               //bana bir tane de  object entity = dğrulama için varlır örn: product
        var context = new ValidationContext<object>(entity);
        var result = validator.Validate(context);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
    }
}
