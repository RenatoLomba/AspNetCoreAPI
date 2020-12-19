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
    //USER REPOSITORY IMPLEMENTA OS METODOS DE BASEREPOSITORY<USERENTITY> E IUSERREPOSITORY
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly MyContext _context;
        private DbSet<UserEntity> _dataSet;

        public UserRepository(MyContext context) : base(context)
        {
            _context = context;
            _dataSet = _context.Set<UserEntity>();
        }

        //METODO ESPECIFICO DE USERENTITY PARA RETORNAR POR EMAIL
        public async Task<UserEntity> SelectAsync(string email)
        {
            try
            {
                return await _dataSet.FirstOrDefaultAsync(p => p.Email.Equals(email));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
