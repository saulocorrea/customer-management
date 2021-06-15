using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ManagementCustomer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("list-cities")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
        public ActionResult ListCitiesByRegion(int regionId)
        {
            IEnumerable<CityDto> cities = _addressService.GetCitiesByRegion(regionId);
            
            return Ok(cities);
        }

        [HttpGet("list-regions")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
        public ActionResult ListRegions()
        {
            IEnumerable<RegionDto> regions = _addressService.GetRegions();

            return Ok(regions);
        }
    }
}
