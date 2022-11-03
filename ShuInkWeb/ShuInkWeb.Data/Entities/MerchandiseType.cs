using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.MerchandiseConstants;
namespace ShuInkWeb.Data.Entities
{
    public class MerchandiseType
    {
        public Guid Id { get; set; }
        [MaxLength(TypeMaxLength)]
        public string Type { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public virtual IEnumerable<Merchandise> Merchandises { get; set; } = new HashSet<Merchandise>();
    }
}
