using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace User.Application.Features.UserInfo.Commands.UpdateUserInfo
{
   public class UpdateUserInfoCommandValidation:AbstractValidator<UpdateUserInfoCommand>
    {
        public UpdateUserInfoCommandValidation()
        {
            RuleFor(a => a.Address)
                .NotEmpty().WithMessage("{Address} is required")
                .NotNull()
                .MaximumLength(500).WithMessage("{Address} must not exceed 500 characters");


            RuleFor(a => a.PostalCode)
                .NotEmpty().WithMessage("{PostalCode} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PostalCode} must not exceed 10 characters");

            RuleFor(a => a.UserId)
                .NotEmpty().WithMessage("{UserId} is required")
                .GreaterThan(0).WithMessage("{UserId} should be greater than 0");

        }
    }
}
