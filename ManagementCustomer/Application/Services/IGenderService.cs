using Application.DTOs;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IGenderService
    {
        IEnumerable<GenderDto> GetGenders();
    }
}
