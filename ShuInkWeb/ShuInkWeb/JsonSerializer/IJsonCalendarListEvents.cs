using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Entities;

namespace ShuInkWeb.JsonSerializer
{
    public interface IJsonCalendarListEvents
    {
        public string GetEventListJSONString();

        public string GetResourceListJSONString();
    }
}
