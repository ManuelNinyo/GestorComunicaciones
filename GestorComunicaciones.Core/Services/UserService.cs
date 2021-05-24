using GestorComunicaciones.Core.Entities;
using GestorComunicaciones.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorComunicaciones.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> getUsersAsync()
        {
            return await Task.FromResult(this._unitOfWork.UserRepository.GetAll());
        }
        public async Task<User> GetUserAsync(UserLogin userlogin)
        {
            return await _unitOfWork.LoginRepository.FindUser(userlogin);
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }
        public bool ValidateUser(UserLogin userLogin, User user)
        {
            if (user.Password.Equals(userLogin.Password))
            {
                return true;
            }

            return false;
        }

        public async Task InsertUser(User user)
        {
            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateUser(User user)
        {
            var existingUser = await _unitOfWork.UserRepository.GetById(user.Id);
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.RoleId = user.RoleId;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            _unitOfWork.UserRepository.Update(existingUser);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<string> GetRoleAsync(User user)
        {
            var Role = await _unitOfWork.RoleRepository.GetById(user.RoleId);
            return Role.Name;
        }
    }
}
