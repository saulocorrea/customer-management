using Domain.Models;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserSy> GetUsers();
    }
}
