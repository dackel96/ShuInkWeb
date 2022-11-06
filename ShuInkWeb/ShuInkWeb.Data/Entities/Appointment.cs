using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.AppointmentConstants;
using static ShuInkWeb.Data.Constants.UserConstants;
using ShuInkWeb.Data.Common;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.Data.Entities.Clients;

namespace ShuInkWeb.Data.Entities
{
    public class Appointment : Entity
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Guid ArtistId { get; set; }
        [ForeignKey(nameof(ArtistId))]
        public Artist Artist { get; set; } = null!;

        public Guid ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; } = null!;
    }
}
