using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<UserSy> GetUsers()
        {
            using (var context = new stfContext())
            {
                return context.UserSys
                    .AsNoTracking()
                    .ToList();
            }
        }
    }
}
