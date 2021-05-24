using GestorComunicaciones.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorComunicaciones.Core.Interfaces
{
    public interface IRepository<T,TK> where T : BaseEntity<TK>
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(TK id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(TK id);
    }
}
