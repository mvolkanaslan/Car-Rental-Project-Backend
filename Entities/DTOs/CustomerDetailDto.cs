using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto:IDto
    {
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public int FindexPoint { get; set; }
        public List<string> Claims { get; set; }
    }
}
