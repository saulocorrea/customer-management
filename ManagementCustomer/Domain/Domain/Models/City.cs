using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class City
    {
        public City()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
