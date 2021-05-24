using AutoMapper;
using GestorComunicaciones.Core.Dtos;
using GestorComunicaciones.Core.Entities;
using GestorComunicaciones.Core.Interfaces;
using GestorComunicaciones.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorComunicaciones.WebApi.Controllers.Communications
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICommunicationService _communicationService;
        public CommunicationsController(IMapper mapper,ILogger logger, ICommunicationService communicationService)
        {
            _mapper = mapper;
            _logger = logger;
            _communicationService = communicationService;
        }
        // GET: api/<CommunicationsController>
        [HttpGet]
        public async Task<IEnumerable<CommunicationDto>> GetAsync()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            _logger.LogInformation("usuario{usuario}esta consultando las comunicaciones",email);
            var communications = await this._communicationService.GetCommunicationsAsync();
            var communicationsDto = _mapper.Map<IEnumerable<CommunicationDto>>(communications);
            return communicationsDto;
        }

        // GET api/<CommunicationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommunicationDto>> GetAsync(int id)
        {
            var communication = await this._communicationService.GetCommunicationByIdAsync(id);
            var communicationDto = _mapper.Map<CommunicationDto>(communication);
            return Ok(communicationDto);
        }

        // POST api/<CommunicationsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommunicationDto communicationDto)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            _logger.LogInformation("usuario{usuario}esta intentando insertar comunicacion", email);
            string Role = User.FindFirstValue(ClaimTypes.Role);
            if(Role.ToLower()=="administrador"|| Role.ToLower() == "gestor")
            {
                var communication = _mapper.Map<Communication>(communicationDto);
                await this._communicationService.InsertCommunication(communication);

                return Ok(new { succes = true });
                
            }
            return Unauthorized(new { succes = false, msg = "solo el administrador o el gestor pueden crear comunicaciones" });

        }

        // PUT api/<CommunicationsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody] CommunicationDto communicationDto)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            _logger.LogInformation("usuario{usuario}esta intentando actualizar comunicacion", email);
            string Role = User.FindFirstValue(ClaimTypes.Role);
            if (Role.ToLower() == "administrador" || Role.ToLower() == "gestor")
            {
                var communication = _mapper.Map<Communication>(communicationDto);
                var result = await this._communicationService.UpdateCommunication(communication);
                return Ok(result);
            }
            return Unauthorized(new { succes = false, msg = "solo el administrador o el gestor pueden editar comunicaciones" });
        }

        // DELETE api/<CommunicationsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            _logger.LogInformation("usuario{usuario}esta intentando borrar comunicacion", email);
            string Role = User.FindFirstValue(ClaimTypes.Role);
            if (Role.ToLower() == "administrador" || Role.ToLower() == "gestor")
            {
                var result = await this._communicationService.DeleteCommunication(id);
                return Ok(result);                

            }
            return Unauthorized(new { succes = false, msg = "solo el administrador o el gestor pueden borrar comunicaciones" });

        }
    }
}
