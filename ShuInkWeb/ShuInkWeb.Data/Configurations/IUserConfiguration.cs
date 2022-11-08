using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuInkWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Data.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
           // builder.HasData(SeedUsers());
        }
        private IEnumerable<ApplicationUser> SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var users = new HashSet<ApplicationUser>();

            var user = new ApplicationUser()
            {
                UserName = "Shu",
                Email = "shu@mail.com",
                PhoneNumber = "0895792178",
                FirstName = "Александър",
                LastName = "Спасов",
                SocialMedia = "https://www.facebook.com/alexandar.spasov2"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "shu!QAz");

            users.Add(user);

            user = new ApplicationUser()
            {
                UserName = "yngsovage",
                Email = "yngsovage@mail.com",
                PhoneNumber = "0895792378",
                FirstName = "Петър",
                LastName = "Ангелов",
                SocialMedia = "https://www.facebook.com/petar.angelov.92"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "yngsovage!QAz");

            users.Add(user);

            user = new ApplicationUser()
            {
                UserName = "dackel",
                Email = "dackel@mail.com",
                PhoneNumber = "0895792078",
                FirstName = "Иван",
                LastName = "Илиев",
                SocialMedia = "https://www.facebook.com/dackel96"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "dackel!QAz");

            users.Add(user);

            return users;
        }
    }
}
