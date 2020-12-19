using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Domain.Interfaces.ServiceInterfaces
{
    public interface ILoginService
    {
        Task<object> GetByEmail(LoginDTO login);
    }
}
