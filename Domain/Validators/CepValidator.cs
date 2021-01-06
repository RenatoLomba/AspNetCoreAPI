using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.Cep;
using FluentValidation;

namespace Domain.Validators
{
    public class CepValidator : AbstractValidator<CepDTOEntry>
    {
        public CepValidator()
        {
            RuleSet("Post", () => {
                RuleFor(x => x.Id).Empty();
                RuleFor(x => x.Cep).NotNull().NotEqual("foo").NotEmpty().MaximumLength(10);
                RuleFor(x => x.Logradouro).NotNull().NotEqual("foo").NotEmpty().MaximumLength(60);
                RuleFor(x => x.Numero).NotNull().NotEqual("foo").NotEmpty().MaximumLength(10);
                RuleFor(x => x.MunicipioId).NotNull().NotEmpty().NotEqual(Guid.Empty);
            });
            RuleSet("Put", () => {
                RuleFor(x => x.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
                RuleFor(x => x.Cep).NotNull().NotEqual("foo").NotEmpty().MaximumLength(10);
                RuleFor(x => x.Logradouro).NotNull().NotEqual("foo").NotEmpty().MaximumLength(60);
                RuleFor(x => x.Numero).NotNull().NotEqual("foo").NotEmpty().MaximumLength(10);
                RuleFor(x => x.MunicipioId).NotNull().NotEmpty().NotEqual(Guid.Empty);
            });
        }
    }
}
