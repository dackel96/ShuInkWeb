using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.Data.Entities.Merchandises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Data.Configurations
{
    public class MerchandiseConfiguration : IEntityTypeConfiguration<MerchandiseType>
    {
        public void Configure(EntityTypeBuilder<MerchandiseType> builder)
        {
            //builder.HasData(SeedTypes());
        }
        private IEnumerable<MerchandiseType> SeedTypes()
        {
            var types = new HashSet<MerchandiseType>();

            var type1 = new MerchandiseType()
            {
                Id = Guid.NewGuid(),
                Name = "Cloth",
                CreatedOn = DateTime.Now,
            };
            types.Add(type1);
            var type2 = new MerchandiseType()
            {
                Id = Guid.NewGuid(),
                Name = "AfterCare",
                CreatedOn = DateTime.Now,
            };
            types.Add(type2);
            var type3 = new MerchandiseType()
            {
                Id = Guid.NewGuid(),
                Name = "Accessori",
                CreatedOn = DateTime.Now,
            };
            types.Add(type3);

            return types;
        }
    }
}
