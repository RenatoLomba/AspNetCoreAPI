using System;
using System.Collections.Generic;
using System.Text;
using Data.Repository;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        //CONFIGURAÇÃO DAS INJEÇÕES DE DEPENDÊNCIA DA CAMADA REPOSITORY
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            serviceCollection.AddScoped(typeof(IUfRepository), typeof(UfRepository));
            serviceCollection.AddScoped(typeof(IMunicipioRepository), typeof(MunicipioRepository));
            serviceCollection.AddScoped(typeof(ICepRepository), typeof(CepRepository));
        }
    }
}
