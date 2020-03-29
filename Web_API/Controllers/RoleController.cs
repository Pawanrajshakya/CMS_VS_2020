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
    public class RoleController : BaseApiController
    {
        public RoleController(IUnitOfWork unitOfWork, IConfiguration config, IMapper mapper) : base(unitOfWork, config, mapper)
        {
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post(RoleForNew role)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(role.Description))
                    return BadRequest("Invalid role.");

                if (await _unitOfWork.Role.RoleExists(role.Description))
                {
                    return BadRequest("Role already exists.");
                }

                Role roleToSave = new Role{
                    Description = role.Description
                };

                _unitOfWork.Role.Add(roleToSave);

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
    }
}