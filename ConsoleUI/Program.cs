using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Color ve Brand için operasyonlar mevcuttur.
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("---------- Details of Cars ---------------\n");
            var ListofCar = carManager.GetCarDetails();
            Console.WriteLine(ListofCar.Message+"\n");
            foreach (var car in ListofCar.Data)
            {
                Console.WriteLine("{0} --- {1} --- {2} --- {3}", car.CarName,car.BrandName,car.ColorName,car.DailyPrice);
            }


            Car carToAdd1 = new Car
            {
                Id=7,
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 750,
                ModelYear = 2021,
                Description = "E350 AMG Cabriolet"
            };
            
            Console.WriteLine(carManager.Add(carToAdd1).Message);

            void ListCar(List<Car> cars)
            {
                Console.WriteLine("\nCAR LIST ON THE SYSTEM\n");

                foreach (Car car in cars)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", car.Id, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
                }
            }
            Console.ReadLine();
        }
    }
}
