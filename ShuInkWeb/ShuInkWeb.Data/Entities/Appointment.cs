﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.AppointmentConstants;

namespace ShuInkWeb.Data.Entities
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; init; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public bool Approved { get; set; }

        public IEnumerable<Duration> Durations { get; set; } = new HashSet<Duration>();

        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public Guid ArtistId { get; set; }

        [ForeignKey(nameof(ArtistId))]
        public Artist Artist { get; set; } = null!;
    }
}
