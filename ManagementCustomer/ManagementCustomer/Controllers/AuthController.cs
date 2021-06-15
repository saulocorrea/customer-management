using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementCustomer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public LoginResponse Login([FromBody] LoginRequest request)
        {
            return new LoginResponse
            {
                Token = _authenticationService.GetUserToken(request.Email, request.Password)
            };
        }
    }
}
