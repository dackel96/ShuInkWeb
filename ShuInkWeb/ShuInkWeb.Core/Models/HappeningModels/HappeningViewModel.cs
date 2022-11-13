using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.HappeningConstants;

namespace ShuInkWeb.Core.Models.HappeningModels
{
    public class HappeningViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;
    }
}
