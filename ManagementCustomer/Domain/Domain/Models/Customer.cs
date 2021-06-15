using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public int? CityId { get; set; }
        public int? RegionId { get; set; }
        public DateTime? LastPurchase { get; set; }
        public int? ClassificationId { get; set; }
        public int? UserId { get; set; }

        public virtual City City { get; set; }
        public virtual Classification Classification { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Region Region { get; set; }
        public virtual UserSy User { get; set; }
    }
}
