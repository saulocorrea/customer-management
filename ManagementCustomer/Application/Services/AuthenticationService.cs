using Application.DTOs;
using Application.Helpers;
using Domain.Models;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;
        public AuthenticationService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GetUserToken(string email, string password)
        {
            if (ValidateUser(email, password))
            {
                return GenerateJwtToken(GetUser(email));
            }

            return null;
        }

        public bool ValidateUser(string email, string password)
        {
            bool isValid = false;

            string md5Pass = MD5Helper.CreateMD5(password);

            using (var context = new stfContext())
            {
                isValid = context.UserSys
                    .Any(u => u.Email == email && u.Password == md5Pass);
            }

            return isValid;
        }

        public UserSy GetUser(string email)
        {
            UserSy user = null;

            using (var context = new stfContext())
            {
                user = context.UserSys
                    .AsNoTracking()
                    .Include(u => u.UserRole)
                    .Include(u => u.Customers).ThenInclude(u => u.Region)
                    .Include(u => u.Customers).ThenInclude(u => u.Gender)
                    .Include(u => u.Customers).ThenInclude(u => u.Classification)
                    .Include(u => u.Customers).ThenInclude(u => u.City)
                    .Where(u => u.Email == email)
                    .FirstOrDefault();
            }

            return user;
        }

        public UserSysDto GetUserById(int userId)
        {
            UserSy user = null;

            using (var context = new stfContext())
            {
                user = context.UserSys
                    .AsNoTracking()
                    .Include(u => u.UserRole)
                    .Include(u => u.Customers).ThenInclude(u => u.Region)
                    .Include(u => u.Customers).ThenInclude(u => u.Gender)
                    .Include(u => u.Customers).ThenInclude(u => u.Classification)
                    .Include(u => u.Customers).ThenInclude(u => u.City)
                    .Where(u => u.Id == userId)
                    .FirstOrDefault();
            }

            return (UserSysDto)user;
        }

        public UserSysDto GetUserByEmail(string email)
        {
            UserSy user = null;

            using (var context = new stfContext())
            {
                user = context.UserSys
                    .AsNoTracking()
                    .Include(u => u.UserRole)
                    .Include(u => u.Customers).ThenInclude(u => u.Region)
                    .Include(u => u.Customers).ThenInclude(u => u.Gender)
                    .Include(u => u.Customers).ThenInclude(u => u.Classification)
                    .Include(u => u.Customers).ThenInclude(u => u.City)
                    .Where(u => u.Email == email)
                    .FirstOrDefault();
            }

            return (UserSysDto)user;
        }

        private string GenerateJwtToken(UserSy user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new Claim[] {
                        new Claim(ClaimTypes.Name, user.Login),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.UserRole.Name),
                        new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                        new Claim("is_admin", user.UserRole.IsAdmin.ToString()),
                }
            ); ;

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromHours(10);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = credentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return token;
        }
    }
}
