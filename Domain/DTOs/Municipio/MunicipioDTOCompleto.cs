using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.Uf;

namespace Domain.DTOs.Municipio
{
    //DADOS MAIS ROBUSTOS (COMPLETOS) QUANDO BUSCAR UM MUNICIPIO ESPECIFICO
    public class MunicipioDTOCompleto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public DateTime? CreatAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Guid UfId { get; set; }
        public UfDTO Uf { get; set; }
    }
}
