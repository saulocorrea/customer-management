using Domain.Models;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomersAdmin();
        IEnumerable<Customer> GetCustomersBySeller(int idUser);
    }
}
