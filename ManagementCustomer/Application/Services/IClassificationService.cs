using Application.DTOs;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IClassificationService
    {
        IEnumerable<ClassificationDto> GetClassifications();
    }
}
