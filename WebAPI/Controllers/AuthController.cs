using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.IsSuccess)
            {
                return BadRequest(userExists);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("UserUpdate")]
        public ActionResult UserUpdate(UserForUpdateDto userForUpdateDto)
        {
            var result = _authService.Update(userForUpdateDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpPost("ChangePassword")]
        public ActionResult ChangePassword(UserForUpdateDto userForUpdateDtoo)
        {
            var result = _authService.ChangePassword(userForUpdateDtoo);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
    }
}
