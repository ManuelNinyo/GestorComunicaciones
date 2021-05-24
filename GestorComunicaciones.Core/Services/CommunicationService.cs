using GestorComunicaciones.Core.Entities;
using GestorComunicaciones.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorComunicaciones.Core.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommunicationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Communication>> GetCommunicationsAsync()
        {
            return await Task.FromResult(_unitOfWork.CommunicationRepository.GetAll());
        }
        public async Task<Communication> GetCommunicationByIdAsync(long id)
        {
            return await _unitOfWork.CommunicationRepository.GetById(id);
        }
        public async Task InsertCommunication(Communication communication)
        {
            await _unitOfWork.CommunicationRepository.Add(communication);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> UpdateCommunication(Communication communication)
        {
            var existingCommunication = await _unitOfWork.CommunicationRepository.GetById(communication.Id);
            existingCommunication.Content = communication.Content;
            existingCommunication.RecipientId = communication.RecipientId;
            existingCommunication.SenderId = communication.SenderId;
            existingCommunication.CommunicationTypeId = communication.CommunicationTypeId;

            _unitOfWork.CommunicationRepository.Update(existingCommunication);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCommunication(long id)
        {
            await _unitOfWork.CommunicationRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<string> GetCommunicationTypeAsync(Communication communication)
        {
            var communicationType = await _unitOfWork.CommunicationTypeRepository.GetById(communication.CommunicationTypeId);
            return communicationType.Name;
        }
    }
}
