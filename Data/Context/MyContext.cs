using System;
using System.Collections.Generic;
using System.Text;
using Data.Mapping;
using Data.Seeds;
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

            //CONFIGURA O MAPEAMENTO DAS TABELAS A PARTIR DOS MAPPINGS
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<UfEntity>(new UfMap().Configure);
            modelBuilder.Entity<MunicipioEntity>(new MunicipioMap().Configure);
            modelBuilder.Entity<CepEntity>(new CepMap().Configure);

            //DADOS SEMENTES GERADOS NA CONSTRUÇÃO DA TABELA NAS MIGRAÇÕES
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    Email = "adm@root.com",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                }    
            );
            UfSeeds.Ufs(modelBuilder);

        }

        //PROPRIEDADES QUE REFERENCIAM AS ENTIDADES
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UfEntity> Ufs { get; set; }
        public DbSet<MunicipioEntity> Municipios { get; set; }
        public DbSet<CepEntity> Ceps { get; set; }
    }
}
