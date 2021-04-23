using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                
                var result = from car in context.Cars
                             join rental in filter==null? context.Rentals:context.Rentals.Where(filter)
                             on car.Id equals rental.CarId
                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 CarName = car.Description,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 CompanyName = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = (DateTime)rental.ReturnDate
                             };
                return result.ToList();



            }
        }
    }
}
