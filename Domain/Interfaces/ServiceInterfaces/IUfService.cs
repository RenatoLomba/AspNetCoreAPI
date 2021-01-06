using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.Uf;

namespace Domain.Interfaces.ServiceInterfaces
{
    public interface IUfService
    {
        Task<UfDTO> Get(Guid id);
        Task<IEnumerable<UfDTO>> GetAll();
    }
}
