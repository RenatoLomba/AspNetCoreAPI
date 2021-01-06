using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class UfEntity : BaseEntity
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public IEnumerable<MunicipioEntity> Municipios { get; set; } //UMA UF POSSUI VARIOS MUNICIPIOS
    }
}
