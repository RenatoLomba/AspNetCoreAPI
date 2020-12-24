using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DataTest
{
    //TESTE DE CRUD DE USUÁRIO
    public class UserCrudCompleto : DbTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider { get; set; }
        public UserCrudCompleto(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task CrudUsuario()
        {
            using(var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repUserImplementation = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(), //CRIA UM EMAIL FAKE PARA TESTE
                    Name = Faker.Name.FullName() //CRIA UM NOME FAKE PARA TESTE
                };

                //INSERT
                var _registroCriado = await _repUserImplementation.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);
                //-------------------------------------------

                //SELECT
                var _registroRetornado = await _repUserImplementation.SelectAsync(_entity.Id);
                Assert.NotNull(_registroRetornado);
                Assert.Equal(_entity.Email, _registroRetornado.Email);
                Assert.Equal(_entity.Name, _registroRetornado.Name);
                //-------------------------------------------

                //SELECT BY EMAIL
                var _registroRetornadoByEmail = await _repUserImplementation.SelectAsync(_entity.Email);
                Assert.NotNull(_registroRetornadoByEmail);
                Assert.Equal(_entity.Email, _registroRetornadoByEmail.Email);
                Assert.Equal(_entity.Name, _registroRetornadoByEmail.Name);
                //-------------------------------------------

                //SELECT ALL
                var _listaRetornada = await _repUserImplementation.SelectAsync();
                Assert.NotNull(_registroRetornado);
                Assert.True(_listaRetornada.Count() > 0);
                //-------------------------------------------

                _entity.Name = Faker.Name.First();

                //UPDATE
                var _registroAtualizado = await _repUserImplementation.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Email, _registroAtualizado.Email);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);
                Assert.False(_registroAtualizado.Id == Guid.Empty);
                //-------------------------------------------

                //DELETE
                var _registroApagado = await _repUserImplementation.DeleteAsync(_entity.Id);
                Assert.True(_registroApagado);
                //-------------------------------------------

            }
        }
    }
}
