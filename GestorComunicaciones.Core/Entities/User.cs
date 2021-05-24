using System;
using System.Collections.Generic;

#nullable disable

namespace GestorComunicaciones.Core.Entities
{
    public partial class User : BaseEntity<int>
    {
        public User()
        {
            ReceivedCommunications = new HashSet<Communication>();
            SentCommunications = new HashSet<Communication>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Communication> ReceivedCommunications { get; set; }
        public virtual ICollection<Communication> SentCommunications { get; set; }
    }
}
