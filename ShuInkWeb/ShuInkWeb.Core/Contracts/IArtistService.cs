using ShuInkWeb.Core.Models.AppointmentModels;
using ShuInkWeb.Core.Models.ArtistModels;
using ShuInkWeb.Data.Entities.Artists;

namespace ShuInkWeb.Core.Contracts
{
    public interface IArtistService
    {
        public Task<IEnumerable<ArtistViewModel>> ArtistsInfo();

        public Task<IEnumerable<AppointmentArtistViewModel>> GetArtistsIdAsync();

    }
}
