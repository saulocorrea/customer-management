using Application.DTOs;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IUserService
    {
        IEnumerable<UserSysDto> GetUsers();
    }
}
