using Domain.Models;

namespace Application.DTOs
{
    public class UserSysDto
    {
        public string Login { get; set; }
        public string Email { get; set; }

        public static explicit operator UserSysDto(UserSy user)
        {
            if (user is null)
            {
                return null;
            }

            return new UserSysDto
            {
                Email = user.Email,
                Login = user.Login
            };
        }
    }
}
