using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Core.Models.ArtistModels;

namespace ShuInkWeb.Core.Contracts
{
    public interface IArtistService
    {
        public Task<IEnumerable<ArtistViewModel>> GetArtistsInfoAsync();

        public Task<IEnumerable<AppointmentArtistViewModel>> GetArtistsIdAsync();

        public Task<bool> ExistByIdAsync(string userId);

        public Task<Guid> GetArtistIdAsync(string userId);

    }
}
