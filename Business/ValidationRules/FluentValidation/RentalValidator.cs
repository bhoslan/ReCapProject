using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r).Must(CheckDate).WithMessage(Messages.CheckDate);
        }

        private bool CheckDate(Rental arg)
        {
            return arg.RentDate > arg.ReturnDate;
        }
    }
}
