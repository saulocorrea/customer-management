using Domain.Models;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IClassificationRepository
    {
        IEnumerable<Classification> GetClassifications();
    }
}
