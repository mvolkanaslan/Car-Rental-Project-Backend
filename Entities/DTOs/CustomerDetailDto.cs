using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto:IDto
    {
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
    }
}
