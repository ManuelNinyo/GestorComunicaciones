using GestorComunicaciones.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorComunicaciones.Core.Interfaces
{
    public interface ICommunicationService
    {
        Task<bool> DeleteCommunication(long id);
        Task<Communication> GetCommunicationByIdAsync(long id);
        Task<IEnumerable<Communication>> GetCommunicationsAsync();
        Task<string> GetCommunicationTypeAsync(Communication communication);
        Task InsertCommunication(Communication communication);
        Task<bool> UpdateCommunication(Communication communication);
    }
}