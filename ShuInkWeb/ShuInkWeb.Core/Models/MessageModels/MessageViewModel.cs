using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.MessageConstants;

namespace ShuInkWeb.Core.Models.MessageModels
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }

        public string? UserId { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        [MaxLength(ImageUrlMax)]
        public string? ImageUrl { get; set; }
    }
}
