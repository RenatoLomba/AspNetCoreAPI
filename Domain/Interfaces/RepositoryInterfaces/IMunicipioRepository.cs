using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces
{
    public interface IMunicipioRepository : IRepository<MunicipioEntity>
    {
        Task<MunicipioEntity> SelectCompleteAsync(Guid id);
        Task<MunicipioEntity> SelectCompleteAsync(int codIBGE);
    }
}
