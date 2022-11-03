using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Models.AppointmentModels
{
    public class AppointmentViewModel
    {
        public string Title { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string End { get; set; } = null!;

    }
}
