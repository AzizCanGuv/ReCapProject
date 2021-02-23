using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.ModelYear).GreaterThanOrEqualTo(2000).WithMessage("Vehicles which are entered have to be newer than 2000!");
            RuleFor(p => p.Description).NotNull().WithMessage("Every car have to have a description!");
            RuleFor(p => p.Description).MinimumLength(3).WithMessage("Description must be longer than 3 characters");


        }



    }
}
