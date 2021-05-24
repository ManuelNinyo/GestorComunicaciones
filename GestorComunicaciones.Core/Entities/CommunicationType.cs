using System;
using System.Collections.Generic;

#nullable disable

namespace GestorComunicaciones.Core.Entities
{
    public partial class CommunicationType : BaseEntity<int>
    {
        public CommunicationType()
        {
            Communications = new HashSet<Communication>();
        }

        public string Name { get; set; }

        public virtual ICollection<Communication> Communications { get; set; }
    }
}
