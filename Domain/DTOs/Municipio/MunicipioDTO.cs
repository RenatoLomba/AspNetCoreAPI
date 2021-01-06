using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Municipio
{
    //DADOS MAIS COMUNS QUANDO RETORNAR UMA LISTA DE MUNICIPIOS
    public class MunicipioDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }
    }
}
