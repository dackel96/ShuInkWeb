using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Data.Constants
{
    public static class DataConstants
    {
    }
    public static class UserConstants
    {
        public const int UserFirstNameMaxLength = 25;
                         
        public const int UserFirstNameMinLength = 3;
                         
        public const int UserLastNameMaxLength = 25;
                         
        public const int UserLastNameMinLength = 3;

        public const int UsernameMaxLength = 20;

        public const int UsernameMinLength = 3;

        public const int PasswordMaxLength = 14;

        public const int PasswordMinLength = 7;

        public const int EmailMaxLength = 32;

        public const int EmailMinLength = 5;

        public const int UserSocialMediaMaxLength = 1000;

        public const int UserSocialMediaMinLength = 15;
    }
    public static class AppointmentConstants
    {
        public const int TitleMaxLength = 30;

        public const int TitleMinLength = 10;

        public const int DescriptionMaxLength = 500;

        public const int DescriptionMinLength = 20;
    }
    public static class ArtistConstants
    {
        public const int ArtistFirstNameMaxLength = 25;

        public const int ArtistFirstNameMinLength = 3;

        public const int ArtistLastNameMaxLength = 25;

        public const int ArtistLastNameMinLength = 3;

        public const int ArtistNickNameMaxLength = 25;

        public const int ArtistNickNameMinLength = 3;

        public const int ResumeMaxLength = 1000;

        public const int ResumeMinLength = 100;
    }
}
