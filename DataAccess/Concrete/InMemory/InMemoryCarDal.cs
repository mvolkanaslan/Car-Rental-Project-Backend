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
    public class InMemoryCarDal : ICarDal
    {
        // Şuan bir database olmadığı için dataları burada barındırdık.
        //Bu class için global _Car değişkeni

        List<Car> _Cars;

        // class default olarak dataları constructor blogu içerisinde oluşturdu
        public InMemoryCarDal()
        {
            _Cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=2,DailyPrice=500,ModelYear=2015,Description="FOCUS 1.5 TDCI 120 BG"},
                new Car{Id=2,BrandId=3,ColorId=1,DailyPrice=600,ModelYear=2018,Description="Clio 1.5 DCi Touch EDC"},
                new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=900,ModelYear=2020,Description="CLA AMG 200"},
                new Car{Id=4,BrandId=1,ColorId=1,DailyPrice=700,ModelYear=2018,Description="A200 1.4 Style DCT"},
                new Car{Id=5,BrandId=2,ColorId=2,DailyPrice=500,ModelYear=2017,Description="FIORINO 1.3 MultiJet 95 HP"},
            };
        }
        

        public void Add(Car car)
        {
            _Cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _Cars.SingleOrDefault(c => c.Id == car.Id);
            _Cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _Cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _Cars.SingleOrDefault(c => c.Id == id);
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByBrandId(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorId(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _Cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
        
    }
}
