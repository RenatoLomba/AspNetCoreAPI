using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    //CLASSE DE CONFIGURAÇÃO DO CONTEXTO
    public class ConfigureContext<T> where T : DbContext
    {
        public static void ConfigureDependenciesContext(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<T>(
                options => options.UseMySql(Conexao.ConexaoPadrao)
            );
        }

        public static void ConfigureDependenciesContextTest(IServiceCollection serviceCollection, string nomeConexao)
        {
            serviceCollection.AddDbContext<T>(
                options => options.UseMySql(nomeConexao),
                ServiceLifetime.Transient
            );
        }
    }
}
