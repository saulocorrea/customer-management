using Domain.Models;

namespace Application.DTOs
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public static explicit operator CityDto(City city)
        {
            if (city is null)
            {
                return null;
            }

            return new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                RegionId = city.RegionId
            };
        }
    }
}
