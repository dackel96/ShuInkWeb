using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.HappeningConstants;

namespace ShuInkWeb.Core.Models.HappeningModels
{
    public class HappeningViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
