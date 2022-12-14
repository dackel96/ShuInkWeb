using ShuInkWeb.Data.Entities.Artists;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ShuInkWeb.Data.Constants.ImageConstants;

namespace ShuInkWeb.Core.Models.GalleryModels
{
    public class ImageViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public Guid? ArtistId { get; set; }
    }
}
