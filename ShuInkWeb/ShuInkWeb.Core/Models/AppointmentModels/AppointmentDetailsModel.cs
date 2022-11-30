#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Models.AppointmentModels
{
    public class AppointmentDetailsModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ClientFirstName { get; set; }

        public string ClientLastName { get; set; }

        public string PhoneNumber { get; set; }

        public string SocialMedia { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string ArtistName { get; set; }
    }
}
