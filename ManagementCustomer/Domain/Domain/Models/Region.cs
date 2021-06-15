using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Region
    {
        public Region()
        {
            Cities = new HashSet<City>();
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
