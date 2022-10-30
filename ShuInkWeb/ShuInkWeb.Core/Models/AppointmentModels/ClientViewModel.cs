using System.ComponentModel.DataAnnotations;

namespace ShuInkWeb.Core.Models.AppointmentModels
{
    public class ClientViewModel
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        [Required]
        public string ClientSocialMedia { get; set; } = null!;
    }
}
