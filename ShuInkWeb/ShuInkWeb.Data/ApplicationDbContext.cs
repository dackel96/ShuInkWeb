using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Data.Configurations;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.Data.Entities.Clients;
using ShuInkWeb.Data.Entities.Merchandises;
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

        public DbSet<Happening> Happenings { get; set; } = null!;

        public DbSet<Artist> Artists { get; set; } = null!;

        public DbSet<Tatto> Tattos { get; set; } = null!;

        public DbSet<Client> Clients { get; set; } = null!;

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

            builder.ApplyConfiguration(new UsersConfiguration());

            builder.ApplyConfiguration(new ArtistsConfiguration());

            builder.ApplyConfiguration(new TattoConfiguration());

            base.OnModelCreating(builder);
        }
    }
}