using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.Municipio;
using Domain.DTOs.Uf;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServiceInterfaces;
using Services.Models;

namespace Services.Services
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IMunicipioRepository _municipioRep;
        private readonly IMapper _mapper;

        public MunicipioService(IMunicipioRepository municipioRep, IMapper mapper)
        {
            _municipioRep = municipioRep;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _municipioRep.DeleteAsync(id);
        }

        public async Task<MunicipioDTO> Get(Guid id)
        {
            var result = await _municipioRep.SelectAsync(id);
            return _mapper.Map<MunicipioDTO>(result);
        }

        public async Task<IEnumerable<MunicipioDTO>> GetAll()
        {
            var result = await _municipioRep.SelectAsync();
            return _mapper.Map<IEnumerable<MunicipioDTO>>(result);
        }

        public async Task<MunicipioDTOCompleto> GetCompleteByIBGE(int codIBGE)
        {
            var result = await _municipioRep.SelectCompleteAsync(codIBGE);
            return _mapper.Map<MunicipioDTOCompleto>(result);
        }

        public async Task<MunicipioDTOCompleto> GetCompleteById(Guid id)
        {
            var result = await _municipioRep.SelectCompleteAsync(id);
            return _mapper.Map<MunicipioDTOCompleto>(result);
        }

        public async Task<MunicipioDTO> Post(MunicipioDTOEntry municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);
            var result = await _municipioRep.InsertAsync(_mapper.Map<MunicipioEntity>(model));
            return _mapper.Map<MunicipioDTO>(result);
        }

        public async Task<MunicipioDTO> Put(MunicipioDTOEntry municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);
            var result = await _municipioRep.UpdateAsync(_mapper.Map<MunicipioEntity>(model));
            return _mapper.Map<MunicipioDTO>(result);
        }
    }
}
