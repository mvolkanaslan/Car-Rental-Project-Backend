using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForUpdateDto:UserForRegisterDto,IDto
    {
        public string NewPassword { get; set; }
        public string CompanyName  { get; set; }
        public int CustomerId { get; set; }
    }
}
