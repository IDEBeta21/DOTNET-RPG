using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetRPG.API.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<bool>> Register(User user, string password);
        Task<ServiceResponse<String>> Login(string username, string password);
        Task<bool> UserExists(String username);
    }
}