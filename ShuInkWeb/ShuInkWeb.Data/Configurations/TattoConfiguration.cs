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
    public class TattoConfiguration : IEntityTypeConfiguration<Tatto>
    {
        public void Configure(EntityTypeBuilder<Tatto> builder)
        {
            //builder.HasData(SeedTattos());
        }

        private IEnumerable<Tatto> SeedTattos()
        {
            var tattos = new HashSet<Tatto>();

            var tatto = new Tatto()
            {
                Title = "rand1",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/15.jpg"
            };

            tattos.Add(tatto);

            tatto = new Tatto()
            {
                Title = "rand2",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/1.jpg"
            };

            tattos.Add(tatto);

            tatto = new Tatto()
            {
                Title = "rand3",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/2.jpg"
            };

            tattos.Add(tatto);

            tatto = new Tatto()
            {
                Title = "rand1",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/3.jpg"
            };

            tattos.Add(tatto);

            tatto = new Tatto()
            {
                Title = "rand2",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/4.jpg"
            };

            tattos.Add(tatto);

            tatto = new Tatto()
            {
                Title = "rand3",
                ImageUrl = "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/5.jpg"
            };

            tattos.Add(tatto);

            return tattos;
        }
    }
}
