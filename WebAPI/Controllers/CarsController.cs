using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
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
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if (result.IsSuccess)
            {
                return Ok(result); // 200 status ile datayı yolluyoruz
            }
            return BadRequest(result);
        }


        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);

            if (result.IsSuccess)
            {
                return Ok(result); // 200 status ile datayı yolluyoruz
            }
            return BadRequest(result);
        }



        [HttpGet("CarDetails")]
        public IActionResult CarDetails()
        {
            var result = _carService.GetCarDetails();

            if (result.IsSuccess)
            {
                return Ok(result); // 200 status ile datayı yolluyoruz
            }
            return BadRequest(result);
        }
        [HttpGet("cardetailsById")]
        public IActionResult CarDetailsById(int id)
        {
            var result = _carService.GetCarDetaisById(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);

        }


        [HttpGet("ByBrand")]
        public IActionResult ByBrand(int id)
        {
            var result = _carService.GetCarsByBrandId(id);

            if (result.IsSuccess)
            {
                return Ok(result); // 200 status ile datayı yolluyoruz
            }
            return BadRequest(result);
        }



        [HttpGet("ByColor")]
        public IActionResult ByColor(int id)
        {
            var result = _carService.GetCarsByColorId(id);

            if (result.IsSuccess)
            {
                return Ok(result); // 200 status ile datayı yolluyoruz
            }
            return BadRequest(result);
        }




        [HttpPost("Add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);

            if (result.IsSuccess)
            {
                return Ok(result); // 200 status ile datayı yolluyoruz
            }
            return BadRequest(result);
        }


        [HttpPost("Delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if (result.IsSuccess)
            {
                return Ok(result); // 200 status ile datayı yolluyoruz
            }
            return BadRequest(result);
        }


        [HttpPost("Update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
