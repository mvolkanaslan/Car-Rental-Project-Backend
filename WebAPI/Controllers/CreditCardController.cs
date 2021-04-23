using Business.Abstract;
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
    public class CreditCardController : ControllerBase
    {
        ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }
        [HttpPost("Add")]
        public IActionResult Add(CreditCard creditCard)
        {
            var result = _creditCardService.Add(creditCard);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);

        }
        [HttpGet("GetByCustomerId")]
        public IActionResult GetByCustomerId(int id)
        {
            var result = _creditCardService.GetByCustomerId(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _creditCardService.GetById(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public IActionResult Delete(CreditCard creditCard)
        {
            var result = _creditCardService.Delete(creditCard);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);

        }
        [HttpPost("Update")]
        public IActionResult Update(CreditCard creditCard)
        {
            var result = _creditCardService.Update(creditCard);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);

        }
    }
}
