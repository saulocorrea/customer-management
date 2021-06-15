using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public IEnumerable<City> GetCitiesByRegion(int regionId)
        {
            using (var context = new stfContext())
            {
                return context.Cities
                    .AsNoTracking()
                    .Include(c => c.Region)
                    .Where(c => c.RegionId == regionId)
                    .ToList();
            }
        }

        public IEnumerable<Region> GetRegions()
        {
            using (var context = new stfContext())
            {
                return context.Regions
                    .AsNoTracking()
                    .ToList();
            }
        }
    }
}
