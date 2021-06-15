using Domain.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomersAdmin();
        IEnumerable<Customer> GetCustomersBySeller(int idUser);
        IEnumerable<Customer> FindCustomers(string Name, int? GenderId, int? CityId, int? RegionId, DateTime? LastPurchaseFrom, DateTime? LastPurchaseUntil, int? ClassificationId, int? UserId);
    }
}