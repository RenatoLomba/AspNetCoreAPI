using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Cep
{
    public class CepDTOEntry
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }
    }
}
