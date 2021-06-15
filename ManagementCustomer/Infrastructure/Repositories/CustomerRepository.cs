using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetCustomersAdmin()
        {
            using (var context = new stfContext())
            {
                return context.Customers
                    .AsNoTracking()
                    .Include(c => c.Region)
                    .Include(c => c.Gender)
                    .Include(c => c.Classification)
                    .Include(c => c.City)
                    .Include(c => c.User)
                    .ToList();
            }
        }
        public IEnumerable<Customer> GetCustomersBySeller(int idUser)
        {
            using (var context = new stfContext())
            {
                return context.Customers
                    .AsNoTracking()
                    .Include(c => c.Region)
                    .Include(c => c.Gender)
                    .Include(c => c.Classification)
                    .Include(c => c.City)
                    .Include(c => c.User)
                    .Where(c => c.UserId == idUser)
                    .ToList();
            }
        }
    }
}
