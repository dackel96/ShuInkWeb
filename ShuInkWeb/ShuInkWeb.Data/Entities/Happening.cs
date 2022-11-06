using ShuInkWeb.Data.Common;
using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.HappeningConstants;


namespace ShuInkWeb.Data.Entities
{
    public class Happening : Entity
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMax)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;
    }
}
