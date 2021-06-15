using Application.DTOs;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IAddressService
    {
        IEnumerable<CityDto> GetCitiesByRegion(int regionId);
        IEnumerable<RegionDto> GetRegions();
    }
}
