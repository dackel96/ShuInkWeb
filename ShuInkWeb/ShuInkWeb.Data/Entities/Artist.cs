using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.ArtistConstants;
namespace ShuInkWeb.Data.Entities
{
    public class Artist
    {
        [Key]
        public Guid Id { get; init; }

        [Required]
        [MaxLength(ArtistNickNameMaxLength)]
        public string NickName { get; set; } = null!;

        [Required]
        [MaxLength(ArtistFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(ArtistLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(ResumeMaxLength)]
        public string Resume { get; set; } = null!;

        public bool Availability { get; set; }

        public string WorkTime { get; set; } = null!;

        public IEnumerable<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
