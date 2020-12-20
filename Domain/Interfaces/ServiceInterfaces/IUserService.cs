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
        Task<UserDTOSelectResult> Get(Guid id);
        Task<IEnumerable<UserDTOSelectResult>> GetAll();
        Task<UserDTOCreateResult> Post(UserDTOEntry user);
        Task<UserDTOUpdateResult> Put(UserDTOEntry user);
        Task<bool> Delete(Guid id);
    }
}
