using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // Bu evrensel bir katmandır.
    //Core Katmanı diğer katmanları refereans almaz çünkü bağımlılık oluşturmaması gerekiyor.
    public interface IEntityRepository<T>where T:class,IEntity,new()
    {

        T GetById(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
