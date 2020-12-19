using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    //CLASSE QUE IRÁ CRIAR UMA CONEXÃO COM O BANCO PARA CRIAÇÃO DE TABELAS EM TEMPO DE EXECUÇÃO
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //CRIAR AS MIGRAÇÕES
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=Redeye@18"); //String de conexão
            return new MyContext(optionsBuilder.Options);
        }
    }
}
