namespace ShuInkWeb.Constants
{
    public static class WebConstants
    {
    }
    public static class MessageConstant
    {
        public const string ErrorMessage = "ErrorMessage";
        public const string WarningMessage = "WarningMessage";
        public const string SuccessMessage = "SuccessMessage";
    }
    public static class AccountControllerConstants
    {
        public const string RegisterConst = "Register";

        public const string LoginConst = "Login";

        public const string LogoutConst = "Logout";

        public const string InvalidLogin = "InvalidLogin";
    }
    public static class AreaConstants
    {
        public const string ArtistRoleName = "Artist";

        public const string ArtistControllerName = "Artist";

        public const string ArtistAreaName = "Artist";

        public const string IdentityRoleName = "Identity";

        public const string AdminRoleName = "Administrator";

        public const string ShopControllerName = "Merchandise";

        public const string ShopAreaName = "Shop";

    }
    public static class ActionsConstants
    {
        public const string IndexConst = "Index";

        public const string HomeConst = "Home";

        public const string AccountConst = "Account";

        public const string InvalidOperation = "/Account/AccessDenied";
    }
    public static class AppointmentControllerConstants
    {
        public const string EventsConst = "Events";

        public const string ResourceConst = "Resources";
    }
}
