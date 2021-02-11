using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2 && car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.ErrorMsg);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Add_Msg);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeleteMsg);

        }
        
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ListMsg);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(c => c.Id == id),Messages.ListMsg); 
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.ListMsg);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),Messages.ListMsg);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.ListMsg);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdateMsg);
        }
    }
}
