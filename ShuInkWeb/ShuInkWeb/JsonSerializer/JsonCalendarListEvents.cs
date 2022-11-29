using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Artists;
using ShuInkWeb.JsonSerializer.JsonModels;

namespace ShuInkWeb.JsonSerializer
{
    public static class JsonCalendarListEvents
    {
        public static string GetEventListJSONString(IEnumerable<Appointment> events)
        {
            var eventlist = new List<Event>();
            foreach (var model in events)
            {
                var myevent = new Event()
                {
                    id = model.Id,
                    start = model.Start,
                    end = model.End,
                    resourceId = model.ArtistId,
                    description = model.Description,
                    title = model.Title
                };
                eventlist.Add(myevent);
            }
            return System.Text.Json.JsonSerializer.Serialize(eventlist);
        }

        public static string GetResourceListJSONString(IEnumerable<AppointmentArtistViewModel> artists)
        {
            var resourcelist = new List<Resource>();

            foreach (var artist in artists)
            {
                var resource = new Resource()
                {
                    id = artist.Id,
                    title = artist.Name
                };
                resourcelist.Add(resource);
            }
            return System.Text.Json.JsonSerializer.Serialize(resourcelist);
        }
    }
}
