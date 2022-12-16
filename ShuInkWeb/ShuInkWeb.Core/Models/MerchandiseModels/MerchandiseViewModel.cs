using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Data.Entities.Merchandises;
using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.MerchandiseConstants;

namespace ShuInkWeb.Core.Models.MerchandiseModels
{
    public class MerchandiseViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }

        [Precision(PrecisionDigits, PrecisionDigitsAfterSign)]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public Guid TypeId { get; set; }

        public IEnumerable<MerchandiseType> Types { get; set; } = new HashSet<MerchandiseType>();
    }
}
