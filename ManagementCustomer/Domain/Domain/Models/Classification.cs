using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Classification
    {
        public Classification()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
