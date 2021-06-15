using Application.DTOs;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        public readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<CustomerDto> GetCustomersAdmin()
        {
            return _customerRepository.GetCustomersAdmin()
                .Select(c => (CustomerDto)c)
                .ToList();
        }

        public IEnumerable<CustomerDto> GetCustomersBySeller(int idUser)
        {
            return _customerRepository.GetCustomersBySeller(idUser)
                .Select(c => (CustomerDto)c)
                .ToList();
        }
    }
}
