using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator:AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(p => p.CarId).NotEmpty().WithMessage("You have to enter Car Id");
        }

    }
}
