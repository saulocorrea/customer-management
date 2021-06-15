using Domain.Models;
using System;

namespace Application.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string LastPurchase { get; set; }
        public string Classification { get; set; }
        public string Seller { get; set; }

        public static explicit operator CustomerDto(Customer customer)
        {
            if (customer is null)
            {
                return null;
            }

            return new CustomerDto
            {
                Id = customer.Id,
                City = customer.City.Name,
                Region = customer.Region.Name,
                Classification = customer.Classification.Name,
                Gender = customer.Gender.Name,
                Name = customer.Name,
                Phone = customer.Phone,
                LastPurchase = customer.LastPurchase?.ToString("dd/MM/yyyy"),
                Seller = customer.User.Login
            };
        }
    }
}
