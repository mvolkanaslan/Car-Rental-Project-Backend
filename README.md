![cizimbanner2](https://raw.githubusercontent.com/furkanpasaoglu/githubImages/main/Yaz%C4%B1l%C4%B1m%20Geli%C5%9Ftirici%20Yeti%C5%9Ftirme%20kamp%C4%B1.png)

<hr>
Katmanlı mimari ile tasarladığımız bu projede OOP tarafında Entity Framework kullanılmaktadır.Sürdürülebilir bir mimari için IoC prensibi ve SOLID ilkeleri ile geliştirilme amaçlanmıştır. AutoFac ve FluentValidation paketleri kullanılıyor .Proje API üzerinden devam ediyor.
<hr>

# Layers

- [Business](https://github.com/mvolkanaslan/ReCapProject/tree/master/Business)
  : Database ile kullancı arasındaki iletişimi
  yöneten Business Katmanı'nda Abstract,Concrete
  sınıflarında ilgilioperasyonlar tanımlanmıştır.
  Business operasyonlarında gerekli Doğrulama
  kuralları ValidationRules sınıfında yer
  almaktadır. Bağımlılıkların Çözümlemdiği
  DependencyResolvers sınıfı, Güvenlik
  aşamalarının sağlandığı BusinessAspects sınıfı
  yer almaktadır.

- [Core](https://github.com/mvolkanaslan/ReCapProject/tree/master/Core)
  : Bu katman diğer katmanlara destek sağlayan
  merkezi bir katmandır. Business katmanındaki
  operasyonlarda kullanıalcak Caching,Validation
  gibi Aspects Operasyonlar, IoC Interceptor
  FileService gibi Utils sınıfları ve çeşitli
  Extention operasyonları yeralmaktadır.Core
  katmanının .Net Core ile hiçbir bağlantısı
  yoktur.
- [DataAccess](https://github.com/mvolkanaslan/ReCapProject/tree/master/DataAccesss):Veritabanı
  iletişiminin sağlandığı katmandır. Database
  işlemleri EntityFrameWork ile gerçekleştirlir.
- [Entites](https://github.com/mvolkanaslan/ReCapProject/tree/master/Entities):Veritabanı
  nesnelerinin yer aldığı Entities Katmanı'nda
  Abstract ve Concrete olmak üzere iki adet klasör
  bulunmaktadır.Abstract klasörü soyut nesneleri,
  Concrete klasörü somut nesneleri tutmak için
  oluşturulmuştur.
- [WebAPI](https://github.com/mvolkanaslan/ReCapProject/tree/master/WebAPI)
  Web Api ile Tüm ortamlar arasında iletişim
  sağlanmaktadır.

# Kullanılan Sistemler

- .NET
- ASP.NET for Restful api
- EntityFramework Core
- Autofac
- FluentValidation
- MsSql
- Angular for Frontend

# Teknolojiler

- Katmanlı Mimari Tasarım Deseni
- AOP
- JWT
- Autofac dependency resolver
- IOC

# Nuget Paketleri

### Autofac Version="6.1.0"

### Autofac.Extensions.DependencyInjection

### Version="7.1.0" Autofac.Extras.DynamicProxy

### Version="6.0.0" FluentValidation Version="9.5.1"

### Microsoft.AspNetCore.Http Version="2.2.2"

### Microsoft.AspNetCore.Http.Features Version="5.0.3"

### Microsoft.AspNetCore.Http.Abstractions

### Version="2.2.0"

### Microsoft.EntityFrameworkCore.SqlServer

### Version="3.1.1" Microsoft.IdentityModel.Tokens

### Version="6.8.0" System.IdentityModel.Tokens.Jwt

### Version="6.8.0"
