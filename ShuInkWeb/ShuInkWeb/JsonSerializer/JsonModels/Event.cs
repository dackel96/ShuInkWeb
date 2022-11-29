#nullable disable
namespace ShuInkWeb.JsonSerializer.JsonModels
{
    public class Event
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public Guid resourceId { get; set; }
        public string description { get; set; }
    }
}
