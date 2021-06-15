using Application.DTOs;
using Application.Helpers;
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
    public class CustomerController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICustomerService _customerService;
        public CustomerController(
            IAuthenticationService authenticationService,
            ICustomerService customerService)
        {
            _authenticationService = authenticationService;
            _customerService = customerService;
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
        public ActionResult ListCustomers()
        {
            IEnumerable<CustomerDto> customers;

            if (User.GetUserIsAdmin())
            {
                customers = _customerService.GetCustomersAdmin();
            }
            else
            {
                customers = _customerService.GetCustomersBySeller(User.GetUserId());
            }

            return Ok(customers);
        }

        [HttpPost("find")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
        public ActionResult FindCustomers([FromBody] CustomerFilterRequest request)
        {
            IEnumerable<CustomerDto> customers;

            if (!User.GetUserIsAdmin())
            {
                request.UserId = User.GetUserId();
            }

            customers = _customerService.FindCustomers(request);

            return Ok(customers);
        }
    }
}
