using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Models.ArtistModels;

namespace ShuInkWeb.Core.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepository repository;

        public ArtistService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public Task<ArtistViewModel> ArtistInfo()
        {
            throw new NotImplementedException();
        }
    }
}
