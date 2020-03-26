using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Web_API.Dtos;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        public AuthController(IUnitOfWork unitOfWork, IConfiguration config)
        : base(unitOfWork, config)
        {
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            try
            {
                userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

                if (await _unitOfWork.User.UserExists(userForRegisterDto.Username))
                    return BadRequest("User already exists.");

                User userToCreate = new User
                {
                    Username = userForRegisterDto.Username,
                    Gender = userForRegisterDto.Gender,
                    Email = userForRegisterDto.Email,
                    UserRole = new System.Collections.Generic.List<UserRole>()
                };

                foreach (var userRole in userForRegisterDto.UserRole)
                {
                    userToCreate.UserRole.Add(new UserRole { RoleId = userRole });
                }

                var createdUser = _unitOfWork.User.Register(userToCreate, userForRegisterDto.Password);

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

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var userFromRepo = await _unitOfWork.User.Login(userLoginDto.Username.ToLower(), userLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.UserId.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

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