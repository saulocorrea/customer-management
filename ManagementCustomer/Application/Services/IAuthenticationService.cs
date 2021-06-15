using Application.DTOs;
using Domain.Models;

namespace Application.Services
{
    public interface IAuthenticationService
    {
        string GetUserToken(string email, string password);
        UserSy GetUser(string email);
        UserSysDto GetUserByEmail(string email);
        UserSysDto GetUserById(int userId);
    }
}
