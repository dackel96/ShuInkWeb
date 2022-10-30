using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.ArtistConstants;
namespace ShuInkWeb.Data.Entities
{
    public class Artist
    {
        [Key]
        public Guid Id { get; init; }

        [Required]
        [MaxLength(ArtistNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ResumeMaxLength)]
        public string Resume { get; set; } = null!;

        public bool Availability { get; set; }

        public string WorkTime { get; set; } = null!;

        public IEnumerable<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
