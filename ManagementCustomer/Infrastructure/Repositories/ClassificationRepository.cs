using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ClassificationRepository : IClassificationRepository
    {
        public IEnumerable<Classification> GetClassifications()
        {
            using (var context = new stfContext())
            {
                return context.Classifications
                    .AsNoTracking()
                    .ToList();
            }
        }
    }
}
