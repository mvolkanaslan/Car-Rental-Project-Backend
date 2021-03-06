using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    // Core Module projede genel kapsamda yapılacak olan Injection işlemlerini bir çatı altında toplamak için oluşturuldu.
    //Uygulama seviyesinde servis bağımlılıklarını çözümleyeceğimiz yer.
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceColleciton)
        {
            serviceColleciton.AddMemoryCache();
            serviceColleciton.AddSingleton<Stopwatch>();
            serviceColleciton.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceColleciton.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
