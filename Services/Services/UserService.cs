using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServiceInterfaces;

namespace Services.Services
{
    //CAMADA DE SERVICE, RESPONSAVEL PELA INTERMEDIAÇÃO ENTRE O USUÁRIO E O BANCO (APPLICATION E DATA)
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserEntity> Get(Guid id)
        {
            return await _userRepository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _userRepository.SelectAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _userRepository.InsertAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }

    }
}
