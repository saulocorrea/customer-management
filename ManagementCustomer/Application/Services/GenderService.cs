using Application.DTOs;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class GenderService : IGenderService
    {
        public readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public IEnumerable<GenderDto> GetGenders()
        {
            return _genderRepository.GetGenders()
                .Select(c => (GenderDto)c)
                .ToList();
        }
    }
}
