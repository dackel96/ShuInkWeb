namespace ShuInkWeb.Core.Contracts
{
    using ShuInkWeb.Core.Models.AppointmentModels;
    using ShuInkWeb.Core.Models.ArtistModels;

    public interface IArtistService
    {
        public Task<IEnumerable<ArtistViewModel>> ArtistsInfo();

        public Task<IEnumerable<AppointmentArtistViewModel>> GetArtistsIdAsync();

        public Task<bool> ExistById(string userId);

        public Task<Guid> GetArtistIdAsync(string userId);

    }
}
