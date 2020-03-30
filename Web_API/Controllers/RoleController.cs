using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Interface;

namespace Web_API.Controllers
{

    public class RoleController 
    {
        // public RoleController(IUnitOfWork unitOfWork, IConfiguration config, IMapper mapper) : base(unitOfWork, config, mapper)
        // {
        // }

        // [HttpPost("post")]
        // public async Task<IActionResult> Post(RoleForNew role)
        // {
        //     try
        //     {
        //         if (string.IsNullOrWhiteSpace(role.Description))
        //             return BadRequest("Invalid role.");

        //         if (await _unitOfWork.Role.RoleExists(role.Description))
        //         {
        //             return BadRequest("Role already exists.");
        //         }

        //         Role roleToSave = new Role{
        //             Description = role.Description
        //         };

        //         _unitOfWork.Role.Add(roleToSave);

        //         if (_unitOfWork.Complete() > 0)
        //             return StatusCode(201);
        //         else
        //             return BadRequest();
        //     }
        //     catch (System.Exception e)
        //     {
        //         return HandleException(e);
        //     }
        // }

    }
}