using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        public List<Car> Get()
        {
            return new List<Car>
            {
                new Car{Id=1,Description="araba 1"},
                new Car{Id=2,Description="araba 2"},
            };
        }
    }
}
