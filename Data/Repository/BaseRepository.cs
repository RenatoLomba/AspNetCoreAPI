using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        private DbSet<T> _dataSet;

        //INJEÇÃO DE DEPENDENCIA DO CONTEXTO/DBSET
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                //CASO ID SEJA VAZIO, ATRIBUI-SE UM IDENTIFICADOR UNICO GUID
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }
                item.CreateAt = DateTime.UtcNow; //DATA ATUAL

                _dataSet.Add(item); //INSERT INTO [] COLUMNS VALUES
                await _context.SaveChangesAsync(); //SALVA O CONTEXTO AO FINAL

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id)); //RECEBERÁ O OBJETO DA TABELA CASO ACHAR
                if (result == null) //CASO O OBJETO NÃO EXISTA, RETORNA A FUNÇÃO NULA
                    return null;

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt; //PERMANECE A DATA ORIGINAL

                _context.Entry(result).CurrentValues.SetValues(item); //UPDATE [] SET COLUMN = VALUE WHERE ID=id 
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                    return false;

                _dataSet.Remove(result); //DELETE * FROM [] WHERE ID=id

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataSet.AnyAsync(p => p.Id.Equals(id)); //VERIFICA SE EXISTE UM ELEMENTO COM ESSE ID
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id)); //SELECT * FROM [] WHERE ID=id
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync(); //SELECT * FROM
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
