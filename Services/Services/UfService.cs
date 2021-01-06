using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.Uf;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServiceInterfaces;

namespace Services.Services
{
    public class UfService : IUfService
    {
        private readonly IUfRepository _ufRep;
        private readonly IMapper _mapper;

        public UfService(IUfRepository ufRepository, IMapper mapper)
        {
            _ufRep = ufRepository;
            _mapper = mapper;
        }
        public async Task<UfDTO> Get(Guid id)
        {
            var result = await _ufRep.SelectAsync(id);
            return  _mapper.Map<UfDTO>(result);
        }

        public async Task<IEnumerable<UfDTO>> GetAll()
        {
            var result = await _ufRep.SelectAsync();
            return _mapper.Map<IEnumerable<UfDTO>>(result);
        }
    }
}
