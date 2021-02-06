using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        // Kullanılabilecek herhangi bir database servisini burada kullanacağımızı belirliyoruz
        //Ama hangi service olduğunu beilmiyoruz. InMemory de olur MongoDB de olur vb..
        //CarManager sınıfı bu işleri yaptırmak için bir servis kullanmak isteyecek.
        //Bu soyut br servis olmalı ki daha sonra eklenebilecek diğer servisleri entegre atmak onun üzerinden olsun.
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Girdiğiniz Kriterler uygun değil....");
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.GetById(c=>c.Id==id); 
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c=>c.ColorId==id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
