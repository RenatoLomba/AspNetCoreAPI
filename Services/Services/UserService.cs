using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.User;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServiceInterfaces;
using Services.Models;

namespace Services.Services
{
    //CAMADA DE SERVICE, RESPONSAVEL PELA INTERMEDIAÇÃO ENTRE O USUÁRIO E O BANCO (APPLICATION E DATA)
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDTO> Get(Guid id)
        {
            var result = await _userRepository.SelectAsync(id);
            return _mapper.Map<UserDTO>(result);
        }
        public async Task<UserDTO> GetByEmail(string email)
        {
            var result = await _userRepository.SelectAsync(email);
            return _mapper.Map<UserDTO>(result);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var result = await _userRepository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(result);
        }

        public async Task<UserDTO> Post(UserDTOEntry user)
        {
            var model = _mapper.Map<UserModel>(user);
            var result = await _userRepository.InsertAsync(_mapper.Map<UserEntity>(model));
            return _mapper.Map<UserDTO>(result);
        }

        public async Task<UserDTO> Put(UserDTOEntry user)
        {
            var model = _mapper.Map<UserModel>(user);
            var result = await _userRepository.UpdateAsync(_mapper.Map<UserEntity>(model));
            return _mapper.Map<UserDTO>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }

    }
}
