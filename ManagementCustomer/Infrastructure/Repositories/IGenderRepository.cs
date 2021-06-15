using Domain.Models;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IGenderRepository
    {
        IEnumerable<Gender> GetGenders();
    }
}
