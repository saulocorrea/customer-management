using Application.DTOs;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class AddressService : IAddressService
    {
        public readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public IEnumerable<CityDto> GetCitiesByRegion(int regionId)
        {
            return _addressRepository.GetCitiesByRegion(regionId)
                .Select(c => (CityDto)c)
                .ToList();
        }
        
        public IEnumerable<RegionDto> GetRegions()
        {
            return _addressRepository.GetRegions()
                .Select(c => (RegionDto)c)
                .ToList();
        }
    }
}
