using Application.DTOs;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class ClassificationService : IClassificationService
    {
        public readonly IClassificationRepository _classificationRepository;

        public ClassificationService(IClassificationRepository classificationRepository)
        {
            _classificationRepository = classificationRepository;
        }

        public IEnumerable<ClassificationDto> GetClassifications()
        {
            return _classificationRepository.GetClassifications()
                .Select(c => (ClassificationDto)c)
                .ToList();
        }
    }
}
