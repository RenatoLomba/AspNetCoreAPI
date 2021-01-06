using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.Uf;

namespace Domain.DTOs.Municipio
{
    public class MunicipioDTOEntry
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }
    }
}
