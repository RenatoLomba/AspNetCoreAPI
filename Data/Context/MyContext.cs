using System;
using System.Collections.Generic;
using System.Text;
using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    //CONTEXTO QUE VAI RELACIONAR AS ENTIDADES DE DOMÍNIO COM O ENTITY FRAMEWORK
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure); //CONFIGURA O MAPEAMENTO DA TABELA
        }

        //PROPRIEDADE QUE REFERENCIA A ENTIDADE USERENTITY
        public DbSet<UserEntity> Users { get; set; }
    }
}
