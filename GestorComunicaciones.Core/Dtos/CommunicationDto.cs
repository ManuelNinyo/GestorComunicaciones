using System;
using System.Collections.Generic;

#nullable disable

namespace GestorComunicaciones.Core.Dtos
{
    public class CommunicationDto
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string ConsecutiveCode { get; set; }
        public int CommunicationTypeId { get; set; }
    }
}
