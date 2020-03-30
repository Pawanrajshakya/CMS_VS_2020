using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : BaseApiController
    {
        public BusinessController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var businesses = await _service.Business.GetAll();

                if (businesses != null)
                    return Ok(businesses);

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
                var business = await _service.Business.Get(id);

                if (business != null)
                    return Ok(business);

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
                if (await _service.Business.Add(businessDto))
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
                if (await _service.Business.Update(id, businessDto))
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
                if (await _service.Business.Remove(id))
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
                if (await _service.Business.SoftDelete(id))
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