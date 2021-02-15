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

            // Add Rental
            Rental rental = new Rental {
            CarId=1,
            RentDate=DateTime.Now,
            CustomerId=3,
            };
            Console.WriteLine(rentalManager.Add(rental).Message); 


            
            // And user and Customer with together
            User user = new User
            {
                FirstName="Damla",
                LastName="Kayalı",
                Email="damla@kayali.com",
                Password="11122233"
            };
            userManager.Add(user);
            Customer customer = new Customer
            {
               UserId = user.Id,
               CompanyName="damlakayali.com"
            };
            customerManager.Add(customer);


            // Rental List              
            ListRental(rentalManager.GetAll());

            // Rental Details List
            RentalsDetails(rentalManager.GetRentalDetails());


            // List Cars with its details-------------------------------
            GetCarDetails(carManager);


            // Get Car list operasions
            // GetAll - GetById - GetCarsByBrandId(id) - GetCarsByColorId(id)
            var GetCarList = carManager.GetCarsByColorId(1);
            ListCars(GetCarList);
            
            Console.ReadLine();
        }

        

        private static void RentalsDetails(IDataResult<List<RentalDetailDto>> rentals)
        {

            if (rentals.IsSuccess)
            {
                Console.WriteLine($"\nCarName\tCustomerName\tCompanyName\tRentalDate\tReturnDate\n");
                foreach (RentalDetailDto RDto in rentals.Data)
                {
                    Console.WriteLine($"{RDto.CarName}\t{RDto.CustomerName}\t{RDto.CompanyName}\t{RDto.RentDate}\t{RDto.ReturnDate}");
                }
                Console.WriteLine(rentals.Message);
            }
            else
            {
                Console.WriteLine(rentals.Message);
            }
            
        }

        private static void ListRental(IDataResult<List<Rental>> rentals)
        {
            if (rentals.IsSuccess)
            {
                Console.WriteLine($"\nRentId\tCarId\tCustomerId\tRentalDate\tReturnDate\n");
                foreach (Rental rental in rentals.Data)
                {
                    Console.WriteLine($"{rental.Id}\t{rental.CarId}\t{rental.CustomerId}\t\t{rental.RentDate}\t{rental.ReturnDate}");
                }
                Console.WriteLine(rentals.Message);
            }
            else
            {
                Console.WriteLine(rentals.Message);
            }

            
        }

        // Listing Cars by given carList
        private static void ListCars(IDataResult<List<Car>> carList)
        {
            if (carList.IsSuccess)
            {
                Console.WriteLine($"\nCarID\tBrandId\tColorId\tModelYear\tDailyPrice\tCarName\n");
                foreach (Car car in carList.Data)
                {
                    Console.WriteLine($"{car.Id}\t{car.BrandId}\t{car.ColorId}\t{car.ModelYear}\t\t{car.DailyPrice}\t   {car.Description}");
                }
                Console.WriteLine(carList.Message);
            }
            else
            {
                Console.WriteLine(carList.Message);
            }
            

        }

        private static void GetCarDetails(CarManager carManager)
        {
            var carList = carManager.GetCarDetails();
            foreach (var car in carList.Data)
            {
                Console.WriteLine($"{car.CarName} - {car.BrandName} - {car.ColorName} - {car.DailyPrice}");
            }
            Console.WriteLine(carList.Message);
        }
    }
}
