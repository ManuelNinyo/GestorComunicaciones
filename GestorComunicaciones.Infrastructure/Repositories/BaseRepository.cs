using GestorComunicaciones.Core.Entities;
using GestorComunicaciones.Core.Interfaces;
using GestorComunicaciones.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorComunicaciones.Infrastructure.Repositories
{
    public class BaseRepository<T,TK> : IRepository<T, TK> where T : BaseEntity<TK>
    {
        protected readonly CommunicationContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(CommunicationContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(TK id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(TK id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}
