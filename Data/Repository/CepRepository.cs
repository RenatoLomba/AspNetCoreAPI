using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class CepRepository : BaseRepository<CepEntity>, ICepRepository
    {
        protected new readonly MyContext _context;
        private DbSet<CepEntity> _dataset;
        public CepRepository(MyContext context) : base(context)
        {
            _context = context;
            _dataset = _context.Set<CepEntity>();
        }

        public async Task<CepEntity> SelectAsync(string cep)
        {
            try
            {
                //RETORNA O OBJETO CEP COM SEU RESPSCTIVO MUNICIPIO INCLUSO E COM A UF DO MUNICIPIO TAMBEM INCLUSO (THEN INCLUDE)
                return await _dataset.Include(c => c.Municipio).ThenInclude(m => m.Uf).FirstOrDefaultAsync(c => c.Cep.Equals(cep));
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
