using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class MunicipioMap : IEntityTypeConfiguration<MunicipioEntity>
    {
        public void Configure(EntityTypeBuilder<MunicipioEntity> builder)
        {
            builder.ToTable("Municipio"); //NOME DA TABELA
            builder.HasKey(p => p.Id); //CHAVE PRIMÁRIA
            builder.HasIndex(p => p.CodIBGE).IsUnique(); //INDEX E UNICO

            //UM MUNICIPIO POSSUI UMA UF (HAS ONE UF), E UMA UF POSSUI VARIOS MUNICIPIOS (WITH MANY MUNICIPIOS)
            builder.HasOne(u => u.Uf).WithMany(m => m.Municipios);

            builder.Property(p => p.Nome).IsRequired().HasMaxLength(60);
        }
    }
}
