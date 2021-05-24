using GestorComunicaciones.Core.Entities;
using GestorComunicaciones.Core.Interfaces;
using GestorComunicaciones.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorComunicaciones.Infrastructure.Repositories
{
    class LoginRepository : BaseRepository<User,int>, ILoginRepository
    {
        public LoginRepository(CommunicationContext context) : base(context)
        {

        }
        public async Task<User> FindUser(UserLogin userLogin)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Email == userLogin.Email);
        }

    }
}
