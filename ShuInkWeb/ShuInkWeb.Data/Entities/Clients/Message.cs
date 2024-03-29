﻿using ShuInkWeb.Data.Common;
using ShuInkWeb.Data.Entities.Identities;
using System.ComponentModel.DataAnnotations;
using static ShuInkWeb.Data.Constants.MessageConstants;

namespace ShuInkWeb.Data.Entities.Clients
{
    public class Message : BaseDeletableModel<Guid>
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;


        [MaxLength(ImageUrlMax)]
        public string? ImageUrl { get; set; }

        public string? UserId { get; set; } = null!;

        public ApplicationUser? User { get; set; }
    }
}
