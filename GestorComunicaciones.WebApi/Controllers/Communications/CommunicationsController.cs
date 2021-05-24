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
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        private readonly ICommunicationService _communicationService;
        public CommunicationsController(IMapper mapper, ICommunicationService communicationService)
        {
            _mapper = mapper;
            _communicationService = communicationService;
        }
        // GET: api/<CommunicationsController>
        [HttpGet]
        public async Task<IEnumerable<CommunicationDto>> GetAsync()
        {
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
        public async Task Post([FromBody] CommunicationDto communicationDto)
        {
            var communication = _mapper.Map<Communication>(communicationDto);
            await this._communicationService.InsertCommunication(communication);
        }

        // PUT api/<CommunicationsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody] CommunicationDto communicationDto)
        {
            var communication = _mapper.Map<Communication>(communicationDto);
            var result = await this._communicationService.UpdateCommunication(communication);
            return Ok(result);
        }

        // DELETE api/<CommunicationsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await this._communicationService.DeleteCommunication(id);
            return Ok(result);
        }
    }
}
