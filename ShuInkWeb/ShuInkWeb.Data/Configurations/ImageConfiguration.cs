using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuInkWeb.Data.Entities.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(SeedTattos());
        }

        private IEnumerable<Image> SeedTattos()
        {
            var tattos = new HashSet<Image>();

            var tatto = new Image()
            {
                Id = Guid.NewGuid(),
                Title = "rand1",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/15.jpg"
            };

            tattos.Add(tatto);

            tatto = new Image()
            {
                Id = Guid.NewGuid(),
                Title = "rand2",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/1.jpg"
            };

            tattos.Add(tatto);

            tatto = new Image()
            {
                Id = Guid.NewGuid(),
                Title = "rand3",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/2.jpg"
            };

            tattos.Add(tatto);

            tatto = new Image()
            {
                Id = Guid.NewGuid(),
                Title = "rand1",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/3.jpg"
            };

            tattos.Add(tatto);

            tatto = new Image()
            {
                Id = Guid.NewGuid(),
                Title = "rand2",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/4.jpg"
            };

            tattos.Add(tatto);

            tatto = new Image()
            {
                Id = Guid.NewGuid(),
                Title = "rand3",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/5.jpg"
            };

            tattos.Add(tatto);

            return tattos;
        }
    }
}
