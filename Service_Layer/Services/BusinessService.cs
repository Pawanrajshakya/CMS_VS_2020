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
    public class BusinessService : BaseService, IBusinessService
    {
        public BusinessService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Add(BusinessDto businessDto)
        {

            if (await _unitOfWork.Business.BusinessExists(businessDto.Name))
            {
                throw new Exception("Name already exists.");
            }

            Business businessToSave = _mapper.Map<Business>(businessDto);

            _unitOfWork.Business.Add(businessToSave);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;

        }

        public async Task<BusinessDto> Get(int id)
        {
            var business = await this._unitOfWork.Business.Get(id);
            BusinessDto businessDto = _mapper.Map<BusinessDto>(business);
            return businessDto;

        }
        
        public async Task<IEnumerable<BusinessDto>> GetAll()
        {
            List<BusinessDto> businessDtos = new List<BusinessDto>();
            var businesses = await this._unitOfWork.Business.GetAll();
            if (businesses != null)
            {
                foreach (var business in businesses)
                {
                    businessDtos.Add(_mapper.Map<BusinessDto>(business));
                }
            }
            return businessDtos;
        }
        public async Task<bool> Remove(int id)
        {
            var businessToDelete = await this._unitOfWork.Business.Get(id);

            if (businessToDelete == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.Business.Remove(businessToDelete);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var business = await this._unitOfWork.Business.Get(id);

            if (business == null)
                throw new Exception("Not Found.");

            business.IsVisible = false;

            this._unitOfWork.Business.Update(business);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
        public async Task<bool> Update(int id, BusinessDto businessDto)
        {
            var businessToPatch = await this._unitOfWork.Business.Get(id);

            if (businessToPatch == null)
                throw new Exception("Not Found.");

            businessToPatch.Address1 = businessDto.Address1;
            businessToPatch.Address2 = businessDto.Address2;
            businessToPatch.Description = businessDto.Description;
            businessToPatch.Name = businessDto.Name;
            businessToPatch.ZipCode = businessDto.ZipCode;
            businessToPatch.State = businessDto.State;
            businessToPatch.IsActive = businessDto.IsActive;

            _unitOfWork.Business.Update(businessToPatch);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
    }
}