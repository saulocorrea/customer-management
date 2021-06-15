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
    public class GenderController : Controller
    {
        private readonly IGenderService _genderService;
        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GenderDto>))]
        public ActionResult List()
        {
            IEnumerable<GenderDto> genders = _genderService.GetGenders();

            return Ok(genders);
        }
    }
}
