using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces
{
    //INTERFACE DE REPOSITÓRIO ESPECIFICA PARA USUÁRIOS
    public interface IUserRepository : IRepository<UserEntity>
    {
        //METODOS MAIS ESPECIFICOS PARA USUÁRIO
        Task<UserEntity> SelectAsync(string email);
    }
}
