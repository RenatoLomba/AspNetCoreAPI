using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.Cep;
using Domain.DTOs.Municipio;

namespace Domain.Interfaces.ServiceInterfaces
{
    public interface ICepService
    {
        Task<CepDTO> Get(Guid id);
        Task<CepDTO> GetByCep(string cep);
        Task<CepDTO> Post(CepDTOEntry cep);
        Task<CepDTO> Put(CepDTOEntry cep);
        Task<bool> Delete(Guid id);
    }
}
