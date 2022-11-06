using ShuInkWeb.Data.Common;
using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.TattoConstants;
namespace ShuInkWeb.Data.Entities.Artists
{
    public class Tatto : Entity
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        public string? Title { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMax)]
        public string ImageUrl { get; set; } = null!;

        public Guid? ArtistId { get; set; }

        public Artist? Artist { get; set; }
    }
}
