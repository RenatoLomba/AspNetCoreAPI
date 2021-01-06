using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.Municipio;
using FluentValidation;

namespace Domain.Validators
{
    public class MunicipioValidator : AbstractValidator<MunicipioDTOEntry>
    {
        public MunicipioValidator()
        {
            RuleSet("Post", () => {
                RuleFor(x => x.Id).Empty();
                RuleFor(x => x.Nome).NotNull().NotEqual("foo").NotEmpty().MaximumLength(60);
                RuleFor(x => x.CodIBGE).NotNull().NotEmpty().IsInEnum();
                RuleFor(x => x.UfId).NotNull().NotEmpty().NotEqual(Guid.Empty);
            });
            RuleSet("Put", () => {
                RuleFor(x => x.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
                RuleFor(x => x.Nome).NotNull().NotEqual("foo").NotEmpty().MaximumLength(60);
                RuleFor(x => x.CodIBGE).NotNull().NotEmpty().IsInEnum();
                RuleFor(x => x.UfId).NotNull().NotEmpty().NotEqual(Guid.Empty);
            });
        }
    }
}
