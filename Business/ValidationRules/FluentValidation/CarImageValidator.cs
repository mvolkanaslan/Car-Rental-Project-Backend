using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator<T> : AbstractValidator<CarImageDto>
    {
        public CarImageValidator()
        {
            //RuleFor(customer => customer.Address.Postcode).NotNull().When(customer => customer.Address != null)
            RuleFor(ci => ci.ImageFile).NotEmpty();
            RuleFor(ci => ci).Must(FileTypeControl).WithMessage(Messages.FileTypeInValid);
        }
        private bool FileTypeControl(CarImageDto arg)
        {
            string[] types = { "image/jpeg", "image/jpg", "image/png" };
            if (arg.ImageFile == null) return false;
            else if (!Array.Exists(types, type => type == arg.ImageFile.ContentType.ToString())) return false;
            return true;
        }
    }
    public class CarImageUpdateValidator : CarImageValidator<CarImageDto>
    {
        public CarImageUpdateValidator()
        {
            RuleFor(ci => ci.Id).NotEmpty().WithMessage("id olmak zorunda");
        }
    }
    public class CarImageAddValidator : CarImageValidator<CarImageDto>
    {
        public CarImageAddValidator()
        {
            RuleFor(ci => ci.CarId).NotEmpty();

        }
    }
}
