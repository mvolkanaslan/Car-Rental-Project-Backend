using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Password).Must(ContainsThese).WithMessage("Min 8 characters, must has number and letter");

        }

        private bool ContainsThese(string arg)
        {
            //MİN 8 karakter ve sayı ve harf içermeli
            return Regex.IsMatch(arg, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
        }
    }
}
