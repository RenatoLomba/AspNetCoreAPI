using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.User;
using Domain.Entities;

namespace Domain.Interfaces.ServiceInterfaces
{
    //INTERFACE DE METODOS DA SERVICE DE USUÁRIO
    public interface IUserService
    {
        Task<UserDTO> Get(Guid id);
        Task<UserDTO> GetByEmail(string email);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> Post(UserDTOEntry user);
        Task<UserDTO> Put(UserDTOEntry user);
        Task<bool> Delete(Guid id);
    }
}
