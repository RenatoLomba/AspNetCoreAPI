using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces
{
    public interface ICepRepository : IRepository<CepEntity>
    {
        Task<CepEntity> SelectAsync(string cep);
    }
}
