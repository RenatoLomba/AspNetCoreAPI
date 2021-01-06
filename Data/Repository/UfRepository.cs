using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UfRepository : BaseRepository<UfEntity>, IUfRepository
    {
        protected new readonly MyContext _context;
        private DbSet<UfEntity> _dataset;
        public UfRepository(MyContext context) : base(context)
        {
            _context = context;
            _dataset = _context.Set<UfEntity>();
        }
    }
}
