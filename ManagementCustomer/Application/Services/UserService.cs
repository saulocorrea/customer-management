using Application.DTOs;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserSysDto> GetUsers()
        {
            return _userRepository.GetUsers()
                .Select(c => (UserSysDto)c)
                .ToList();
        }
    }
}
