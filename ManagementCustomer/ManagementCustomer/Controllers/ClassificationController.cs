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
    public class ClassificationController : Controller
    {
        private readonly IClassificationService _classificationService;
        public ClassificationController(IClassificationService classificationService)
        {
            _classificationService = classificationService;
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClassificationDto>))]
        public ActionResult List()
        {
            IEnumerable<ClassificationDto> classifications = _classificationService.GetClassifications();

            return Ok(classifications);
        }
    }
}
