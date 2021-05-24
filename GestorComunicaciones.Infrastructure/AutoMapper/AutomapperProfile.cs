using AutoMapper;
using GestorComunicaciones.Core.Dtos;
using GestorComunicaciones.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorComunicaciones.Infrastructure.AutoMapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Communication, CommunicationDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<CommunicationType, CommunicationTypeDto>();

            CreateMap<UserDto, User>();
            CreateMap<CommunicationDto, Communication>();
            CreateMap<RoleDto, Role>();
            CreateMap<CommunicationTypeDto, CommunicationType>();

        }
    }
}