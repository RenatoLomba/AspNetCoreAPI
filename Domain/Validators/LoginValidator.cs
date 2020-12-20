using System;
using FluentValidation;
using Domain.DTOs;

namespace Domain.Validators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        //CLASSE DE VALIDAÇÃO DE DADOS DE LOGIN
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEqual("foo").NotEmpty().EmailAddress().MaximumLength(100);
        }
    }
}
