using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Models.AppointmentModels
{
    public class AppointmentShareModel
    {
        public string Title { get; set; } = null!;

        public string Day { get; set; } = null!;

        public string Month { get; set; } = null!;

        public string DayOfWeek { get; set; } = null!;

        public bool IsFree { get; set; }

        public string? Start { get; set; }

        public string? End { get; set; }

        public string ArtistName { get; set; } = null!;
    }
}
