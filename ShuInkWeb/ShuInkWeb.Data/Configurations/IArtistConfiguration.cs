using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Data.Configurations
{
    public class IArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasData(new Artist()
            {

            });
        }

        private IEnumerable<IdentityUser> SeedArtists()
        {
            var users = new HashSet<ApplicationUser>();

            return users;
        }
    }
}
