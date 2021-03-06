using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace Web_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : BaseApiController
    {
        public AccountTypeController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var accountTypes = await _serviceManager.AccountType.GetAll();

                if (accountTypes != null)
                    return Ok(accountTypes);

                return NotFound();
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
                var accountType = await _serviceManager.AccountType.Get(id);

                if (accountType != null)
                    return Ok(accountType);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post(AccountTypeToSaveDto AccountTypeDto)
        {
            try
            {
                if (await _serviceManager.AccountType.Add(AccountTypeDto))
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
        public async Task<IActionResult> Patch(int id, AccountTypeToEditDto AccountTypeDto)
        {
            try
            {
                if (!await _serviceManager.AccountType.Update(id, AccountTypeDto))
                    return BadRequest();

                return Ok();
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
                if (await _serviceManager.AccountType.Remove(id))
                    return Ok();

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
                if (await _serviceManager.AccountType.SoftDelete(id))
                    return Ok();

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }
    }
}