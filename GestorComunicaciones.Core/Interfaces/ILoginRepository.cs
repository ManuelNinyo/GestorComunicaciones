using GestorComunicaciones.Core.Entities;
using System.Threading.Tasks;

namespace GestorComunicaciones.Core.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> FindUser(UserLogin userLogin);
    }
}