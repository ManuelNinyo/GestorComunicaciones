using GestorComunicaciones.Core.Entities;
using GestorComunicaciones.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestorComunicaciones.WebApi.Controllers.authentication
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class authenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public authenticationController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;

        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin login)
        {
            var user= await this._userService.GetUserAsync(login);
            if (user == null)
            {
                return NotFound(new {
                    Access=false,
                    msg="datos de acceso incorrectos",
                    token = ""
                });
            }
            var validation = this._userService.ValidateUser(login,user);
            if (validation)
            {
                var rolName =await  this._userService.GetRoleAsync(user);
                var token = GenerateToken(user.Email, rolName);
                return Ok(new { token });
            }

            return NotFound(new
            {
                Access = false,
                msg = "datos de acceso incorrectos",
                token = ""
            });
        }
        private string GenerateToken(string email,string role)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);


            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role.ToString()),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(300)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
