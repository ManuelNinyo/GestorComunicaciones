using System;
using System.Collections.Generic;

#nullable disable

namespace GestorComunicaciones.Core.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RoleId { get; set; }
        public string Email { get; set; }
    }
}
