using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extentions
{
    public static class ServiceCollectionExtentions
    {
        //Extention classlar static olur
        //IServiceCollection Api mizin Servis bağımlılıklarıı eklediğimiz yada araya girmesini istediğimiz servisleri eklediğimiz koleksiyondur.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);

            }
            return ServiceTool.Create(serviceCollection);
            //Buradaki amacımız projede kullanılacak olan servicelerin staratup da tektek eklenmesi yerine 
            //ICoreModule Tipindeki tüm servisleri tek seferde. Oluşturuyor.
        }
    }
}
