using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    //MAPEAMENTO DA TABELA NO BANCO
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User"); //NOME DA TABELA
            builder.HasKey(p => p.Id); //CHAVE PRIMÁRIA
            builder.HasIndex(p => p.Email).IsUnique(); //INDEX EMAIL E DEVERÁ SER UNICO

            builder.Property(p => p.Name).IsRequired().HasMaxLength(60); //PROPRIEDADE É OBRIGATÓRIA E COM NO MÁXIMO 60 CHARS
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
        }
    }
}
