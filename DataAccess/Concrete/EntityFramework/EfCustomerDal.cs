using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<User, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from user in filter ==null ? context.Users:context.Users.Where(filter)
                             join customer in context.Customers
                             on user.Id equals customer.UserId
                             select new CustomerDetailDto
                             {
                                 UserId=user.Id,
                                 CustomerId=customer.CustomerId,
                                 CompanyName = customer.CompanyName,
                                 CustomerName = $"{user.FirstName} {user.LastName}",
                                 Email=user.Email,
                                 FindexPoint=customer.FindexScore,
                                 Claims =   (from uoc in context.UserOperationClaims.Where(c => c.UserId == user.Id)
                                                  join claim in context.OperationClaims
                                                  on uoc.OperationClaimId equals claim.Id
                                                  select claim.Name).ToList()

                             };
                return result.ToList();


            }
        }
    }
}
