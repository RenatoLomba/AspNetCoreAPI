using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.Cep;
using Domain.DTOs.Municipio;
using Domain.DTOs.Uf;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServiceInterfaces;
using Services.Models;

namespace Services.Services
{
    public class CepService : ICepService
    {
        private readonly ICepRepository _cepRep;
        private readonly IMapper _mapper;

        public CepService(ICepRepository cepRep, IMapper mapper)
        {
            _cepRep = cepRep;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _cepRep.DeleteAsync(id);
        }

        public async Task<CepDTO> Get(Guid id)
        {
            var result = await _cepRep.SelectAsync(id);
            return _mapper.Map<CepDTO>(result);
        }

        public async Task<CepDTO> GetByCep(string cep)
        {
            var result = await _cepRep.SelectAsync(cep);
            return _mapper.Map<CepDTO>(result);
        }

        public async Task<CepDTO> Post(CepDTOEntry cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var result = await _cepRep.InsertAsync(_mapper.Map<CepEntity>(model));
            return _mapper.Map<CepDTO>(result);
        }

        public async Task<CepDTO> Put(CepDTOEntry cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var result = await _cepRep.UpdateAsync(_mapper.Map<CepEntity>(model));
            return _mapper.Map<CepDTO>(result);
        }
    }
}
