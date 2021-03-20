using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal 
    {
        // Şuan bir database olmadığı için dataları burada barındırdık.
        //Bu class için global _Car değişkeni

        List<Car> _Cars;

        // class default olarak dataları constructor blogu içerisinde oluşturdu
        public InMemoryCarDal()
        { }
        
    }
}
