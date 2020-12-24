using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs.User;

namespace Data.Repository
{
    //USER REPOSITORY IMPLEMENTA OS METODOS DE BASEREPOSITORY<USERENTITY> E IUSERREPOSITORY
    public class UserRepository : IUserRepository
    {
        private readonly MyContext _context;
        private DbSet<UserEntity> _dataSet;

        public UserRepository(MyContext context)
        {
            _context = context;
            _dataSet = _context.Set<UserEntity>();
        }

        public async Task<UserEntity> SelectAsync(Guid id)
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

        public async Task<IEnumerable<UserEntity>> SelectAsync()
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
        public async Task<UserEntity> InsertAsync(UserEntity item)
        {
            //CASO ID SEJA VAZIO, ATRIBUI-SE UM IDENTIFICADOR UNICO GUID
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }
            item.CreateAt = DateTime.UtcNow; //DATA ATUAL

            using (var connDapper = new MySqlConnection(Conexao.ConexaoPadrao))
            {
                await connDapper.OpenAsync();
                try
                {
                    await connDapper.QueryAsync(
                    "PROC_INSERT_USER",
                    new
                    {
                        PROC_ID = item.Id,
                        PROC_CREATE_AT = item.CreateAt,
                        PROC_USER_NAME = item.Name,
                        PROC_EMAIL = item.Email,
                    }, commandType: System.Data.CommandType.StoredProcedure);
                } catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    await connDapper.CloseAsync();
                }
            }

            return item;
        }

        public async Task<UserEntity> UpdateAsync(UserEntity item)
        {
            try
            {
                var exist = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id)); //RECEBERÁ O OBJETO DA TABELA CASO ACHAR
                if (exist == null) //CASO O OBJETO NÃO EXISTA, RETORNA A FUNÇÃO NULA
                    return null;

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = exist.CreateAt; //PERMANECE A DATA ORIGINAL

                using (var connDapper = new MySqlConnection(Conexao.ConexaoPadrao))
                {
                    await connDapper.OpenAsync();
                    try
                    {
                        await connDapper.QueryAsync(
                        "PROC_UPDATE_USER",
                        new
                        {
                            PROC_ID = exist.Id,
                            PROC_UPDATE_AT = item.UpdateAt,
                            PROC_USER_NAME = item.Name,
                            PROC_EMAIL = item.Email,
                        }, commandType: System.Data.CommandType.StoredProcedure);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        await connDapper.CloseAsync();
                    }
                }
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
                using (var connDapper = new MySqlConnection(Conexao.ConexaoPadrao))
                {
                    await connDapper.OpenAsync();
                    try
                    {
                        await connDapper.QueryAsync(
                        "PROC_DELETE_USER",
                        new
                        {
                            PROC_ID = result.Id,
                        }, commandType: System.Data.CommandType.StoredProcedure);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        await connDapper.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

    }
}
