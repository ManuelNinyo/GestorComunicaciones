using System;
using System.Collections.Generic;

#nullable disable

namespace GestorComunicaciones.Core.Entities
{
    public partial class Role : BaseEntity<int>
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
