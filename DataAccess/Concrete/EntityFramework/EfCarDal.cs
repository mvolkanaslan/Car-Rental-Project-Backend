using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {

                var result = from car in filter== null  ? context.Cars : context.Cars.Where(filter)
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandId= car.BrandId,
                                 ColorId=car.ColorId,
                                 CarName = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear=car.ModelYear,
                                 FindexScore=car.FindexScore,
                                 ImagePath= (from carImage in context.CarImages
                                            where (carImage.CarId==car.Id)
                                            select carImage).FirstOrDefault().ImagePath
                             };
                             return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId,int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {

                var result = from car in context.Cars.Where(car=>car.BrandId==brandId && car.ColorId==colorId)
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id

                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandId = car.BrandId,
                                 ColorId = car.ColorId,
                                 CarName = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ImagePath = (from carImage in context.CarImages
                                              where (carImage.CarId == car.Id)
                                              select carImage).FirstOrDefault().ImagePath
                             };
                return result.ToList();
            }
        }


    }
}
