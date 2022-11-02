using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Models.AppointmentModels
{
    public class AppointmentViewModel
    {
        public string Start { get; set; } = null!;

        public string End { get; set; } = null!;

        public int Duration { get; set; }

        public int MyProperty { get; set; }


    }
}
