using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    //CLASSE DE CONFIGURAÇÃO DO CONTEXTO
    public class ConfigureContext
    {
        public static void ConfigureDependenciesContext(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=Redeye@18")
            );
        }
    }
}
