using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<UserEntity>
    {
        public UserValidator()
        {
            RuleSet("Post", () =>
            {
                RuleFor(x => x.Email).NotNull().NotEqual("foo").NotEmpty().EmailAddress();
                RuleFor(x => x.Name).NotNull().NotEqual("foo").NotEmpty().MaximumLength(60);
            });

            RuleSet("Put", () =>
            {
                RuleFor(x => x.Id).NotNull().NotEmpty();
            });
        }
    }
}
