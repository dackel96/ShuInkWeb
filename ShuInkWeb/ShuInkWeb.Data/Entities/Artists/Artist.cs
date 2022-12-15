using ShuInkWeb.Data.Common;
using ShuInkWeb.Data.Entities.Identities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ShuInkWeb.Data.Constants.UserConstants;
namespace ShuInkWeb.Data.Entities.Artists
{
    public class Artist : BaseDeletableModel<Guid>
    {
        [MaxLength(ResumeMaxLength)]
        public string? Resume { get; set; }

        [Required]
        [MaxLength(ResumeMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLEngth)]
        public string Address { get; set; } = null!;

        public string? ApplicationUserId { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ApplicationUser { get; set; }

        public virtual IEnumerable<Image> Images { get; set; } = new HashSet<Image>();
    }
}
