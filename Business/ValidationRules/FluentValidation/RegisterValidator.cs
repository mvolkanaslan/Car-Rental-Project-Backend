using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator: AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.Password).MinimumLength(8);
        }
    }
    public class UpdateValidator: AbstractValidator<UserForUpdateDto>
    {
        public UpdateValidator()
        {
            RuleFor(r => r.Password).MinimumLength(8);
            RuleFor(u=>u.NewPassword).MinimumLength(8);
        }
    }
}
