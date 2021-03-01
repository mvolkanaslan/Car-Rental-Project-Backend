using Business.Abstract;
using Core.Utilities.FileService;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public static IWebHostEnvironment _environment;


        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment environment)
        {
            _carImageService = carImageService;
            _environment = environment;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromForm] CarImageDto carImageDTO)
        {
                var result = _carImageService.Add(carImageDTO);
                if (result.IsSuccess)return Ok(result);
                return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Upload([FromForm] CarImageDto carImageDTO)
        {
            var result = _carImageService.Update(carImageDTO);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            CarImage carToDelete = _carImageService.GetById(id).Data;
            var result = _carImageService.Delete(carToDelete);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetByCarId")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImageService.GetByCarId(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}
