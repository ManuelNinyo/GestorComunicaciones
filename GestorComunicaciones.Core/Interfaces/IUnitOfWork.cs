using GestorComunicaciones.Core.Entities;
using System;
using System.Threading.Tasks;

namespace GestorComunicaciones.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Communication,long> CommunicationRepository { get; }

        IRepository<User,int> UserRepository { get; }

        IRepository<Role, int> RoleRepository { get; }

        IRepository<CommunicationType, int> CommunicationTypeRepository { get; }

        ILoginRepository LoginRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}