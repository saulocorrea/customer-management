using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserSies = new HashSet<UserSy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<UserSy> UserSies { get; set; }
    }
}
