using Domain.Models;

namespace Application.DTOs
{
    public class GenderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator GenderDto(Gender gender)
        {
            if (gender is null)
            {
                return null;
            }

            return new GenderDto
            {
                Id = gender.Id,
                Name = gender.Name
            };
        }
    }
}
