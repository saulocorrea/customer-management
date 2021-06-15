using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class UserSy
    {
        public UserSy()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
