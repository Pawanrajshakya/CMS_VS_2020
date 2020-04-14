using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service_Layer.Dtos;
using Service_Layer.Interface;
using Web_API.Helpers;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController: BaseApiController
    {
        public UserController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpGet]
        //[CustomAuthorizationFilter]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _serviceManager.User.GetAll();

                if (users != null)
                    return Ok(users);

                return NotFound();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _serviceManager.User.Get(id);

                if (user != null)
                    return Ok(user);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            try
            {
                if (await _serviceManager.User.Add(userDto))
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
        public async Task<IActionResult> Patch(int id, UserDto userDto)
        {
            try
            {
                if (!await _serviceManager.User.Update(id, userDto))
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
                if (await _serviceManager.User.Remove(id))
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
                if (await _serviceManager.User.SoftDelete(id))
                    return Ok();

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            try
            {
                UserDto userDto = new UserDto { Username = "pawanrajshakya", Password = "password", Name = "Sys Admin", UserRole = new int[]{1} };
                if (await _serviceManager.User.Add(userDto))
                    return StatusCode(201);
                else
                    return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = await _serviceManager.User.Login(userLoginDto.Username.ToLower(), userLoginDto.Password);

            if (user == null)
                return Unauthorized();

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}