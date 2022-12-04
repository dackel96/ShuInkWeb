namespace ShuInkWeb.Extensions
{
    using System.Security.Claims;

    public static class ClaimsPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static string PhoneNumber(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.MobilePhone);
        }

        public static string Name(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Name);
        }
    }
}
