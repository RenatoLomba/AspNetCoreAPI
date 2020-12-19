using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces
{
    //INTERFACE DO REPOSITÓRIO
    public interface IRepository<T> where T : BaseEntity
    {
        //CRUD DA API
        Task<T> InsertAsync(T item); //INSERT
        Task<T> UpdateAsync(T item); //UPDATE
        Task<bool> DeleteAsync(Guid id); //DELETE
        Task<T> SelectAsync(Guid id); //SELECT ESPECÍFICO
        Task<IEnumerable<T>> SelectAsync(); //SELECT ALL
        Task<bool> ExistAsync(Guid id); //VERIFICA SE EXISTE
    }
}
