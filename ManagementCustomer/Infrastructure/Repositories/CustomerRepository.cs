using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public IEnumerable<Customer> FindCustomers(
            string name, 
            int? genderId, 
            int? cityId, 
            int? regionId, 
            DateTime? lastPurchaseFrom, 
            DateTime? lastPurchaseUntil, 
            int? classificationId, 
            int? userId)
        {
            using (var context = new stfContext())
            {
                IQueryable<Customer> query = context.Customers
                    .AsNoTracking()
                    .Include(c => c.Region)
                    .Include(c => c.Gender)
                    .Include(c => c.Classification)
                    .Include(c => c.City)
                    .Include(c => c.User);

                if (!string.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(c => c.Name.ToUpper().Contains(name.ToUpper()));
                }

                if (genderId.HasValue)
                {
                    query = query.Where(c => c.GenderId == genderId);
                }

                if (cityId.HasValue)
                {
                    query = query.Where(c => c.CityId == cityId);
                }

                if (regionId.HasValue)
                {
                    query = query.Where(c => c.RegionId == regionId);
                }

                if (classificationId.HasValue)
                {
                    query = query.Where(c => c.ClassificationId == classificationId);
                }

                if (userId.HasValue)
                {
                    query = query.Where(c => c.UserId == userId);
                }

                if (lastPurchaseFrom.HasValue && lastPurchaseUntil.HasValue)
                {
                    query = query.Where(c=> c.LastPurchase >= lastPurchaseFrom && c.LastPurchase <= lastPurchaseUntil);
                }

                return query.ToList();
            }
        }
        
    }
}
