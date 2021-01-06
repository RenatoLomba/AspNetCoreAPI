using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class MunicipioEntity : BaseEntity
    {
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; } //CHAVE ESTRANGEIRA DE RELACIONAMENTO
        public UfEntity Uf { get; set; } //CADA MUNICIPIO POSSUI UM UF
        public IEnumerable<CepEntity> Ceps { get; set; } //UM MUNICIPIO POSSUI VARIOS CEPS
    }
}
