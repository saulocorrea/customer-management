using System.Linq;
using System.Security.Claims;

namespace Application.Helpers
{
    public static class ClaimHelper
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.Claims.First(c => c.Type == ClaimTypes.PrimarySid).Value);
        }

        public static bool GetUserIsAdmin(this ClaimsPrincipal user)
        {
            return bool.Parse(user.Claims.First(c => c.Type == "is_admin").Value);
        }
    }
}
