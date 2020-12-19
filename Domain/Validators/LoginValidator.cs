using System;
using Domain.DTOs;
using FluentValidation;

namespace Domain.Validators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        //CLASSE DE VALIDAÇÃO DE DADOS DE LOGIN
        public LoginValidator()
        {
            RuleSet("LoginPwd", () =>
            {
                RuleFor(x => x.Email).NotNull().NotEqual("foo").NotEmpty().EmailAddress();
                RuleFor(x => x.Senha).NotNull().NotEqual("foo").NotEmpty();
            });
        }
    }
}
