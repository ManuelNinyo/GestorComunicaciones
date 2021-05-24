using AutoMapper;
using GestorComunicaciones.Core.Dtos;
using GestorComunicaciones.Core.Entities;
using GestorComunicaciones.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorComunicaciones.WebApi.Controllers.Communications
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public UsersController(IMapper mapper, ILogger logger, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAsync()
        {
            var users =await  this._userService.getUsersAsync();
            return this._mapper.Map<IEnumerable<UserDto>>(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetAsync(int id)
        {
            var user = await this._userService.GetUserByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task PostAsync([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await this._userService.InsertUser(user);

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await this._userService.UpdateUser(user);
            return Ok(result);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await this._userService.DeleteUser(id);
            return Ok(result);
        }
    }
}
