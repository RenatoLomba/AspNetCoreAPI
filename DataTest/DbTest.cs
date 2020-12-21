using System;
using CrossCutting.DependencyInjection;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DataTest
{
    public class DbTest : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", "")}";
        public ServiceProvider ServiceProvider { get; private set; }
        public DbTest()
        {
            //CRIA UMA CONEXÃO COM O BANCO DE DADOS TEMPORÁRIA COM O CONTEXTO
            IServiceCollection serviceCollection = new ServiceCollection();
            string conexaoTest = $"Persist Security Info=True;Server=localhost;Port=3306;Database={dataBaseName};Uid=root;Pwd=Redeye@18";
            ConfigureContext<MyContext>.ConfigureDependenciesContextTest(serviceCollection, conexaoTest);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using(var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {
            //APAGA A CONEXÃO TEMPORÁRIA COM O BANCO
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
