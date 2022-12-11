using Newtonsoft.Json;
using ShuInkWeb.Data.Common.Repositories;
using ShuInkWeb.Data.Entities;
using ShuInkWeb.Data.Entities.Artists;

namespace ShuInkWeb.JsonSerializer
{
    public class JsonCalendarListEvents : IJsonCalendarListEvents
    {
        private readonly IDeletableEntityRepository<Appointment> appointmentDb;

        private readonly IDeletableEntityRepository<Artist> artistDb;
        public JsonCalendarListEvents(IDeletableEntityRepository<Appointment> _appointmentDb, IDeletableEntityRepository<Artist> _artistDb)
        {
            appointmentDb = _appointmentDb;
            artistDb = _artistDb;
        }

        public string GetEventListJSONString()
        {
            var events = appointmentDb.AllAsNoTracking()
                .Select(x => new
                {
                    id = x.Id,
                    title = x.Title,
                    start = x.Start,
                    end = x.End,
                    resorceId = x.ArtistId,
                    description = x.Description
                })
                .ToList();

            return JsonConvert.SerializeObject(events, Formatting.Indented);
        }

        public string GetResourceListJSONString()
        {
            var artists = artistDb.AllAsNoTracking()
                .Select(x => new
                {
                    id = x.Id,
                    title = x.ApplicationUser!.UserName
                })
                .ToList();

            return JsonConvert.SerializeObject(artists, Formatting.Indented);
        }
    }
}
