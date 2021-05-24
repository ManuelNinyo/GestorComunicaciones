using GestorComunicaciones.Core.Entities;
using GestorComunicaciones.Core.Interfaces;
using GestorComunicaciones.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorComunicaciones.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CommunicationContext _context;
        private readonly IRepository<Communication,long> _communicationRepository;
        private readonly IRepository<User,int> _userRepository;
        private readonly IRepository<Role, int> _roleRepository;
        private readonly IRepository<CommunicationType, int> _communicationTypeRepository;
        private readonly ILoginRepository _loginRepository;

        public UnitOfWork(CommunicationContext context)
        {
            _context = context;
        }

        public IRepository<Communication, long> CommunicationRepository => _communicationRepository ?? new CommunicationRepository(_context);

        public IRepository<User, int> UserRepository => _userRepository ?? new BaseRepository<User, int>(_context);

        public IRepository<Role, int> RoleRepository => _roleRepository ?? new BaseRepository<Role, int>(_context);

        public IRepository<CommunicationType, int> CommunicationTypeRepository => _communicationTypeRepository ?? new BaseRepository<CommunicationType, int>(_context);

        public ILoginRepository LoginRepository => _loginRepository ?? new LoginRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
