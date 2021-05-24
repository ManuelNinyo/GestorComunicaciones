using FluentValidation;
using GestorComunicaciones.Core.Dtos;
using GestorComunicaciones.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorComunicaciones.Infrastructure.Validators
{
    public class CommunicationValidator : AbstractValidator<CommunicationDto>
    {
        public CommunicationValidator()
        {
            RuleFor(communication => communication.Content)
                .NotEmpty()
                .WithMessage("La Comunicacion debe tener contenido"); ;
            RuleFor(communication => communication.RecipientId)
                .NotNull()
                .NotEqual(0)
                .WithMessage("el DestinatarioId no puede ser null");
            RuleFor(communication => communication.SenderId)
                .NotNull()
                .NotEqual(0)
                .WithMessage("el RemirtenteId no puede ser null");
            RuleFor(communication => communication.CommunicationTypeId)
                .NotNull()
                .NotEqual(0)
                .WithMessage("el TipoCorrespondencia no puede ser null");
        }
    }
}
