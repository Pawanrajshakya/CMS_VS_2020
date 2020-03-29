using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Web_API.Dtos;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : BaseApiController
    {
        public BusinessController(IUnitOfWork unitOfWork, IConfiguration config, IMapper mapper) : base(unitOfWork, config, mapper)
        {
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var businesses = await this._unitOfWork.Business.GetAll();

                if (businesses != null)
                {

                    return Ok(businesses);
                }

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var business = await this._unitOfWork.Business.Get(id);

                if (business != null)
                {
                    BusinessDto businessDto = _mapper.Map<BusinessDto>(business);
                    return Ok(businessDto);
                }

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post(BusinessDto businessDto)
        {
            try
            {
                if (await _unitOfWork.Business.BusinessExists(businessDto.Name))
                {
                    return BadRequest("Name already exists.");
                }

                Business businessToSave = _mapper.Map<Business>(businessDto);

                _unitOfWork.Business.Add(businessToSave);

                if (_unitOfWork.Complete() > 0)
                    return StatusCode(201);
                else
                    return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPatch("patch/{id}")]
        public async Task<IActionResult> Patch(int id, BusinessDto businessDto)
        {
            try
            {
                var businessToPatch = await this._unitOfWork.Business.Get(id);

                if (businessToPatch == null)
                {
                    return BadRequest();
                }

                //businessToPatch = _mapper.Map<Business>(businessDto).RowVersion.;

                businessToPatch.Address1 = businessDto.Address1;
                businessToPatch.Address2 = businessDto.Address2;
                businessToPatch.Description = businessDto.Description;
                businessToPatch.Name = businessDto.Name;
                businessToPatch.ZipCode = businessDto.ZipCode;
                businessToPatch.State = businessDto.State;
                businessToPatch.IsActive = businessDto.IsActive;

                _unitOfWork.Business.Update(businessToPatch);

                if (_unitOfWork.Complete() > 0)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var businessToDelete = await this._unitOfWork.Business.Get(id);

                if (businessToDelete == null)
                {
                    return BadRequest();
                }

                this._unitOfWork.Business.Remove(businessToDelete);

                if (_unitOfWork.Complete() > 0)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("softdelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                var business = await this._unitOfWork.Business.Get(id);

                if (business == null)
                {
                    return BadRequest();
                }
                business.IsVisible = false;
                this._unitOfWork.Business.Update(business);

                if (_unitOfWork.Complete() > 0)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }
    }
}