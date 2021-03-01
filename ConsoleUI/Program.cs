using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            CarImageManager carImageManager = new CarImageManager(new EfCarImageDal());

            var result = carImageManager.GetById(1);
            if (result.IsSuccess)
            {
                foreach (CarImage carImage in result.Data)
                {
                    Console.WriteLine(carImage.ImagePath);
                }
            }

            Console.ReadLine();
        }

        

    }
}
