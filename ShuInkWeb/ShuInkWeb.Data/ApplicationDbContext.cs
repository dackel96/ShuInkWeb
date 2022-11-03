using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Data.Entities;
using static ShuInkWeb.Data.Constants.UserConstants;
namespace ShuInkWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; } = null!;

        public DbSet<Artist> Artists { get; set; } = null!;

        public DbSet<Merchandise> Merchandises { get; set; } = null!;

        public DbSet<MerchandiseType> MerchandiseTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
               .Property(x => x.UserName)
               .HasMaxLength(UsernameMaxLength);

            builder.Entity<ApplicationUser>()
                .Property(x => x.Email)
                .HasMaxLength(EmailMaxLength);


            builder.Entity<Artist>()
                .HasData(new Artist()
                {
                    Id = Guid.NewGuid(),
                    NickName = "Shu",
                    FirstName = "Alexander",
                    LastName = "Spasov",
                    Resume = "Lorem Ipsum",
                    Availability = true,
                    WorkTime = "10:00 - 18:00"
                },
                new Artist()
                {
                    Id = Guid.NewGuid(),
                    NickName = "Svg",
                    FirstName = "Peter",
                    LastName = "Angelov",
                    Resume = "Lorem Ipsum",
                    Availability = true,
                    WorkTime = "10:00 - 18:00"
                });

            base.OnModelCreating(builder);
        }
    }
}