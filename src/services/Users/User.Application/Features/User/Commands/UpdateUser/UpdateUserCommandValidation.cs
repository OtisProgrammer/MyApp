using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace User.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommandValidation:AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("{FirstName} is required")
                .NotNull()
                .MaximumLength(150).WithMessage("{FirstName} must not exceed 150 characters");


            RuleFor(a => a.LastName)
                .NotEmpty().WithMessage("{LastName} is required")
                .NotNull()
                .MaximumLength(150).WithMessage("{LastName} must not exceed 150 characters");

            RuleFor(a => a.Mobile)
                .NotEmpty().WithMessage("{Mobile} is required")
                .NotNull()
                .MaximumLength(11).WithMessage("{Mobile} must not exceed 11 characters");

            RuleFor(a => a.UserName)
                .NotEmpty().WithMessage("{UserName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters");

            RuleFor(a => a.PassWord)
                .NotEmpty().WithMessage("{PassWord} is required")
                .NotNull()
                .MaximumLength(300).WithMessage("{PassWord} must not exceed 300 characters");

        }
    }
}
