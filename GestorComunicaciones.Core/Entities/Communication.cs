using System;
using System.Collections.Generic;

#nullable disable

namespace GestorComunicaciones.Core.Entities
{
    public partial class Communication : BaseEntity<long>
    {
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string ConsecutiveCode { get; set; }
        public int CommunicationTypeId { get; set; }

        public virtual User Recipient { get; set; }
        public virtual User Sender { get; set; }
        public virtual CommunicationType CommunicationType { get; set; }
    }
}
