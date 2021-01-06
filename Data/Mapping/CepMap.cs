using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class CepMap : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder)
        {
            builder.ToTable("Cep"); //NOME DA TABELA
            builder.HasKey(p => p.Id); //CHAVE PRIMÁRIA
            builder.HasIndex(p => p.Cep); //INDEX

            //UM CEP POSSUI UM MUNICIPIO (HAS ONE MUNICIPIO), E UM MUNICIPIO POSSUI VARIOS CEPS (WITH MANY CEPS)
            builder.HasOne(m => m.Municipio).WithMany(c => c.Ceps);

            builder.Property(p => p.Cep).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Logradouro).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Numero).IsRequired().HasMaxLength(10);
        }
    }
}
