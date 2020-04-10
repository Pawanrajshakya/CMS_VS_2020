using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Add(UserDto entity)
        {
            byte[] passwordHash, passwordSalt;

            if (await _unitOfWork.User.UserExists(entity.Username))
                throw new Exception("Username already exists.");

            User userToCreate = _mapper.Map<User>(entity);

            CreatePasswordHash(entity.Password, out passwordHash, out passwordSalt);
            userToCreate.PasswordHash = passwordHash;
            userToCreate.PasswordSalt = passwordSalt;

            userToCreate.UserRole = new System.Collections.Generic.List<UserRole>();

            if (entity.UserRole.Length > 0)
            {
                foreach (var userRole in entity.UserRole)
                {
                    userToCreate.UserRole.Add(new UserRole { RoleId = userRole });
                }
            }

            _unitOfWork.User.Add(userToCreate);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<UserDto> Get(int id)
        {
            var entity = await this._unitOfWork.User.Get(id);
            if (!entity.IsVisible)
                return null;
            UserDto userDto = _mapper.Map<UserDto>(entity);
            return userDto;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            List<UserDto> entityDtos = new List<UserDto>();
            var entities = (await this._unitOfWork.User.GetAll()).Where(x => x.IsVisible);
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    entityDtos.Add(_mapper.Map<UserDto>(entity));
                }
            }
            return entityDtos;
        }

        public async Task<bool> Remove(int id)
        {
            var entityToDelete = await this._unitOfWork.User.Get(id);

            if (entityToDelete == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.User.Remove(entityToDelete);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var entity = await this._unitOfWork.User.Get(id);

            if (entity == null)
                throw new Exception("Not Found.");

            entity.IsVisible = false;

            this._unitOfWork.User.Update(entity);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> Update(int id, UserDto entity)
        {
            var entityToUpdate = await this._unitOfWork.User.Get(id);

            if (entityToUpdate == null)
                throw new Exception("Not Found.");

            entityToUpdate.Username = entity.Username;
            entityToUpdate.IsActive = entity.IsActive;
            entityToUpdate.Gender = entity.Gender;
            entityToUpdate.Email = entity.Email;
            entityToUpdate.Name = entity.Name;

            _unitOfWork.User.Update(entityToUpdate);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
        public async Task<UserDto> Login(string username, string password)
        {
            var user = await _unitOfWork.User.Find(x=>x.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            UserDto userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < ComputedHash.Length; i++)
                {
                    if (ComputedHash[i] != passwordHash[i])
                        return false;
                }
                return true;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}