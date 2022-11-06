using ShuInkWeb.Core.Contracts;

namespace ShuInkWeb.Core.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepository repository;

        public ArtistService(IRepository _repository)
        {
            this.repository = _repository;
        }
    }
}
