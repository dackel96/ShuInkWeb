using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ShuInkWeb.Data.Constants.MerchandiseConstants;

namespace ShuInkWeb.Data.Entities
{
    public class Merchandise
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(NameMaxLength)]
        [Required]
        public string Name { get; set; } = null!;

        [Precision(PrecisionDigits,PrecisionDigitsAfterSign)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string Image { get; set; } = null!;

        public bool IsInStock { get; set; }

        public Guid MerchandiseTypeId { get; set; }
        [ForeignKey(nameof(MerchandiseTypeId))]
        public virtual MerchandiseType Type { get; set; } = null!;
    }
}
