using ShuInkWeb.Data.Common;
using ShuInkWeb.Data.Entities.Artists;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ShuInkWeb.Data.Constants.HappeningConstants;


namespace ShuInkWeb.Data.Entities
{
    public class Happening : BaseDeletableModel<Guid>
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

        public Guid? ArtistId { get; set; }

        [ForeignKey(nameof(ArtistId))]
        public Artist? Artist { get; set; }
    }
}
