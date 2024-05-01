using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions;

public static class ServicesCollectionExtension
{
    public static IServiceCollection AddDependencyResolvers
        (this IServiceCollection servicesCollection, ICoreModule[] modules )
    {
        foreach (var module in modules)
        {
            module.load(servicesCollection);   
        }
        return ServiceTool.Create(servicesCollection);
    }
}
