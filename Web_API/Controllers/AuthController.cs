using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace Web_API.Controllers
{

    public class AuthController 
    {
        

        // [HttpPost("register")]
        // public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        // {
        //     try
        //     {
        //         userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

        //         if (await _unitOfWork.User.UserExists(userForRegisterDto.Username))
        //             return BadRequest("User already exists.");

        //         User userToCreate = new User
        //         {
        //             Username = userForRegisterDto.Username,
        //             Gender = userForRegisterDto.Gender,
        //             Email = userForRegisterDto.Email,
        //             UserRole = new System.Collections.Generic.List<UserRole>()
        //         };

        //         if (userForRegisterDto.UserRole.Length > 0)
        //         {
        //             foreach (var userRole in userForRegisterDto.UserRole)
        //             {
        //                 userToCreate.UserRole.Add(new UserRole { RoleId = userRole });
        //             }
        //         }
        //         var createdUser = _unitOfWork.User.Register(userToCreate, userForRegisterDto.Password);

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

        // [HttpPost("login")]
        // public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        // {
        //     var userFromRepo = await _unitOfWork.User.Login(userLoginDto.Username.ToLower(), userLoginDto.Password);

        //     if (userFromRepo == null)
        //         return Unauthorized();

        //     var claims = new[]{
        //         new Claim(ClaimTypes.NameIdentifier, userFromRepo.UserId.ToString()),
        //         new Claim(ClaimTypes.Name, userFromRepo.Username)
        //     };

        //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

        //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //     var tokenDescriptor = new SecurityTokenDescriptor
        //     {
        //         Subject = new ClaimsIdentity(claims),
        //         Expires = DateTime.Now.AddDays(1),
        //         SigningCredentials = creds
        //     };

        //     var tokenHandler = new JwtSecurityTokenHandler();

        //     var token = tokenHandler.CreateToken(tokenDescriptor);

        //     return Ok(new
        //     {
        //         token = tokenHandler.WriteToken(token)
        //     });
        // }
    }
}