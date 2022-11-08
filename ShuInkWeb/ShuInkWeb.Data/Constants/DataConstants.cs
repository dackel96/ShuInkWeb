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

        public const int PhoneNumberLength = 10;

        public const string PhoneNumberRegex = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";

        public const int UserSocialMediaMaxLength = 1000;

        public const int UserSocialMediaMinLength = 15;

        public const int ResumeMaxLength = 1000;

        public const int ResumeMinLength = 100;

        public const int AddressMaxLEngth = 100;
    }
    public static class AppointmentConstants
    {
        public const int TitleMaxLength = 30;

        public const int TitleMinLength = 10;

        public const int DescriptionMaxLength = 500;

        public const int DescriptionMinLength = 20;
    }

    public static class MerchandiseConstants
    {
        public const int PrecisionDigits = 6;

        public const int PrecisionDigitsAfterSign = 2;

        public const int NameMaxLength = 25;

        public const int NameMinLength = 5;

        public const int DescriptionMaxLength = 50;

        public const int DescriptionMinLength = 1;

        public const int TypeMaxLength = 20;

        public const int TypeMinLength = 3;
    }
    public static class HappeningConstants
    {
        public const int TitleMaxLength = 20;

        public const int TitleMinLength = 5;

        public const int ContentMaxLength = 5000;

        public const int ContentMinLength = 50;

        public const int ImageUrlMax = 500;

        public const int ImageUrlMin = 22;
    }
    public static class TattoConstants
    {
        public const int TitleMaxLength = 20;

        public const int TitleMinLength = 5;

        public const int ImageUrlMax = 500;

        public const int ImageUrlMin = 22;
    }
}
