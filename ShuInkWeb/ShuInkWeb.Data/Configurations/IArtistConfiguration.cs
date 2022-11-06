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
            builder.HasData(SeedArtists());
        }

        private IEnumerable<Artist> SeedArtists()
        {
            var artists = new HashSet<Artist>();

            var artist = new Artist()
            {
                UserId = "dea12856-c198-4129-b3f3-b893d8395082",
                Resume = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/shu.jpg",
                Tattos = SeedTattos()
            };

            artists.Add(artist);

            artist = new Artist()
            {
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                Resume = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/yngsovage.jpg",
                Tattos = SeedTattos()
            };

            artists.Add(artist);

            return artists;
        }
        private IEnumerable<Tatto> SeedTattos()
        {
            var tattos = new HashSet<Tatto>();

            var tatto = new Tatto()
            {
                Title = "rand1",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/1.jpg"
            };

            tattos.Add(tatto);

            tatto = new Tatto()
            {
                Title = "rand2",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/2.jpg"
            };

            tattos.Add(tatto);

            tatto = new Tatto()
            {
                Title = "rand3",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/15.jpg"
            };

            tattos.Add(tatto);


            return tattos;
        }
    }
}
