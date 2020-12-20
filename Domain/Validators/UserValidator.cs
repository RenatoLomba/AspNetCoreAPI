using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs;
using Domain.DTOs.User;
using FluentValidation;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<UserDTOEntry>
    {
        public UserValidator()
        {
            RuleSet("Post", () => {
                RuleFor(x => x.Id).Empty();
                RuleFor(x => x.Email).NotNull().NotEqual("foo").NotEmpty().EmailAddress().MaximumLength(100);
                RuleFor(x => x.Name).NotNull().NotEqual("foo").NotEmpty().MaximumLength(60);
            });
            RuleSet("Put", () => {
                RuleFor(x => x.Id).NotNull().NotEqual("foo").NotEmpty();
                RuleFor(x => x.Email).NotNull().NotEqual("foo").NotEmpty().EmailAddress().MaximumLength(100);
                RuleFor(x => x.Name).NotNull().NotEqual("foo").NotEmpty().MaximumLength(60);
            });
        }
    }
}
