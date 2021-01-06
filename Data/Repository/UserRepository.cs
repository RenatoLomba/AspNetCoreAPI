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
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository 
    {
        protected new readonly MyContext _context;
        private DbSet<UserEntity> _dataset;
        public UserRepository(MyContext context) : base(context)
        {
            _context = context;
            _dataset = _context.Set<UserEntity>();
        }
        public async Task<UserEntity> SelectAsync(string email)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Email.Equals(email));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
