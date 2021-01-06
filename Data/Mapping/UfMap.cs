using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UfMap : IEntityTypeConfiguration<UfEntity>
    {
        public void Configure(EntityTypeBuilder<UfEntity> builder)
        {
            builder.ToTable("Uf"); //NOME DA TABELA
            builder.HasKey(p => p.Id); //CHAVE PRIMÁRIA
            builder.HasIndex(p => p.Sigla).IsUnique(); //INDEX E UNICO

            builder.Property(p => p.Sigla).IsRequired().HasMaxLength(2);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(45);
        }
    }
}
