using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class CepEntity : BaseEntity
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; } //CHAVE ESTRANGEIRA
        public MunicipioEntity Municipio { get; set; } //UM CEP POSSUI UM MUNICIPIO
    }
}
