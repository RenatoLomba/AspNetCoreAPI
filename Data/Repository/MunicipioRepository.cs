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
    public class MunicipioRepository : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        protected new readonly MyContext _context;
        private DbSet<MunicipioEntity> _dataset;
        public MunicipioRepository(MyContext context) : base(context)
        {
            _context = context;
            _dataset = _context.Set<MunicipioEntity>();
        }
        public async Task<MunicipioEntity> SelectCompleteAsync(Guid id)
        {
            try
            {
                //RETORNA O OBJETO MUNICIPIO COM O OBJETO UF REFERENTE AQUELE MUNICIPIO (INCLUDE)
                return await _dataset.Include(m => m.Uf).FirstOrDefaultAsync(m => m.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MunicipioEntity> SelectCompleteAsync(int codIBGE)
        {
            try
            {
                //RETORNA O OBJETO MUNICIPIO COM O OBJETO UF REFERENTE AQUELE MUNICIPIO (INCLUDE)
                return await _dataset.Include(m => m.Uf).FirstOrDefaultAsync(m => m.CodIBGE.Equals(codIBGE));
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
