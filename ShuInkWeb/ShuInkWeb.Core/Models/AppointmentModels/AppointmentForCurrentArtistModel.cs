namespace ShuInkWeb.Core.Models.AppointmentModels
{
    public class AppointmentForCurrentArtistModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string Start { get; set; } = null!;

        public string End { get; set; } = null!;

        public string ClientContact { get; set; } = null!;
    }
}
