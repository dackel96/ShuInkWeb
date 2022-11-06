using ShuInkWeb.Core.Models.ArtistModels;

namespace ShuInkWeb.Core.Contracts
{
    public interface IArtistService
    {
        public Task<ArtistViewModel> ArtistInfo();
    }
}
