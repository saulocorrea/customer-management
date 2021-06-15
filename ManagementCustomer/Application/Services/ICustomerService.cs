using Application.DTOs;
using System.Collections.Generic;

namespace Application.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetCustomersAdmin();
        IEnumerable<CustomerDto> GetCustomersBySeller(int idUser);
        IEnumerable<CustomerDto> FindCustomers(CustomerFilterRequest request);
    }
}
