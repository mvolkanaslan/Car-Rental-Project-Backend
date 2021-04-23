using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ICustomerService _customerService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper,ICustomerService customerService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _customerService = customerService;
        }
        [ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            var newUser = _userService.GetByMail(user.Email).Data;
            var newCustomer = new Customer
            {
                UserId = newUser.Id,
                FindexScore = new Random().Next(1900)
            };
            _customerService.Add(newCustomer);
            return new SuccessDataResult<User>(user,Messages.UserRegistered);
        }
        [ValidationAspect(typeof(UpdateValidator))]
        public IResult Update(UserForUpdateDto userForUpdateDto)
        {
            var userToCheck = _userService.GetById(userForUpdateDto.Id).Data;
            var user = new User
            {
                Id= userToCheck.Id,
                Email = userForUpdateDto.Email,
                FirstName = userForUpdateDto.FirstName,
                LastName = userForUpdateDto.LastName,
                PasswordHash = userToCheck.PasswordHash,
                PasswordSalt = userToCheck.PasswordSalt, 
                Status = true,
                
            };
            _userService.Update(user);

            var customerToUpdate = _customerService.GetById(userForUpdateDto.CustomerId).Data;
            customerToUpdate.CompanyName = userForUpdateDto.CompanyName;
            customerToUpdate.UserId = userForUpdateDto.Id;
            _customerService.Update(customerToUpdate);
            return new SuccessResult(Messages.UpdateMsg);
        }
        [ValidationAspect(typeof(UpdateValidator))]
        public IResult ChangePassword(UserForUpdateDto userForUpdateDto)
        {
            var userToCheck = _userService.GetById(userForUpdateDto.Id).Data;

            if (!HashingHelper.VerifyPasswordHash(userForUpdateDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorResult(Messages.PasswordError);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForUpdateDto.NewPassword, out passwordHash, out passwordSalt);
            var user = new User
            {
                Id = userToCheck.Id,
                Email = userToCheck.Email,
                FirstName = userToCheck.FirstName,
                LastName = userToCheck.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,

            };
            _userService.Update(user);
            return new SuccessResult(Messages.UpdateMsg);


        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck.Email == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck,Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
                
            }
            return new SuccessResult();

        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);
        }

        
    }
}
