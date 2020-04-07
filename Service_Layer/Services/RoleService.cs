using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Add(RoleDto entity)
        {
            if (await _unitOfWork.Role.RoleExists(entity.Description))
            {
                throw new Exception("Name already exists.");
            }

            Role roleToSave = _mapper.Map<Role>(entity);

            _unitOfWork.Role.Add(roleToSave);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<RoleDto> Get(int id)
        {
            var role = await this._unitOfWork.Role.Get(id);
            RoleDto roleDto = _mapper.Map<RoleDto>(role);
            return roleDto;
        }

        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            List<RoleDto> roleDtos = new List<RoleDto>();
            var roles = await this._unitOfWork.Role.GetAll();
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    roleDtos.Add(_mapper.Map<RoleDto>(role));
                }
            }
            return roleDtos;
        }

        public async Task<bool> Remove(int id)
        {
           var entityToDelete = await this._unitOfWork.Role.Get(id);

            if (entityToDelete == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.Role.Remove(entityToDelete);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var role = await this._unitOfWork.Role.Get(id);

            if (role == null)
                throw new Exception("Not Found.");

            role.IsVisible = false;

            this._unitOfWork.Role.Update(role);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> Update(int id, RoleDto entity)
        {
            var roleToPatch = await this._unitOfWork.Role.Get(id);

            if (roleToPatch == null)
                throw new Exception("Not Found.");

            roleToPatch.Description = entity.Description;
            roleToPatch.IsActive = entity.IsActive;

            _unitOfWork.Role.Update(roleToPatch);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
    }
}