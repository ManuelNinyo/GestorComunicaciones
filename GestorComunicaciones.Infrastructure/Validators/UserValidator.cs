using FluentValidation;
using GestorComunicaciones.Core.Dtos;
using GestorComunicaciones.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorComunicaciones.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email)
                .NotNull()
                .EmailAddress()
                .NotEmpty()
                .WithMessage("El Email debe tener contenido valido");
            RuleFor(user => user.RoleId)
                .NotNull()
                .NotEqual(0)
                .WithMessage("el RolId no puede ser null");

        }
    }
}
