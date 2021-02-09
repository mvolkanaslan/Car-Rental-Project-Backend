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
            foreach (var car in carManager.GetCarDetails())
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
            Car carToAdd2 = new Car
            {
                Id=8,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 800,
                ModelYear = 2021,
                Description = "A8 Spider"
            };

            // List car on the system

            ListCar(carManager.GetAll());
            //Add two car and list cars on the system
            carManager.Add(carToAdd1);
            carManager.Add(carToAdd2);
            ListCar(carManager.GetAll());

            //Delete last car on the system and list...
            Car carToDelete = carManager.GetAll()[carManager.GetAll().Count - 1]; // delete last Car of the database
            carManager.Delete(carToDelete);
            ListCar(carManager.GetAll());

            //Update a car
            Car carToUpdate = new Car
            {
                Id = 1,
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 750,
                ModelYear = 2018,
                Description = "A3 Sedan Coupé"
            };
            carManager.Update(carToUpdate);
            ListCar(carManager.GetAll());

            //List by BrandId
            ListCar(carManager.GetCarsByBrandId(1));

            //List by ColorId
            ListCar(carManager.GetCarsByColorId(2));



            // Yukarıda yaptığım her database işleminden sonra güncel datayı yazdır.

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
