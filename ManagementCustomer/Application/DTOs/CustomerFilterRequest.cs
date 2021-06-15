using System;

namespace Application.DTOs
{
    public class CustomerFilterRequest
    {
        public string Name { get; set; }
        public int? GenderId { get; set; }
        public int? CityId { get; set; }
        public int? RegionId { get; set; }
        public DateTime? LastPurchaseFrom { get; set; }
        public DateTime? LastPurchaseUntil { get; set; }
        public int? ClassificationId { get; set; }
        public int? UserId { get; set; }
    }
}
