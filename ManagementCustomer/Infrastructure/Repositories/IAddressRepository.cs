using Domain.Models;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IAddressRepository
    {
        IEnumerable<City> GetCitiesByRegion(int regionId);
        IEnumerable<Region> GetRegions();
    }
}
