using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        public IEnumerable<Gender> GetGenders()
        {
            using (var context = new stfContext())
            {
                return context.Genders
                    .AsNoTracking()
                    .ToList();
            }
        }
    }
}
