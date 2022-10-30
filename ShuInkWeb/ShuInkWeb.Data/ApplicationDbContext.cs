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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
               .Property(x => x.UserName)
               .HasMaxLength(UsernameMaxLength);

            builder.Entity<ApplicationUser>()
                .Property(x => x.Email)
                .HasMaxLength(EmailMaxLength);

            base.OnModelCreating(builder);
        }
    }
}