using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.User;
using FluentValidation;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEqual("foo").NotEmpty().EmailAddress().MaximumLength(100);
            RuleFor(x => x.Name).NotNull().NotEqual("foo").NotEmpty().MaximumLength(60);
        }
    }
}
