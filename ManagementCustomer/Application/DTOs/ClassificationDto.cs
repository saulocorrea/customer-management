using Domain.Models;

namespace Application.DTOs
{
    public class ClassificationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator ClassificationDto(Classification classification)
        {
            if (classification is null)
            {
                return null;
            }

            return new ClassificationDto
            {
                Id = classification.Id,
                Name = classification.Name
            };
        }
    }
}
