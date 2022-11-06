using ShuInkWeb.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ShuInkWeb.Data.Constants.UserConstants;
namespace ShuInkWeb.Data.Entities.Artists
{
    public class Artist : Entity
    {
        [MaxLength(ResumeMaxLength)]
        public string? Resume { get; set; }

        public string UserId { get; set; } = null!;

        [Required]
        [MaxLength(ResumeMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public virtual IEnumerable<Tatto> Tattos { get; set; } = new HashSet<Tatto>();
    }
}
