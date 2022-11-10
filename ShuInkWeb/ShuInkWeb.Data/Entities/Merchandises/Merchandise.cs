using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ShuInkWeb.Data.Constants.MerchandiseConstants;

namespace ShuInkWeb.Data.Entities.Merchandises
{
    public class Merchandise : BaseDeletableModel<Guid>
    {
        [MaxLength(NameMaxLength)]
        [Required]
        public string Name { get; set; } = null!;

        [Precision(PrecisionDigits, PrecisionDigitsAfterSign)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        public string? Size { get; set; }

        public bool IsInStock { get; set; }

        public Guid MerchandiseTypeId { get; set; }
        [ForeignKey(nameof(MerchandiseTypeId))]
        public virtual MerchandiseType Type { get; set; } = null!;
    }
}
