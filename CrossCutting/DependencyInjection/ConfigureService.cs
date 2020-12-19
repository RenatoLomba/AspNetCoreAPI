using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        //CONFIGURAÇÃO DAS INJEÇÕES DE DEPENDÊNCIA DA CAMADA SERVICE
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}
