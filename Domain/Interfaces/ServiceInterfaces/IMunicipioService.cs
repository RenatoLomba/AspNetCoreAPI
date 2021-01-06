using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.Municipio;

namespace Domain.Interfaces.ServiceInterfaces
{
    public interface IMunicipioService
    {
        Task<MunicipioDTO> Get(Guid id);
        Task<MunicipioDTOCompleto> GetCompleteById(Guid id);
        Task<MunicipioDTOCompleto> GetCompleteByIBGE(int codIBGE);
        Task<IEnumerable<MunicipioDTO>> GetAll();
        Task<MunicipioDTO> Post(MunicipioDTOEntry municipio);
        Task<MunicipioDTO> Put(MunicipioDTOEntry municipio);
        Task<bool> Delete(Guid id);
    }
}
