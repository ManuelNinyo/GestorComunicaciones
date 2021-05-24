using GestorComunicaciones.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorComunicaciones.Core.Interfaces
{
    public interface IUserService
    {
        Task<bool> DeleteUser(int id);
        Task<User> GetUserAsync(UserLogin userlogin);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> getUsersAsync();
        Task InsertUser(User user);
        Task<bool> UpdateUser(User user);
        bool ValidateUser(UserLogin userLogin, User user);
        Task<string> GetRoleAsync(User user);
    }
}