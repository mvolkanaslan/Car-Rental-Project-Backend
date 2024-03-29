﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();

            if (result.IsSuccess)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }


        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("RentalDetails")]
        public IActionResult RentalDetails()
        {
            var result = _rentalService.GetRentalDetails();

            if (result.IsSuccess)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }
        [HttpGet("RentalDetailsByCustomerId")]
        public IActionResult RentalDetailsByCustomerId(int id)
        {
            var result = _rentalService.GetRentalDetailsByCustomerId(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("Add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);

            if (result.IsSuccess)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }

        [HttpPost("IsRentable")]
        public IActionResult IsRentable(Rental rental)
        {
            var result = _rentalService.IsRentable(rental);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("CheckFindex")]
        public IActionResult CheckFindex(int customerId,int carId)
        {
            var result = _rentalService.CheckFindexScore(customerId,carId);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("Delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);

            if (result.IsSuccess)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }


        [HttpPost("Update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
