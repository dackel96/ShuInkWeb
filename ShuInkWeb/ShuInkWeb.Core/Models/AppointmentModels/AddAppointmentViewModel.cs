using ShuInkWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.AppointmentConstants;
namespace ShuInkWeb.Core.Models.AppointmentModels
{
    public class AddAppointmentViewModel
    {
        [Required]
        [StringLength(TitleMaxLength,MinimumLength =TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength,MinimumLength =DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Range(0,23)]
        public int Duration { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string Beginning { get; set; } = null!;

        public Guid ArtistId { get; set; }

        public IEnumerable<Artist> Artists { get; set; } = new HashSet<Artist>();

        public ClientViewModel Client { get; set; } = null!;
    }
}
