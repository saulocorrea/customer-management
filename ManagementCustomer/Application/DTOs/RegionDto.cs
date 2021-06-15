using Domain.Models;

namespace Application.DTOs
{
    public class RegionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator RegionDto(Region region)
        {
            if (region is null)
            {
                return null;
            }

            return new RegionDto
            {
                Id = region.Id,
                Name = region.Name
            };
        }
    }
}
